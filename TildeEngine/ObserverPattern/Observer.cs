namespace TildeEngine.ObserverPattern;

public static class Observer
{
    public static Queue<(Enum, object?)> LogBuffer { get; } = new();

    public delegate void ObserverEventHandler(Enum e, object? o);
    public static event ObserverEventHandler? Event;

    public static void Invoke<TEnum, TParameter>(TEnum e, TParameter param) where TEnum : Enum
    {
        Event?.Invoke(e, param);
        LogBuffer.Enqueue((e, param));
    }

    public static ObserverHook Hook<TEnum, TParameter>(TEnum e, Action<TParameter> action) where TEnum : Enum
    {
        void Action(Enum code, object? o)
        {
            if (!code.Equals(e))
                return;

            if (o?.GetType() != typeof(TParameter)) 
                throw new InvalidCastException($"The hook parameter for {e} is not valid ({code})");

            action.Invoke((TParameter)o);
        }

        Event += Action;

        return new ObserverHook(Action);
    }
}