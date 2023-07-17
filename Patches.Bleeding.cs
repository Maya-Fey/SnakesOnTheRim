namespace Symbiotes;

public static partial class Patches
{
    public static class Bleeding
    {
        [HarmonyPatch(typeof(HediffSet), nameof(CalculateBleedRate))]
        [HarmonyPostfix]
        public static void CalculateBleedRate(HediffSet __instance, ref float __result)
        {
            if (!__instance.pawn.TryGetSymbiotePersonality(out var personality))
                return;

            __result *= personality.GetBleedRate();
        }
    }
}