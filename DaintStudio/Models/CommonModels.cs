
namespace DaintStudio.Models;

public class MainConfig
{
    public string? my_git_server_ip { get; set; }
}
public class MyGitConfig
{
    public string? server_ip {get; set; }
    public string? repository_name { get; set; }
}
public class FileScanModel
{
    public string? key { get; set; }
    public string? label { get; set; }
    public string? parentKey { get; set; }
    public string? type { get; set; }
}
public class ResponseModel<T>
{
    public bool ok { get; set; }
    public T? data { get; set; }
}    