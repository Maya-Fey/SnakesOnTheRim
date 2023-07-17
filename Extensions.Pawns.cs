namespace Symbiotes;
partial class Extensions
{
    public static Pawn GenerateSymbiotePawn(PawnGenerationRequest? request = null)
    {
        var finalRequest = request ?? new PawnGenerationRequest(Defs.SymbiotePawnKind);

        finalRequest.AllowPregnant = false;
        finalRequest.AllowFood = false;
        finalRequest.AllowedDevelopmentalStages = DevelopmentalStage.Adult;

        return PawnGenerator.GeneratePawn(finalRequest);
    }

    internal static SymbioteHediff GetHediff(this Pawn pawn) =>
        pawn?.health?.hediffSet?.GetFirstHediff<SymbioteHediff>();

    internal static SymbioteComponent GetComponent(this Pawn pawn) =>
        pawn?.GetComp<SymbioteComponent>();

    public static bool CanAccquireHediffs(this Pawn pawn) => pawn is { health.hediffSet: not null };

    internal static bool IsHost(this Pawn pawn, out SymbioteHediff hediff) =>
        (hediff = pawn.GetHediff()) is not null;

    internal static bool IsHost(this Pawn pawn) => pawn.IsHost(out _);

    internal static bool IsSymbiote(this Pawn pawn, out SymbioteComponent component) =>
        (component = pawn.GetComponent()) is not null;

    internal static bool IsSymbiote(this Pawn pawn) => pawn.IsSymbiote(out _);

    internal static bool IsHostOrSymbiote(this Pawn pawn) =>
        pawn.IsHost() || pawn.IsSymbiote();

    internal static bool IsHostOrSymbiote(this Pawn pawn, out SymbioteComponent component)
    {
        if (pawn.IsHost(out var hediff))
            component = hediff.Symbiote.GetComponent();
        else if (pawn.IsSymbiote(out component)) { }
        else return false;

        return true;
    }

    internal static bool TryGetSymbiotePersonality(this Pawn pawn, out SymbiotePersonality personality)
    {
        var result = pawn.IsHostOrSymbiote(out var component);

        personality = component?.Personality;

        return result;
    }
}
