
namespace DaintStudio.Services.Common;

public class StaticData
{

    public static string RootDrive = Path.GetPathRoot(Application.StartupPath) ?? @"C:\";

    public static string Database = Path.Combine((Path.GetPathRoot(Application.StartupPath) ?? @"C:\"), "database");

}
