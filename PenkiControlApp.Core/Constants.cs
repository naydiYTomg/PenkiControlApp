namespace PenkiControlApp.Core;

public static class Constants
{
    public static readonly string CONNECTION_INFO = Environment.GetEnvironmentVariable("DATABASE_ACCESS")!;

    

    public const string DO_QQQ = "select * from \"Order\"";
}