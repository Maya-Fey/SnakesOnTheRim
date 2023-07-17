namespace Symbiotes;

public class SymbioteComponent : ThingComp 
{
    public CompProperties_Symbiote Properties => props as CompProperties_Symbiote;

    public Pawn Parent => parent as Pawn;
    public Pawn Symbiote => Parent;

    internal Pawn host;
    public Pawn Host => host;

    internal SymbiotePersonality personality;
    public SymbiotePersonality Personality => personality;

    private void SetPersonality()
    {
        personality = Rand.Value > Properties.FriendlyChance ?
            new SymbiotePersonality.Tokra() :
            new SymbiotePersonality.Goauld();
    }

    public override void Initialize(CompProperties props)
    {
        base.Initialize(props);

        SetPersonality();
    }

    internal bool SetHost(Pawn host)
    {
        if (!host.CanAccquireHediffs())
            return false;

        var hediff = host.GetHediff();
        if (hediff is null)
        {
            hediff = HediffMaker.MakeHediff(Defs.SymbioteHediff, host, null) as SymbioteHediff;

            host.health.AddHediff(hediff);
        }

        this.host = host;

        hediff.SetSymbiote(Symbiote);

        return true;
    }

    public override void PostExposeData()
    {
        base.PostExposeData();

        Scribe_References.Look(ref host, nameof(Host), true);
        Scribe_Deep.Look(ref personality, nameof(Personality));
    }
}