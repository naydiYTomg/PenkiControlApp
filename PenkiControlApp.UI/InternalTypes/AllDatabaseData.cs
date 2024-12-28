using PenkiControlApp.Core.OutputModels;

namespace PenkiControlApp.UI.InternalTypes;

public class AllDatabaseData
{
    private static AllDatabaseData? _instance;
    private Dictionary<string, object> _data = new();
    private static int _loadedData = 0;

    public static AllDatabaseData GetInstance()
    {
        return _instance ??= new AllDatabaseData();
    }

    public object GetData(string key, string? where)
    {
        if (where is not null)
        {
            try
            {
                return (_data[where.ToLower()] as Dictionary<string, object>)![key.ToLower()];
            }
            catch (Exception e)
            {
                return false;
            }
        }
        else
        {
            try
            {
                foreach (var (s, value) in _data)
                {
                    foreach (var (k, o) in (value as Dictionary<string, object>)!)
                    {
                        if (k.Equals(key, StringComparison.CurrentCultureIgnoreCase))
                        {
                            return o;
                        }
                    }
                }

                return false;

            }
            catch (Exception e)
            {
                return false;
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
                    clientsDict[x.Id.ToString()] = x;
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