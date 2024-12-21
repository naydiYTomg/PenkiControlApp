namespace PenkiControlApp.Core.Queries
{
    public static class UserQueries
    {
        public const string GET_USERS_QUERY = "SELECT * FROM \"User\"";
        public const string INSERT_USER_QUERY =
    "insert into public.\"User\" (\"Name\", \"Surname\", \"Login\", \"Password\", \"Manager\", \"Administrator\") values (@Name, @Login, @Password, @Manager, @Surname, @Administrator) returning \"Id\"";
        public const string GET_USER_BY_ID_QUERY =
            """
            select "Id", "Name", "Surname", "Login", "Password", "Manager", "Administrator" from "User" where "Id"=@Id
            """;

        public const string GET_MANAGERS_QUERY =
            """
            select "Id", "Name", "Surname", "Login", "Password", "Manager", "Administrator" from "User" where "Manager"=true
            """;
        public const string GET_ADMINISTRATORS_QUERY =
            """
            select "Id", "Name", "Surname", "Login", "Password", "Manager", "Administrator" from "User" where "Administrator"=true
            """;
    }
}