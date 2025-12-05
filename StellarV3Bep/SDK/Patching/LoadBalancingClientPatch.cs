using HarmonyLib;
using Photon.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StellarV3Bep.SDK.Patching
{
    [HarmonyPatch(typeof(LoadBalancingClient))]
    internal class LoadBalancingClientPatch
    {
        public static bool antiUdon = false;

        [HarmonyPatch("OnEvent")]
        [HarmonyPrefix]
        private static bool OnEventPatch(EventData __0)
        {
            var data = __0.CustomData;

            switch (__0.Code)
            {
                case 11: //Prob not needed 
                case 18:
                    return !antiUdon;
                default:
                    return true;
            }
        }
    }
}
