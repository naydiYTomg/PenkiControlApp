namespace PenkiControlApp.Core.Queries
{
    public static class UserQueries
    {
        public const string GET_USERS_QUERY = "SELECT * FROM \"User\"";
        public const string INSERT_USER_QUERY =
    "insert into public.\"User\" (\"Name\", \"Login\", \"Password\", \"Manager\") values (@Name, @Login, @Password, @Manager) returning \"Id\"";
        public const string GET_USER_BY_ID_QUERY =
            "select \"Id\", \"Name\", \"Login\", \"Password\", \"Manager\" from \"User\" where \"Id\"=@Id";

        public const string GET_MANAGERS_QUERY =
            "select \"Id\", \"Name\", \"Login\", \"Password\", \"Manager\" from \"User\" where \"Manager\"=true";
    }
}