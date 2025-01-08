using System.Security.Cryptography;
using System.Text;
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

    public int AddNewUser(string name, string surname, string login, string password, bool isManager, bool isAdmin)
    {
        string hashedPassword = Encoding.UTF8.GetString(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
        var user = new UserDTO
        { Login = login, Name = name, Surname = surname, Password = hashedPassword, Manager = isManager, Administrator = isAdmin };
        return _userRepository.InsertUser(user);
    }

    public UserForLoginOutputModel GetUserByLogin(string login)
    {
        var got = _userRepository.GetUserByLogin(login);
        return new UserForLoginOutputModel{ Name = got.Name!, Surname = got.Surname!, Id = got.Id, Login = got.Login! };
    }
    public UserForLoginOutputModel GetManagerByLogin(string login)
    {
        var got = _userRepository.GetManagerByLogin(login);
        return new UserForLoginOutputModel{ Name = got.Name!, Surname = got.Surname!, Id = got.Id, Login = got.Login! };
    }
    public UserForLoginOutputModel GetAdministratorByLogin(string login)
    {
        var got = _userRepository.GetAdministratorByLogin(login);
        return new UserForLoginOutputModel{ Name = got.Name!, Surname = got.Surname!, Id = got.Id, Login = got.Login! };
    }

    public bool TryLoginUser(string login, string password)
    {
        try
        {
            var gotPassword = _userRepository.GetUserPasswordByLogin(login);
            return Encoding.UTF8.GetString(SHA256.HashData(Encoding.UTF8.GetBytes(password))) == gotPassword;
        }
        catch (Exception e)
        {
            return false;
        }
        
    }
    public bool TryLoginAdmin(string login, string password)
    {
        try
        {
            var gotPassword = _userRepository.GetAdministratorPasswordByLogin(login);
            return Encoding.UTF8.GetString(SHA256.HashData(Encoding.UTF8.GetBytes(password))) == gotPassword;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    public bool TryLoginManager(string login, string password)
    {
        try
        {
            var gotPassword = _userRepository.GetManagerPasswordByLogin(login);
            return Encoding.UTF8.GetString(SHA256.HashData(Encoding.UTF8.GetBytes(password))) == gotPassword;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
}