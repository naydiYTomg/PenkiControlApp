using PenkiControlApp.Core.DTOs;
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
        got.ForEach(x => outputModels.Add(new ManagerForDisplayingOutputModel{Name = x.Name!, Id = x.Id, Surname = x.Surname! }));
        return outputModels;
    }

    public bool IsLoginExists(string login)
    {
        foreach (var userDto in _userRepository.GetAllUsers())
        {
            if (userDto.Login == login)
            {
                return true;
            }
        }

        return false;
    }

    public void AddNewUser(string name, string surname, string login, string password, bool isManager, bool isAdmin)
    {
        var user = new UserDTO
            { Login = login, Name = name, Surname = surname, Password = password, Manager = isManager, Administrator = isAdmin};
        _userRepository.InsertUser(user);
    }
}