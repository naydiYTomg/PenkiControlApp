namespace PenkiControlApp.Logging;

public class PCALogger
{
    private static PCALogger? _instance;
    private readonly StreamWriter _current;
    public static PCALogger GetInstance()
    {
        return _instance ??= new PCALogger();
    }
    public static PCALogger GetInstance(string filename)
    {
        return _instance ??= new PCALogger(filename);
    }

    private PCALogger()
    {
        var date = DateTime.Now;
        Directory.CreateDirectory("./Log");
        _current = new StreamWriter(File.Create($"./Log/LOG{date.Minute}{date.Hour}{date.Day}{date.Month}{date.Year}.log"));
    }
    private PCALogger(string filename)
    {
        Directory.CreateDirectory("./Log");
        _current = new StreamWriter(File.Create($"./Log/{filename}.log"));
    }

    public void LogWarning(string message)
    {
        try
        { 
            _current.WriteLine($"{DateTime.Now}|WARNING::|{message}");
            _current.Flush();
        }
        catch (Exception e)
        {
            throw; //TODO: handle exception
        }
    }

    public void LogError(string message, bool isDrop)
    {
        try
        {
            _current.WriteLine($"{DateTime.Now}|ERROR::|{message}");
            _current.Flush();
            if (isDrop)
            {
                _current.Dispose();
                _current.Close();
                Environment.Exit(0);
            }
        }
        catch (Exception e)
        {
            throw; //TODO: Handle exception
        }
    }

    public void LogMessage(string message)
    {
        try
        {
            _current.WriteLine($"{DateTime.Now}|LOG::|{message}");
            _current.Flush();
        }
        catch (Exception e)
        {
            throw; //TODO: Handle exception
        }
    }

    public void OnExit()
    {
        _current.WriteLine($"{DateTime.Now}|LOG::|Exiting...");
        _current.Flush();
        _current.Dispose();
        _current.Close();
    }
}