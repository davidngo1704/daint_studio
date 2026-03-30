using DaintStudio.Models;
using System.Diagnostics;

namespace DaintStudio.Services.Common;

public class ExecuteScriptWindow
{
    public static WindowScriptModel RunScript(string content)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "powershell.exe";

        string path = Path.Combine(StaticData.Database, "window_scripts", "deploy_api_gateway.ps1");

        FileHelper.WriteText(path, content);

        startInfo.Arguments = @$"-ExecutionPolicy Bypass -File ""{path}""";
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        startInfo.UseShellExecute = false;
        startInfo.CreateNoWindow = true;

        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();

        process.WaitForExit();

        return new WindowScriptModel()
        {
            fail = error,
            success = output
        };

    }
}
