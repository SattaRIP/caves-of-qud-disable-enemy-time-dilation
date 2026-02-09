using HarmonyLib;
using XRL.World;
using XRL.World.Parts.Mutation;

namespace LocalMods
{
    [HarmonyPatch]
    public static class DisableEnemyTimeDilation
    {
        [HarmonyPatch(typeof(TimeDilation))]
        [HarmonyPatch("FireEvent")]
        static bool Prefix(TimeDilation __instance, ref bool __result, Event E)
        {
            if (E.ID == "CommandTimeDilation")
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
