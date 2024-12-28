namespace PenkiControlApp.UI.InternalTypes;

public class AllDatabaseData
{
    private static AllDatabaseData? _instance;
    private static Dictionary<string, object> _data = new();

    public static AllDatabaseData GetInstance()
    {
        return _instance ??= new AllDatabaseData();
    }

    public static void LoadAllData()
    {
        
    }
}