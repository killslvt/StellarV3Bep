using UnityEngine;
using VRC.SDKBase;

namespace StellarV3Bep.Modules.Movement
{
    internal class ClickTP : BaseModule
    {
        public void Update()
        {
            if (Input.GetKeyInt(KeyCode.LeftControl) && Input.GetKeyDownInt(KeyCode.Mouse0))
            {
                ClickTeleport();
            }
        }

        private static void ClickTeleport()
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit))
            {
                Networking.LocalPlayer.gameObject.transform.position = hit.point;
            }
        }
    }
}
