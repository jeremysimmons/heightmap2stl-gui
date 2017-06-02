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
[assembly: AssemblyVersion("1.1.0.0")]
[assembly: AssemblyFileVersion("1.1.0.0")]

namespace app
{
    public partial class Main : Form
    {
        private const string DefaultXms = "64m";
        private const string DefaultXmx = "8g";
        private const string EmbeddedResourceName = "app.heightmap2stl.jar";
        private Process _p;
        private bool _autoBackup = true;

        public Main()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Boolean.TryParse(ConfigurationManager.AppSettings["AutoBackup"], out _autoBackup);
            AppendLog($"AutoBackup: {_autoBackup}");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            KillChildProcess();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ClearLog();

            if (FindJavaRuntime() == false)
            {
                AppendLog("JAVA cannot be found. Download/Install from https://java.com");
                return;
            }

            if (string.IsNullOrEmpty(txtFile.Text))
            {
                AppendLog("Error: Heightmap Source is empty");
                return;
            }

            var rawFileName = new FileInfo(txtFile.Text);
            var stlFile = new FileInfo(Path.Combine(Environment.CurrentDirectory,
                Path.GetFileNameWithoutExtension(rawFileName.FullName) + ".stl"));

            var backupStlFile = new FileInfo(Path.Combine(
                // Directory
                stlFile.DirectoryName,
                // FileName
                Path.GetFileNameWithoutExtension(stlFile.Name) +
                Regex.Replace(stlFile.LastWriteTime.ToString("s"), "[^a-zA-Z0-9]+", "-") +
                Path.GetExtension(stlFile.Name)
                ));

            if (_autoBackup)
            {
                if (stlFile.Exists && !backupStlFile.Exists)
                {
                    stlFile.MoveTo(backupStlFile.FullName);
                    AppendLog($"Info: A STL file with the name {stlFile.Name} already existed, and was renamed to {backupStlFile}");
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
                            AppendLog($"Created STL file {stlFile.FullName}");
                        }
                    },
                    null,
                    TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private void RunExport()
        {
            var rawFileName = new FileInfo(txtFile.Text);
            _p = new Process();
            _p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            _p.StartInfo.FileName = "java.exe";
            _p.StartInfo.Arguments = string.Join(" ",
                JavaSystemProperties(),
                "-jar",
                $"\"{AppTempPath()}\"",
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
            AppendLog(_p.StartInfo.FileName + " " + _p.StartInfo.Arguments);
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

            AppendLog(args.Data);
        }

        private void AppendLog(string text)
        {
            if (txtLog.InvokeRequired)
                txtLog.Invoke(new Action<string>(AppendLog), text);
            else
                txtLog.AppendText(text + Environment.NewLine);
        }

        private void ClearLog()
        {
            if (txtLog.InvokeRequired)
                txtLog.Invoke(new Action(ClearLog));
            else
                txtLog.Clear();
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
                AppendLog("User-supplied Xms is invalid. Using default: " + DefaultXms);
            }

            var rawXmx = settings["Xmx"];
            if (validSize.IsMatch(rawXmx))
            {
                properties["Xmx"] = rawXmx;
            }
            else
            {
                properties["Xmx"] = DefaultXmx;
                AppendLog("User-supplied Xmx is invalid. Using default: " + DefaultXmx);
            }

            // Prefix all the values with -D and combine with spaces
            return String.Join(" ", properties.Select(x => "-D" + x.Key + "=" + x.Value));
        }

        private bool FindJavaRuntime()
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
            string path = AppTempPath();
            if (File.Exists(path))
            {
                if (BinaryMatchesEmbeddedVersion(path) == false)
                {
                    AppendLog("Warning: Heightmap2STL.jar already exists, but doesn't match embedded version.");
                    AppendLog($"Current path: {path}");
                    AppendLog($"Current hash: {Md5HashFile(path)}");
                    AppendLog($"Embedded hash: {EmbeddedHeightmap2StlBinaryHash()}");

                    DialogResult result =
                        MessageBox.Show(this,
                            "The embedded version of Heightmap2STL doesn't match the temporarily unpacked version at '" +
                            path + "'.\n" +
                            "Do you want to overwrite this file with a trusted version?",
                            "Heightmap2STL",
                            MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        AppendLog("Info: Operation Cancelled. Prevented overwriting existing STL file.");
                        return false;
                    }
                }
            }

            using (Stream app = EmbeddedHeightmap2StlBinary())
            using (Stream writer = File.OpenWrite(path))
            {
                app?.CopyTo(writer);
            }
            return BinaryMatchesEmbeddedVersion(path);
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

        private static string AppTempPath()
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
                txtFile.Text = d.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            KillChildProcess();
            AppendLog(new string('-', 20));
            AppendLog("Warning: User cancelled processing");
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
                return BitConverter.ToString(hash);
            }
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
