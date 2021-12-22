namespace TildeEngine.ObserverPattern;

public class ObserverHook
{
    private Observer.ObserverEventHandler Action { get; }

    internal ObserverHook(Observer.ObserverEventHandler action)
    {
        Action = action;
    }

    public void Unhook()
    {
        Observer.Event -= Action;
    }
}