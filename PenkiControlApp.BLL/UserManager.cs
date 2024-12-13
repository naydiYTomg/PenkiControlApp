using PenkiControlApp.Core.OutputModels;
using PenkiControlApp.DAL;

namespace PenkiControlApp.BLL;

public class UserManager
{
    private readonly UserRepository _userRepository = new();

    public List<ManagerForDisplayingOutputModel> GetAllManagers()
    {
        List<ManagerForDisplayingOutputModel> outputModels = [];
        var got = _userRepository.GetManagers();
        got.ForEach(x => outputModels.Add(new ManagerForDisplayingOutputModel{Name = x.Name!, Id = x.Id }));
        return outputModels;
    }
}