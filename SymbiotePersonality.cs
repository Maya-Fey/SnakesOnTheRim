namespace Symbiotes;

public partial class SymbiotePersonality
{
    public virtual float GetPainFactor() => 0.8f;
    public virtual float GetAgingFactor() => 0.5f;
    public virtual float GetBleedRate() => 0.8f;
    public virtual float GetMetabolismFactor() => 0.8f;
    public virtual float GetBloodFiltrationFactor() => 0.8f;
}
