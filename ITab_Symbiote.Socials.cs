namespace Symbiotes;

public class ITab_Symbiote_Socials : ITab_Symbiote
{
    public ITab_Symbiote_Socials()
    {
        labelKey = "Symbiote Socials";
    }

    public override void FillTab()
    {
        SocialCardUtility.DrawSocialCard(new Rect(0f, 0f, size.x, size.y), Symbiote);
    }
}
