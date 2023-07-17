namespace Symbiotes;

public class ITab_Symbiote_Needs : ITab_Symbiote
{
    public ITab_Symbiote_Needs()
    {
        labelKey = "Symbiote Needs";
    }

    public override void FillTab()
    {
        NeedsCardUtility.DoNeedsMoodAndThoughts(new Rect(0f, 0f, size.x, size.y), Symbiote, ref thoughtScrollPosition);
    }

    public override void UpdateSize() => size = NeedsCardUtility.GetSize(Symbiote);

    private Vector2 thoughtScrollPosition;
}