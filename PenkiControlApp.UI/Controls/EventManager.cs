namespace PenkiControlApp.UI.Controls;

public static class EventManager
{
    public static event Action<string> OnEventOccurred;

    public static void TriggerEvent(string name)
    {
        OnEventOccurred?.Invoke(name);
    }
}