namespace Symbiotes;

public sealed class Mod : Verse.Mod
{
    public static Mod Instance { get; private set; }
    public readonly Harmony Harmony = new(nameof(Symbiotes));
    public Mod(ModContentPack content) : base(content)
    {
        Instance = this;
    }

    [DebugAction("Pawns", name = "Add symbiote", actionType = DebugActionType.ToolMapForPawns, allowedGameStates = AllowedGameStates.PlayingOnMap)]
    public static void AddHediff(Pawn pawn)
    {
        var symbiote = GenerateSymbiotePawn();
        var component = symbiote.GetComponent();

        component.SetHost(pawn);
    }

    public void OnStartup()
    {
        DebugMessage("Loading.", color: Color.magenta);
        try
        {
            DebugMessage("Patching.");

            Harmony.PatchAll();

            DebugMessage("Loaded successfully.");
        }
        catch (Exception ex)
        {
            DebugMessage("Failed to load.", Log.Error);

            Harmony.UnpatchAll(Harmony.Id);

            DebugMessage(ex, Log.Error);
        }
    }
}