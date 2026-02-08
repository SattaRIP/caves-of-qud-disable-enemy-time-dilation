using HarmonyLib;
using XRL.World;
using XRL.World.Parts.Mutation;

namespace LocalMods
{
    [HarmonyPatch]
    public static class DisableEnemyTemporalFugue
    {
        [HarmonyPatch(typeof(TemporalFugue))]
        [HarmonyPatch("FireEvent")]
        static bool Prefix(TemporalFugue __instance, ref bool __result, Event E)
        {
            if (E.ID == "CommandTemporalFugue")
            {
                // Allow player to use it
                if (__instance.ParentObject != null && __instance.ParentObject.IsPlayer())
                {
                    return true; // Continue to original
                }

                // Block NPCs
                __result = true;
                return false;
            }
            return true;
        }
    }
}
