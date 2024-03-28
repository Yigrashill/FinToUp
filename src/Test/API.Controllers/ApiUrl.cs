namespace Test.Api.Controllers;

internal static class ApiUrl
{
    private readonly static string finance  = "/api/finances/";

    public static string Finances(int? id)
    {
        return finance + id;
    }

    public static string Finances()
    {
        return finance;
    }
}

