using System.Windows.Documents;
using PenkiControlApp.Core.OutputModels;

namespace PenkiControlApp.UI.InternalTypes;

public class AllDatabaseData
{
    private static AllDatabaseData? _instance;
    private Dictionary<string, Dictionary<string, IOutputModel>> _data = new();
    private static int _loadedData = 0;

    public static AllDatabaseData GetInstance()
    {
        return _instance ??= new AllDatabaseData();
    }

    public (List<object>, string) GetData(string key, string? where)
    {
        // foreach (var (k, v) in _data)
        // {
        //     Console.WriteLine($"{k}:");
        //     foreach (var (n, d) in v)
        //     {
        //         Console.WriteLine($"\t- {d}");
        //     }
        // }
        // Console.WriteLine($"key is {key}, where is {where}");
        if (where is not null)
        {
            // Console.WriteLine($"trying to find {key} in category {where}");
            List<object> output = [];
            foreach (var (k, v) in _data[where.ToLower()])
            {
                if (k == key)
                {
                    output.Add(v);
                }
            }
            
            // Console.WriteLine($"{key} not found in category {where}");
            return (output, where);

        }
        else
        {
            // Console.WriteLine($"trying to find {key} in all categories");
            try
            {
                List<object> output = [];
                foreach (var (s, value) in _data)
                {
                    // Console.WriteLine($"searching {key} in {s}");
                    foreach (var (k, o) in value)
                    {
                        // Console.WriteLine($"Element :{k}:; key :{key}:");
                        if (k.Equals(key, StringComparison.CurrentCultureIgnoreCase))
                        {
                            output.Add((o, s));
                        }
                    }
                }
                // Console.WriteLine($"{key} not found in database");
                return (output, "None");

            }
            catch (Exception e)
            {
                // Console.WriteLine($"{key} not found in database");
                return ([], "None");
            }
        }
    }
    private AllDatabaseData() {}

    public async Task<bool> LoadData()
    {
        switch (_loadedData)
        {
            case 0:
                var categories = App.CategoryManager.GetCategories();
                Dictionary<string, IOutputModel> categoriesDict = new Dictionary<string, IOutputModel>();
                categories.ForEach(x =>
                {
                    categoriesDict[x.Name] = x;
                });
                _data["categories"] = categoriesDict;
                _loadedData++;
                return true;
                break;
            case 1:
                var tags = App.TagManager.GetAllTags();
                Dictionary<string, IOutputModel> tagsDict = new Dictionary<string, IOutputModel>();
                tags.ForEach(x =>
                {
                    tagsDict[x.Name] = x;
                });
                _data["tags"] = tagsDict;
                _loadedData++;
                return true;
                break;
            case 2:
                var orders = App.OrderManager.GetAllOrders();
                Dictionary<string, IOutputModel> ordersDict = new Dictionary<string, IOutputModel>();
                orders.ForEach(x =>
                {
                    ordersDict[x.Id.ToString()] = x;
                });
                _data["orders"] = ordersDict;
                _loadedData++;
                return true;
                break;
            case 3:
                var products = App.ProductManager.GetAllProducts();
                Dictionary<string, IOutputModel> productsDict = new Dictionary<string, IOutputModel>();
                products.ForEach(x =>
                {
                    productsDict[x.Name] = x;
                });
                _data["products"] = productsDict;
                _loadedData++;
                return true;
                break;
            case 4:
                var clients = App.ClientManager.GetAllClientsForSearch();
                Dictionary<string, IOutputModel> clientsDict = new Dictionary<string, IOutputModel>();
                clients.ForEach(x =>
                {
                    clientsDict[x.Name.ToString()] = x;
                });
        
                _data["clients"] = clientsDict;
                _loadedData++;
                return true;
                break;
            default:
                return false;
                break;
        }
    }
    
}