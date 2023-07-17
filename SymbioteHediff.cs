namespace Symbiotes;

public class SymbioteHediff : HediffWithComps
{
    internal Pawn symbiote;
    public Pawn Symbiote => symbiote;

    internal void SetSymbiote(Pawn symbiote)
    {
        this.symbiote = symbiote;
    }

    public override void ExposeData()
    {
        base.ExposeData();

        Scribe_References.Look(ref symbiote, nameof(Symbiote), true);
    }
}