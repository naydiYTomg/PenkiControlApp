namespace PenkiControlApp.DAL.Internal;

public static class StringExtensions
{
    public static string UpperFirstLetter(this string source)
    {
        if (string.IsNullOrEmpty(source)) return string.Empty;
        char[] letters = source.ToCharArray();
        letters[0] = char.ToUpper(letters[0]);
        return new string(letters);
    }
}