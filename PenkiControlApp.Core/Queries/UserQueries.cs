namespace PenkiControlApp.Core.Queries
{
    public static class UserQueries
    {
        public const string GET_USERS_QUERY = "SELECT * FROM \"User\"";
        public const string INSERT_USER_QUERY =
    "insert into public.\"User\" (\"Name\", \"Surname\", \"Login\", \"Password\", \"Manager\", \"Administrator\") values (@Name, @Surname, @Login, @Password, @Manager, @Administrator) returning \"Id\"";
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

        public const string GET_USER_PASSWORD_BY_LOGIN_QUERY =
            """
            select "Password" from "User" where "Login"=@Login
            """;

        public const string GET_ADMINISTRATOR_PASSWORD_BY_LOGIN_QUERY =
            """
            select "Password" from "User" where "Administrator"=true and "Login"=@Login
            """;
        public const string GET_MANAGER_PASSWORD_BY_LOGIN_QUERY =
            """
            select "Password" from "User" where "Manager"=true and "Login"=@Login
            """;
        public const string GET_USER_BY_LOGIN_QUERY = 
            """
            select * from "User" where "Login"=@Login
            """;
        public const string GET_ADMINISTRATOR_BY_LOGIN_QUERY = 
            """
            select * from "User" where "Administrator"=true and "Login"=@Login
            """;
        public const string GET_MANAGER_BY_LOGIN_QUERY = 
            """
            select * from "User" where "Manager"=true and "Login"=@Login
            """;
    }
}