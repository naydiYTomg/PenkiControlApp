namespace PenkiControlApp.Core;

public static class Constants
{
    public const string CONNECTION_INFO = "Server=localhost;Port=5432;User Id=postgres;Password=azure;Database=Testik";


    public const string INSERT_USER_QUERY =
        "insert into public.\"User\" (\"Name\", \"Login\", \"Password\") values (@Name, @Login, @Password) returning \"Id\"";

    public const string GET_USER_BY_ID_QUERY =
        "select \"Id\", \"Name\", \"Login\", \"Password\" from \"User\" where \"Id\"=@Id";

    public const string DO_QQQ = "select * from \"Order\"";
}