namespace Symbiotes;

public abstract class ITab_Symbiote : ITab
{
    public override bool IsVisible => Hediff is not null;
    public SymbioteHediff Hediff => Host.health?.hediffSet.GetFirstHediffOfDef(Defs.SymbioteHediff) as SymbioteHediff;
    public Pawn Host => SelPawn;
    public Pawn Symbiote => Hediff.Symbiote;

    public ITab_Symbiote()
    {
        size = new Vector2(Width, Height);
        labelKey = "TabSymbiote";
    }

    public const float Width = 540f, Height = 510f;
}
