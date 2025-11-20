using ExitGames.Client.Photon;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRC;
using VRC.Core;

namespace StellarV3Bep.Modules
{
    public class BaseModule : MonoBehaviour
    {
        //Credit: Magma
        public virtual void Awake()
        {
            BaseModules.Modules.Add(this);
        }
        public virtual bool OnPhotonEvent(EventData data) { return true; }
        public virtual void OnPlayerJoin(Player Player) { }
        public virtual void OnPlayerLeave(Player Player) { }
        public virtual void OnPlayerAvatarChange(Player Player, ApiAvatar Avatar) { }
        public virtual void OnPlayerAvatarLoaded(Player Player, ApiAvatar Avatar) { }
        public virtual void PreQuickMenuInitialized() { }
        public virtual void OnQuickMenuInitialized() { }
        public virtual void PostQuickMenuInitialized() { }
        public virtual void QuickMenuOpened() { }
        public virtual void QuickMenuClosed() { }
        public virtual void OnMainMenuInitialized() { }
        public virtual void OnJump() { }
        public virtual void OnSceneLoad(Scene OldScene, Scene CurrentScene) { }
        public virtual void OnApplicationQuit() { }
    }

    public class BaseModules : MonoBehaviour
    {
        public static HashSet<BaseModule> Modules = new();
    }
}
