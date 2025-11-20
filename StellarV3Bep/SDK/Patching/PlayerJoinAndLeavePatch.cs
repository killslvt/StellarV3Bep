using HarmonyLib;

namespace StellarV3Bep.SDK.Patching
{
    [HarmonyPatch(typeof(NetworkManager))]
    internal class PlayerJoinAndLeavePatch
    {
        [HarmonyPatch("Method_Public_Void_Player_PDM_1")]
        [HarmonyPrefix]
        private static void OnPlayerJoin(VRC.Player __0)
        {
            Logging.Log($"Player joined: {__0.field_Private_APIUser_0.displayName}", LType.Join);
        }

        [HarmonyPatch("Method_Public_Void_Player_0")]
        [HarmonyPrefix]
        private static void OnPlayerLeave(VRC.Player __0)
        {
            Logging.Log($"Player left: {__0.field_Private_APIUser_0.displayName}", LType.Leave);
        }
    }
}
