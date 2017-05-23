using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: AssemblyTitle("heightmap2stl-gui")]
[assembly: AssemblyProduct("heightmap2stl-gui")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

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

    public partial class Main : Form
    {
        private Process _p;

        public Main()
        {
            InitializeComponent();
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
            var stlFilePath = Path.GetFileNameWithoutExtension(rawFileName.FullName) + ".stl";
            if (File.Exists(stlFilePath))
            {
                var overwrite = MessageBox.Show(this,
                    "Do you want to overwrite?" + Path.GetFileName(stlFilePath),
                    "File Exists",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (overwrite == DialogResult.No)
                {
                    AppendLog("Info: Operation Cancelled. Prevented overwriting existing STL file.");
                    return;
                }
            }

            ExtractBinary();

            btnCreate.Enabled = false;
            btnCancel.Enabled = true;

            Task.Factory.StartNew(RunExport).ContinueWith((ancestor, _) =>
            {
                btnCreate.Enabled = true;
                btnCancel.Enabled = false;
            },
            null,
            TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void RunExport()
        {
            var rawFileName = new FileInfo(txtFile.Text);
            _p = new Process();
            _p.StartInfo.FileName = "java.exe";
            _p.StartInfo.Arguments = string.Join(" ",
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

        private void ExtractBinary()
        {
            string path = AppTempPath();
            if (File.Exists(path)) return;
            var asm = Assembly.GetEntryAssembly();
            using (Stream app = asm.GetManifestResourceStream("app.heightmap2stl.jar"))
            using (Stream writer = File.OpenWrite(path))
            {
                app?.CopyTo(writer);
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
    }
}
