using PenkiControlApp.Core.OutputModels;
using PenkiControlApp.DAL;

namespace PenkiControlApp.BLL;

public class ClientManager
{
    private readonly ClientRepository _repository = new();

    public List<ClientForDisplayingOutputModel> GetAllClients()
    {
        List<ClientForDisplayingOutputModel> outputModels = [];
        var got = _repository.GetAllClients();
        got.ForEach(x => outputModels.Add(new ClientForDisplayingOutputModel{ Name = x.Name!, Id = x.Id, Surname = x.Surname! }));
        return outputModels;
    }

    public List<ClientForSearchOutputModel> GetAllClientsForSearch()
    {
        var got = _repository.GetAllClients();
        List<ClientForSearchOutputModel> outputModels = [];
        got.ForEach(x => outputModels.Add(new ClientForSearchOutputModel { Id = x.Id, Name = x.Name!, Surname = x.Surname!, Age = x.Age }));
        return outputModels;
    }
    public int GetClientIdByNameAndSurname(string name, string surname)
    {
        var got = _repository.GetClientIdByNameAndSurname(name, surname);
        //got.ForEach(x => outputModels.Add(new ClientForDisplayingOutputModel { Name = x.Name!, Id = x.Id, Surname = x.Surname! }));
        return got.Id;
    }
}