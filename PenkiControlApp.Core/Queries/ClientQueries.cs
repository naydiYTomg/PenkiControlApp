namespace PenkiControlApp.Core.Queries
{
    public static class ClientQueries
    {
        public const string GET_CLIENT_QUERY = "SELECT * FROM \"Client\"";
        public const string GET_CLIENT_ID_BY_NAME_AND_SURNAME_QUERY = "SELECT \"Id\" FROM \"Client\" WHERE \"Name\" = @Name AND \"Surname\" = @Surname";

    }
}
