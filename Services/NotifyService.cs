namespace BelinAI.Services;
public class NotifyService
{
    public event Action<string>? ReloadNeeded;

    public void RaiseReloadNeeded(string message)
    {
        ReloadNeeded?.Invoke(message);
    }
}
