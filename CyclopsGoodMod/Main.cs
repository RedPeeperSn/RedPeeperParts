// Include this namespace to simplify the code below
using QModManager.API.ModLoading;
using HarmonyLib;
using SMLHelper.V2.Handlers;
using UnityEngine;
using System.Reflection;
using CustomBatteries.API;

namespace CyclopsShitMod
{
    // Your main patching class must have the QModCore attribute (and must be public)
    [QModCore]
    public static class Main
    {
        // Your patching method must have the QModPatch attribute (and must be public)
        [QModPatch]
        public static void Patch()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var modName = ($"Dream_{assembly.GetName().Name}");
            Harmony harmony = new Harmony(modName);
            harmony.PatchAll(assembly);

            var shitItem1 = new R_C_B_item();
            shitItem1.Patch();

            var shitItem2 = new R_H_B_item();
            shitItem2.Patch();

            var shitItem3 = new R_E_B_item();
            shitItem3.Patch();

            var RedPeeper_storage_concentrate = new RedPeeper_storage_concentrate();
            RedPeeper_storage_concentrate.Patch();

            var CbBattery = new CbBattery();
            CbBattery.Patch();

            var RedPeeper_plasma_lens = new RedPeeper_plasma_lens();
            RedPeeper_plasma_lens.Patch();

        }
        static Main()
        {
            QModManager.Utility.Logger.Log(QModManager.Utility.Logger.Level.Info, "Yo RedPeeper");
        }
    }
}