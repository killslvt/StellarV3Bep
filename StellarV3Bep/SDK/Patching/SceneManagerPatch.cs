using HarmonyLib;
using StellarV3Bep.Modules.Menus;
using UnityEngine.SceneManagement;

namespace StellarV3Bep.SDK.Patching
{
    [HarmonyPatch(typeof(SceneManager))]
    internal static class SceneManagerPatch
    {
        [HarmonyPatch("Internal_SceneLoaded")]
        [HarmonyPrefix]
        private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Logging.Log($"Scene Loaded: {scene.name}, {scene.buildIndex}", LType.Info);

            WorldHacksGUI.Initialize(scene.name);
        }
    }
}
