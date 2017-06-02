<Query Kind="Statements" />

Process p = new Process();
var info = p.StartInfo;
info.FileName = "cmd.exe";
info.Arguments = @"/c ""java -XX:+PrintFlagsFinal -version | findstr /i ""InitialHeapSize MaxHeapSize"" "" ";

info.CreateNoWindow = true;
info.UseShellExecute = false;
info.RedirectStandardOutput = true;
info.RedirectStandardError = true;
p.Start();
p.WaitForExit(2000);
var output = p.StandardOutput.ReadToEnd();
var parts = output.Split('\n', '\r').Select(x => x.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToList();
parts.Dump();
p.Close();
output.Dump();