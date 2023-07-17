namespace Symbiotes;

public static partial class Patches
{
    public static class Pain
    {
        [HarmonyPatch(typeof(HediffSet), nameof(CalculatePain))]
        [HarmonyPostfix]
        public static void CalculatePain(HediffSet __instance, ref float __result)
        {
            if (!__instance.pawn.TryGetSymbiotePersonality(out var personality))
                return;

            __result *= personality.GetPainFactor();
        }
    }
}