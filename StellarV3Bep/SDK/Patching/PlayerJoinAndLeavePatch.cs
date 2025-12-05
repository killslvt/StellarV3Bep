using HarmonyLib;
using System.Security.AccessControl;
using UnityEngine;
using VRC.SDKBase;

namespace StellarV3Bep.SDK.Patching
{
    [HarmonyPatch(typeof(NetworkManager))]
    internal class PlayerJoinAndLeavePatch
    {
        public static bool ownerSpoof = false;
        public static bool customSpoof = false;
        public static string customName = "StellarV3";
        public static VRC_Pickup[] _pickups;

        [HarmonyPatch("Method_Public_Void_Player_PDM_1")]
        [HarmonyPrefix]
        private static void OnPlayerJoin(VRC.Player __0)
        {
            Logging.Log($"Player joined: {__0.field_Private_APIUser_0.displayName}", LType.Join);

            if (__0.field_Private_VRCPlayerApi_0.isLocal)
            {
                if (ownerSpoof)
                {
                    customSpoof = false;
                    string ownerSpoof = RoomManager.field_Internal_Static_ApiWorld_0.authorName ?? "DisplayName";

                    __0.field_Private_VRCPlayerApi_0.displayName = ownerSpoof;
                    __0.field_Private_APIUser_0.displayName = ownerSpoof;
                }
                else if (customSpoof)
                {
                    ownerSpoof = false;
                    __0.field_Private_VRCPlayerApi_0.displayName = customName;
                    __0.field_Private_APIUser_0.displayName = customName;
                }

                _pickups = Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToArray();
            }
        }

        [HarmonyPatch("Method_Public_Void_Player_0")]
        [HarmonyPrefix]
        private static void OnPlayerLeave(VRC.Player __0)
        {
            Logging.Log($"Player left: {__0.field_Private_APIUser_0.displayName}", LType.Leave);
        }
    }
}
