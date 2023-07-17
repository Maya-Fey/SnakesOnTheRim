namespace Symbiotes;

public class ITab_Symbiote_Bio : ITab_Symbiote
{
    public ITab_Symbiote_Bio()
    {
        labelKey = "Symbiote Bio";
    }

    public override void UpdateSize()
    {
        base.UpdateSize();
        size = CharacterCardUtility.PawnCardSize(Symbiote) + new Vector2(17f, 17f) * 2f;
    }

    public override void FillTab()
    {
        UpdateSize();
        CharacterCardUtility.DrawCharacterCard(new Rect(17f, 17f, size.x, size.y), Symbiote);
    }
}
