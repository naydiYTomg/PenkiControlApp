namespace PenkiControlApp.Core.Queries
{
    public static class ClientQueries
    {
        public const string GET_CLIENT_QUERY = "SELECT * FROM \"Client\"";
        public const string GET_CLIENT_ID_BY_NAME_AND_SURNAME_QUERY = "SELECT \"Id\" FROM \"Client\" WHERE \"Name\" = @Name AND \"Surname\" = @Surname";
        public const string GetClientsFavoriteNTagsQuery = """
                                                   select t."Id", sum(t."Count") as "Count"
                                                   from (select T."Id", "Count"
                                                         from "Client" join public."Order" Orde on "Client"."Id" = Orde."ClientId"
                                                                       join public."OrderProductRelationship" OPR on Orde."Id" = OPR."OrderId"
                                                                       join public."ProductTagRelationship" PTR on OPR."ProductId" = PTR."ProductId"
                                                                       join public."Tag" T on T."Id" = PTR."TagId" where "Client"."Id"=@Id) as t
                                                   group by t."Id"
                                                   order by "Count" desc limit @N;
                                                   """;
    }
}
