namespace PenkiControlApp.Core.Queries
{
    public static class ClientQueries
    {
        public const string GET_CLIENT_QUERY = "SELECT * FROM \"Client\"";
        public const string GET_CLIENT_BY_ID_QUERY = "SELECT * FROM \"Client\" WHERE \"Name\" = @Name";

    }
}
