

using System.Diagnostics;

namespace DaintStudio.Services.Common;

public class WindowRequestModel
{
    public string? file { get; set; }
}

public class PythonService
{

    public static string NormalizePath(string messyPath)
    {
        if (string.IsNullOrEmpty(messyPath))
            return string.Empty;

        // 1. Thay thế tất cả '/' thành '\'
        string normalized = messyPath.Replace("/", "\\");

        return normalized;
    }

    public static string RunPythonScript(string pythonPath, string scriptPath)
    {

        // 1. Khởi tạo thông tin tiến trình
        ProcessStartInfo start = new ProcessStartInfo();

        start.FileName = pythonPath; // Ví dụ: "python" hoặc @"C:\Python39\python.exe"
        start.Arguments = $"\"{scriptPath}\""; // Đối số là đường dẫn file main.py

        // 2. Cấu hình để đọc dữ liệu đầu ra
        start.UseShellExecute = false;       // Bắt buộc bằng false để redirect output
        start.RedirectStandardOutput = true; // Cho phép đọc kết quả từ lệnh print của Python
        start.RedirectStandardError = true;  // Cho phép đọc lỗi nếu có
        start.CreateNoWindow = true;         // Chạy ngầm, không hiện cửa sổ CMD đen
        start.Verb = "runas";

        string res = string.Empty;

        try
        {
            // 3. Bắt đầu chạy tiến trình
            using (Process process = Process.Start(start))
            {

                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();

                    res += "Output: " + result + "\n";
                }

                using (StreamReader errorReader = process.StandardError)
                {
                    string error = errorReader.ReadToEnd();

                    if (!string.IsNullOrEmpty(error))
                    {
                        res += "Error: " + error + "\n";
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi thực thi: " + ex.Message);
        }
        return res;
    }

    public static async Task<string> ExecutePython(string scriptPath)
    {

        string result = string.Empty;

        var path = NormalizePath(scriptPath);

        result = RunPythonScript("python", path);

        return result;

    }

    public static async Task<string> ExecuteScript(string scriptPath)
    {
        string result = string.Empty;

        var requestModel = JsonService.FromJson<WindowRequestModel>(scriptPath);

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "powershell.exe";

        var path = NormalizePath(requestModel.file);

        var argt = $"-ExecutionPolicy Bypass -File \"{path}\"";

        // Sử dụng -ExecutionPolicy Bypass để tránh bị chặn quyền thực thi
        startInfo.Arguments = argt;

        startInfo.RedirectStandardOutput = true;  // Đọc dữ liệu đầu ra
        startInfo.RedirectStandardError = true;   // Đọc lỗi nếu có
        startInfo.UseShellExecute = false;        // Bắt buộc bằng false để redirect output
        startInfo.CreateNoWindow = true;          // Chạy ẩn, không hiện cửa sổ xanh PowerShell
        startInfo.Verb = "runas";                 // Yêu cầu quyền Administrator (nếu cần)

        try
        {
            // 3. Thực thi script
            using (Process process = Process.Start(startInfo))
            {
                // Đọc kết quả trả về từ Script
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(output))
                {
                    Console.WriteLine("Kết quả thực thi:");
                    Console.WriteLine(output);
                }

                if (!string.IsNullOrEmpty(errors))
                {
                    Console.WriteLine("Lỗi (nếu có):");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errors);
                    Console.ResetColor();
                }

                process.WaitForExit();
                Console.WriteLine($"Tiến trình kết thúc với mã: {process.ExitCode}");

                result = $"ExitCode: {process.ExitCode}, Output: {output}, Errors: {errors}";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Đã xảy ra lỗi khi khởi chạy script: " + ex.Message);
        }

        return result;
    }

}
