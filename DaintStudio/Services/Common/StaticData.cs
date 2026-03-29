
namespace DaintStudio.Services.Common;

public class StaticData
{
    public static string RootDrive = Path.GetPathRoot(Application.StartupPath) ?? @"C:\";
}
