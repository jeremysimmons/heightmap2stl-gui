using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: AssemblyTitle("heightmap2stl-gui")]
[assembly: AssemblyProduct("heightmap2stl-gui")]
[assembly: AssemblyVersion("1.3.2.0")]
[assembly: AssemblyFileVersion("1.3.2.0")]

namespace app
{
    public partial class Main : Form
    {
        private const string DefaultXms = "64m";
        private const string DefaultXmx = "8g";
        private const string EmbeddedResourceName = "app.heightmap2stl.jar";
        private Process _p;
        private bool _autoBackup = true;
        private string _lastCustom;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            SetInputPath((e.Data.GetData(DataFormats.FileDrop) as string[])?.FirstOrDefault());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            // Initial output path
            SetOutputPath(GetOutputPath());

            // Version
            Text += $" {GetVersion()}";
            Log($"Version: {GetVersion()}");

            // Autobackup
            Boolean.TryParse(ConfigurationManager.AppSettings["AutoBackup"], out _autoBackup);
            chkAutoBackup.Checked = _autoBackup;
            Log($"AutoBackup: {_autoBackup}");
        }

        private Version GetVersion() => Assembly.GetEntryAssembly().GetName().Version;

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            KillChildProcess();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ClearLog();

            if (CheckForJavaInPath() == false)
            {
                Log("JAVA cannot be found. Download/Install from https://java.com");
                return;
            }

            if (GetInputFile() == null)
            {
                Log("Error: Heightmap Source is empty");
                return;
            }

            var rawFileName = GetInputFile();
            var outDirectory = GetOutputPath();
            Log($"Input File: {rawFileName}");
            Log($"Output Path: {outDirectory}");

            var stlFile = new FileInfo(Path.Combine(outDirectory,
                Path.GetFileNameWithoutExtension(rawFileName.FullName) + ".stl"));

            if (_autoBackup)
            {
                Log($"Autobackup: {_autoBackup}");
                var backupStlFile = new FileInfo(Path.Combine(
                    // Directory
                    outDirectory,
                    // FileName
                    Path.GetFileNameWithoutExtension(stlFile.Name) +
                        Regex.Replace(stlFile.LastWriteTime.ToString("s"), "[^a-zA-Z0-9]+", "-") +
                        stlFile.Extension
                    ));

                if (stlFile.Exists && !backupStlFile.Exists)
                {
                    stlFile.MoveTo(backupStlFile.FullName);
                    Log($"Info: A STL file with the name {stlFile.Name} already existed, and was renamed to {backupStlFile}");
                }
            }

            if (EnsureHeightmap2StlBinary())
            {
                btnCreate.Enabled = false;
                btnCancel.Enabled = true;

                Task.Factory.StartNew(RunExport).ContinueWith((ancestor, _) =>
                    {
                        btnCreate.Enabled = true;
                        btnCancel.Enabled = false;
                        if (ancestor.IsCompleted)
                        {
                            Log($"Created STL file {stlFile.FullName}");
                        }
                    },
                    null,
                    TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private void RunExport()
        {
            var rawFileName = GetInputFile();
            _p = new Process();
            _p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            _p.StartInfo.FileName = "java.exe";
            _p.StartInfo.Arguments = string.Join(" ",
                JavaSystemProperties(),
                "-jar",
                $"\"{GetAppTempPath()}\"",
                $"\"{rawFileName.FullName}\"",
                numModelHeight.Text,
                numBaseHeight.Text
            );
            _p.StartInfo.CreateNoWindow = true;
            _p.StartInfo.UseShellExecute = false;
            _p.StartInfo.RedirectStandardOutput = true;
            _p.StartInfo.RedirectStandardError = true;
            _p.OutputDataReceived += OnDataReceived;
            _p.ErrorDataReceived += OnDataReceived;
            _p.Start();
            Log(_p.StartInfo.FileName + " " + _p.StartInfo.Arguments);
            _p.BeginOutputReadLine();
            _p.BeginErrorReadLine();
            _p.WaitForExit(360000);
            _p.Close();
            _p = null;
        }

        private void OnDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (args.Data == null)
                return;

            Log(args.Data);
        }

        // CrossThreadSafe
        private void Log(string text)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action<string>(Log), text);
            }
            else
            {
                txtLog.AppendText(text + Environment.NewLine);
            }
        }

        // CrossThreadSafe
        private void ClearLog()
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(ClearLog));
            }
            else
            {
                txtLog.Clear();
            }
        }

        private string JavaSystemProperties()
        {
            var settings = ConfigurationManager.AppSettings;
            var validSize = new Regex(@"\d+[kKmMgG]");
            var properties = new Dictionary<string, string>();

            // Process each setting
            var rawXms = settings["Xms"];
            if (validSize.IsMatch(rawXms))
            {
                properties["Xms"] = rawXms;
            }
            else
            {
                properties["Xms"] = DefaultXms;
                Log("User-supplied Xms is invalid. Using default: " + DefaultXms);
            }

            var rawXmx = settings["Xmx"];
            if (validSize.IsMatch(rawXmx))
            {
                properties["Xmx"] = rawXmx;
            }
            else
            {
                properties["Xmx"] = DefaultXmx;
                Log("User-supplied Xmx is invalid. Using default: " + DefaultXmx);
            }

            // Prefix all the values with -D and combine with spaces
            return String.Join(" ", properties.Select(x => "-D" + x.Key + "=" + x.Value));
        }

        // A standard java install will add java.exe to %PATH%
        private bool CheckForJavaInPath()
        {
            try
            {
                var psi = new ProcessStartInfo("java.exe", "-version");
                psi.UseShellExecute = true;
                var process = Process.Start(psi);
                process?.WaitForExit(50000);
                return process?.ExitCode == 0;
            }
            catch
            {
                // ignored
            }
            return false;
        }

        private Stream EmbeddedHeightmap2StlBinary()
        {
            var asm = Assembly.GetEntryAssembly();
            return asm.GetManifestResourceStream(EmbeddedResourceName);
        }

        private bool EnsureHeightmap2StlBinary()
        {
            string path = GetAppTempPath();
            if (File.Exists(path))
            {
                if (BinaryMatchesEmbeddedVersion(path) == false)
                {
                    Log("Warning: Replacing heightmap2stl.jar at {path}.");
                    Log($"Current hash: {Md5HashFile(path)}");
                    Log($"Embedded hash: {EmbeddedHeightmap2StlBinaryHash()}");
                    File.Delete(path);
                    CopyEmbeddedHeightmap2StlBinaryToTemp(path);
                    Log($"Replaced");
                }
            }
            else
            {
                CopyEmbeddedHeightmap2StlBinaryToTemp(path);
            }

            return BinaryMatchesEmbeddedVersion(path);
        }

        private void CopyEmbeddedHeightmap2StlBinaryToTemp(string path)
        {
            using (Stream app = EmbeddedHeightmap2StlBinary())
            using (Stream writer = File.OpenWrite(path))
            {
                app?.CopyTo(writer);
            }
            Log($"Deployed heightmap2stl.jar with hash: {Md5HashFile(path)}");

        }

        private bool BinaryMatchesEmbeddedVersion(string path)
        {
            return Md5HashFile(path) == EmbeddedHeightmap2StlBinaryHash();
        }

        private string EmbeddedHeightmap2StlBinaryHash()
        {
            using (Stream binary = EmbeddedHeightmap2StlBinary())
            {
                return Md5HashStream(binary);
            }
        }

        private static string GetAppTempPath()
        {
            return Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "heightmap2stl.jar");
        }

        private void hostSoftwareSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start((string)e.Link.Tag);
        }

        private void btnPick_Click(object sender, EventArgs e)
        {
            using (FileDialog d = new OpenFileDialog())
            {
                if (DialogResult.OK != d.ShowDialog()) return;
                SetInputPath(d.FileName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            KillChildProcess();
            Log(new string('-', 20));
            Log("Warning: User cancelled processing");
        }

        private void KillChildProcess()
        {
            _p?.Kill();
        }

        private static string Md5HashFile(string filePathName)
        {
            using (var stream = File.OpenRead(filePathName))
                return Md5HashStream(stream);
        }

        private static string Md5HashStream(Stream stream)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = GetOutputPath();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                if (!radOutCustom.Checked)
                {
                    radOutCustom.Checked = true;
                }
                SetOutputPath(dialog.FileName);
            }
            else
            {
                if(GetOutputPath() != Environment.CurrentDirectory)
                {
                    SetOutputPath(Environment.CurrentDirectory);
                }
            }
        }

        private void radOutput_Click(object sender, EventArgs e)
        {
            if (radOutCustom.Checked)
            {
                SetOutputPath(_lastCustom);
                if (GetOutputPath() == Environment.CurrentDirectory)
                {
                    Log("Rember to set your custom path");
                }
            }

            UpdateOutputPath();
        }

        private void SetInputPath(string fileName)
        {
            txtInputFile.Text = fileName;
            UpdateOutputPath();
        }

        private FileInfo GetInputFile()
        {
            return 
                String.IsNullOrEmpty(txtInputFile.Text) ? 
                    null : 
                    new FileInfo(txtInputFile.Text);
        }

        private void SetOutputPath(string outputPath)
        {
            txtOutputPath.Text = outputPath;
            if (radOutCustom.Checked)
            {
                _lastCustom = outputPath;
            }
        }

        private string GetOutputPath()
        {
            if (radOutProgram.Checked)
            {
                return Environment.CurrentDirectory;
            }

            // same as input file
            if(radOutSource.Checked)
            {
                // input file might not be set yet, fallback to current directory
                var inputFile = GetInputFile();
                if (inputFile == null)
                {
                    Log("No Input image specified. Output path will update when input is selected.");
                    return Environment.CurrentDirectory;
                }
                
                // Use the directory of the input file if it's available, otherwise current directory
                return inputFile.DirectoryName ?? Environment.CurrentDirectory;
            }

            if(radOutCustom.Checked)
            {
                if (string.IsNullOrEmpty(txtOutputPath.Text))
                {
                    return Environment.CurrentDirectory;
                }

                return txtOutputPath.Text;
            }

            // Final fallback
            return Environment.CurrentDirectory;
        }

        private void UpdateOutputPath()
        {
            txtOutputPath.Text = GetOutputPath();
        }
    }
}
namespace app
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // The rest of the program assumes CurrentDirectory is the directory the exe is in
            Environment.CurrentDirectory = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
