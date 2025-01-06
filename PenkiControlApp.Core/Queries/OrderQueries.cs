namespace PenkiControlApp.Core.Queries
{
    public static class OrderQueries
    {
        public const string GET_ORDER_QUERY = "SELECT * FROM \"Order\"";
        public const string INSERT_ORDER_QUERY = """
            INSERT INTO "Order" ("Sum", "Date", "UserId", "ClientId") VALUES (@Sum, @Date, @UserId, @ClientId) RETURNING "Id"
            """;
    }
}
