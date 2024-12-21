using System.Reflection.Emit;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace PenkiControlApp.BLL.SessionStoring;

public static class Storer
{
    public static void Store(Session session)
    {
        FileStream stream = new FileStream("current.session", FileMode.OpenOrCreate);
        List<byte> encryptedName = [];
        List<byte> encryptedSurname = [];
        List<byte> encryptedLogin = [];
        List<byte> encryptedPassword = [];
        encryptedName.AddRange(session.Name.ToCharArray().Select(c => (byte)((byte)c ^ 12)));
        encryptedSurname.AddRange(session.Name.ToCharArray().Select(c => (byte)((byte)c ^ 52)));
        encryptedLogin.AddRange(session.Name.ToCharArray().Select(c => (byte)((byte)c ^ 9)));
        encryptedPassword.AddRange(session.Password.ToCharArray().Select(c => (byte)((byte)c ^ 23)));
        // encryptedName.ForEach(x => Console.Write($"{(char)x} "));
        // Console.WriteLine($"\n{session.Name}");
        stream.Write(Encoding.Default.GetBytes(session.Name.Length.ToString("D2")));
        stream.Write(Encoding.Default.GetBytes(session.Surname.Length.ToString("D2")));
        stream.Write(Encoding.Default.GetBytes(session.Login.Length.ToString("D2")));
        stream.Write(Encoding.Default.GetBytes(session.Password.Length.ToString("D2")));
        stream.Write(encryptedName.ToArray());
        stream.Write(encryptedSurname.ToArray());
        stream.Write(encryptedLogin.ToArray());
        stream.Write(encryptedPassword.ToArray());
        stream.Flush();
        stream.Close();
    }

    public static Session? Read()
    {
        if (!File.Exists("current.session")) return null;
        
        FileStream stream = new FileStream("current.session", FileMode.Open);
        StringBuilder sb = new StringBuilder();
        byte[] size1 = new byte[2];
        byte[] size2 = new byte[2];
        byte[] size3 = new byte[2];
        byte[] size4 = new byte[2];
        stream.Read(size1, 0, 2);
        stream.Read(size2, 0, 2);
        stream.Read(size3, 0, 2);
        stream.Read(size4, 0, 2);
        byte[] name = new byte[int.Parse($"{char.GetNumericValue((char)size1[0])}{char.GetNumericValue((char)size1[1])}")];
        byte[] surname = new byte[int.Parse($"{char.GetNumericValue((char)size2[0])}{char.GetNumericValue((char)size2[1])}")];
        byte[] login = new byte[int.Parse($"{char.GetNumericValue((char)size3[0])}{char.GetNumericValue((char)size3[1])}")];
        byte[] password =
            new byte[int.Parse($"{char.GetNumericValue((char)size4[0])}{char.GetNumericValue((char)size4[1])}")];
        stream.Read(name, 0,
            int.Parse($"{char.GetNumericValue((char)size1[0])}{char.GetNumericValue((char)size1[1])}"));
        stream.Read(surname, 0,
            int.Parse($"{char.GetNumericValue((char)size2[0])}{char.GetNumericValue((char)size2[1])}"));
        stream.Read(login, 0,
            int.Parse($"{char.GetNumericValue((char)size3[0])}{char.GetNumericValue((char)size3[1])}"));
        stream.Read(password, 0,
            int.Parse($"{char.GetNumericValue((char)size4[0])}{char.GetNumericValue((char)size4[1])}"));
        string outName;
        string outSurname;
        string outLogin;
        string outPassword;
        sb.Clear();
        foreach (var b in name)
        {
            sb.Append((char)(b ^ 12));
        }

        outName = sb.ToString();
        sb.Clear();
        foreach (var b in surname)
        {
            sb.Append((char)(b ^ 52));
        }

        outSurname = sb.ToString();
        sb.Clear();
        foreach (var b in login)
        {
            sb.Append((char)(b ^ 9));
        }

        outLogin = sb.ToString();
        sb.Clear();
        foreach (var b in password)
        {
            sb.Append((char)(b ^ 23));
        }

        outPassword = sb.ToString();
        sb.Clear();
        
        return new Session() { Name = outName, Surname = outSurname, Login = outLogin, Password = outPassword};
    }
}