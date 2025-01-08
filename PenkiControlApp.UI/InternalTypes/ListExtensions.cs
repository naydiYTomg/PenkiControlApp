namespace PenkiControlApp.UI.InternalTypes;

public static class ListExtensions
{
    public static List<List<T>> SplitChunks<T>(this List<T> self, int chunkSize)
    {
        var chunks = self.Select((value, index) => new { value, index })
            .GroupBy(x => x.index / chunkSize)
            .Select(group => group.Select(x => x.value).ToList())
            .ToList();
        return chunks;
    }
}