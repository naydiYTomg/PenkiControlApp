namespace PenkiControlApp.UI.InternalTypes;

public static class StringExtensions
{
    public static string Choice(this List<string> self)
    {
        var range = self.Count;
        var random = new Random();
        return self[random.Next(0, range)];
    }
}