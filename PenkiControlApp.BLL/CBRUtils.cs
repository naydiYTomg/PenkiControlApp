namespace PenkiControlApp.BLL;

public static class CBRUtils
{
    public static async Task<decimal> ConvertToDollars(decimal rubles)
    {
        decimal exchangeRate = await GetExchangeRate();
        decimal priceInDollars = rubles / exchangeRate;
        return priceInDollars;
    }

    private static async Task<decimal> GetExchangeRate()
    {
        using (HttpClient client = new HttpClient())
        {
            const string url = "https://www.cbr-xml-daily.ru/daily_json.js";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json)!;
            decimal usd = data.Valute.USD.Value;
            return usd;
        }
    }
}