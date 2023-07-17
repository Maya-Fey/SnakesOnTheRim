namespace Symbiotes;

partial class Extensions
{
    public const string LogPrefix = $"[{nameof(Symbiotes)}] ";
    public static void DebugMessage(object message, Action<string> logAction = null, Color? color = null)
    {
        logAction ??= Log.Message;

        var text = LogPrefix + message;
        if (color.HasValue)
            text = $"<color=#{ColorUtility.ToHtmlStringRGBA(color.Value)}>{text}</color>";

        logAction.Invoke(text);
    }
}
