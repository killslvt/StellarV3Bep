using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Injection;
using StellarV3Bep.Modules;
using StellarV3Bep.SDK;
using StellarV3Bep.SDK.Patching;
using System.Reflection;
using UnityEngine;

namespace StellarV3Bep
{
    [BepInPlugin("com.v.stellarv3", "StellarV3External", "1.0.6")]
    public class Main : BasePlugin
    {
        public static new ManualLogSource Log;
        public static Harmony _instance { get; } = new Harmony("StellarV3External");

        public static string folderPath = $"{Environment.CurrentDirectory}/StellarV3";

        public static string logFolderPath = $"{Environment.CurrentDirectory}/StellarV3/WorldLogs";

        public override void Load()
        {
            Log = new ManualLogSource("StellarV3");
            BepInEx.Logging.Logger.Sources.Add(Log);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            if (!Directory.Exists(logFolderPath))
                Directory.CreateDirectory(logFolderPath);

            Logging.Log("Registering Modules", LType.Info);

            var modules = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(BaseModule)))
                .ToList();

            foreach (var type in modules)
                ClassInjector.RegisterTypeInIl2Cpp(type);

            var mainObject = new GameObject("StellarV3Main");
            UnityEngine.Object.DontDestroyOnLoad(mainObject);
            mainObject.hideFlags |= HideFlags.HideAndDontSave;

            foreach (var type in modules)
                mainObject.AddComponent(Il2CppType.From(type));

            VRCPlusPatch.Apply(_instance);
            _instance.PatchAll();
        }
    }
}
