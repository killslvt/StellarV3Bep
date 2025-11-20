using HarmonyLib;
using System.Reflection;

namespace StellarV3Bep.SDK.Patching
{
    internal static class VRCPlusPatch
    {
        //Credit: catnotadog https://discord.gg/fXVn2JJyuA
        public static void Apply(Harmony harmony)
        {
            PropertyInfo prop = typeof(VRCPlusStatus).GetProperty("prop_Object1PublicIDisposableObAc1BoObObUnique_1_Boolean_0", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            MethodInfo getter = prop.GetGetMethod(true);

            harmony.Patch(getter, postfix: new HarmonyMethod(typeof(VRCPlusPatch), nameof(VRCSpoof)));

            Logging.Log("VRC Plus spoof patch applied.", LType.Info);
        }

        private static void VRCSpoof(ref Object1PublicIDisposableObAc1BoObObUnique<bool> __result)
        {
            if (__result != null)
                __result.field_Protected_T_0 = true;
        }
    }
}
