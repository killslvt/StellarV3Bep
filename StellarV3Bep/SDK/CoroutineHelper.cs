using BepInEx.Unity.IL2CPP.Utils.Collections;
using Il2CppInterop.Runtime.Injection;
using StellarV3Bep.Modules;
using System.Collections;
using UnityEngine;
public static class CoroutineHelper
{
    private static CoroutineRunner _runner;

    public static void Init()
    {
        if (_runner != null) return;

        var go = new GameObject("Coroutine");
        UnityEngine.Object.DontDestroyOnLoad(go);
        ClassInjector.RegisterTypeInIl2Cpp<CoroutineRunner>();
        _runner = go.AddComponent<CoroutineRunner>();
    }

    public static Coroutine Start(IEnumerator routine)
    {
        if (_runner == null) Init();
        return _runner.Run(routine.WrapToIl2Cpp());
    }

    public static void Stop(Coroutine coroutine)
    {
        if (_runner != null && coroutine != null)
            _runner.StopCoroutine(coroutine);
    }
}

public class CoroutineRunner : BaseModule
{
    public Coroutine Run(Il2CppSystem.Collections.IEnumerator routine)
    {
        return StartCoroutine(routine);
    }
}
