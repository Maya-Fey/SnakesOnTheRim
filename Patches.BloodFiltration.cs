namespace Symbiotes;

public static partial class Patches
{
    public static class BloodFiltration
    {
        [HarmonyPatch(typeof(PawnCapacityWorker_BloodFiltration), nameof(CalculateCapacityLevel))]
        [HarmonyPostfix]
        public static void CalculateCapacityLevel(HediffSet diffSet, ref float __result)
        {
            if (!diffSet.pawn.TryGetSymbiotePersonality(out var personality))
                return;

            __result *= personality.GetBloodFiltrationFactor();
        }
    }
}