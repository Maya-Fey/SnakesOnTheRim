namespace Symbiotes;

public static partial class Patches
{
    public static class Aging
    {
        [HarmonyPatch(typeof(Pawn_AgeTracker), nameof(get_AdultAgingMultiplier))]
        [HarmonyPostfix]
        public static void get_AdultAgingMultiplier(Pawn pawn, ref float __result)
        {
            if (!pawn.TryGetSymbiotePersonality(out var personality))
                return;

            __result *= personality.GetAgingFactor();
        }
    }
}