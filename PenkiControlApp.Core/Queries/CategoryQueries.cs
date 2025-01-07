namespace PenkiControlApp.Core.Queries
{
    public static class CategoryQueries
    {
        public const string GET_CATEGORIES_QUERY = "select * from \"Category\"";
        public const string GET_CATEGORY_BY_ID_QUERY = """select * from "Category" where "Id"=@Id""";
        public const string GetCategoryIdByName = """ select * from "Category" where "Name"=@Name """;
        public const string GET_CATEGORY_ID = """ SELECT "Id" FROM "Category" """;
    }
}