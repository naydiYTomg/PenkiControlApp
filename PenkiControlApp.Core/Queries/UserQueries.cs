namespace PenkiControlApp.Core.Queries
{
    public class UserQueries
    {
        public const string GET_USERS_QUERY = "SELECT * FROM \"User\"";
<<<<<<< HEAD
        public const string INSERT_USER_QUERY =
    "insert into public.\"User\" (\"Name\", \"Login\", \"Password\") values (@Name, @Login, @Password) returning \"Id\"";

        public const string GET_USER_BY_ID_QUERY =
            "select \"Id\", \"Name\", \"Login\", \"Password\" from \"User\" where \"Id\"=@Id";
=======
>>>>>>> main
    }
}
