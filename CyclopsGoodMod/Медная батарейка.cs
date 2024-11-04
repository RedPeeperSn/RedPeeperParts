namespace CustomBatteries.Packs
{
    using System.Collections.Generic;
    using CustomBatteries.API;
    using QModManager.API.ModLoading;
    using SMLHelper.V2.Crafting;

    [QModCore]
    public static class ExampleCbItemMod
    {
        [QModPatch]
        public static void MainPatch()
        {
            var myBattery = new CbBattery
            {
                EnergyCapacity = 200,
                ID = "redpeeper_copper_battery",
                Name = "Медная батарея",
                FlavorText = "Базовая батарея, созданная из подручных материалов. Крайне быстро расходует накопленную энергию, но быстро заряжается.",
                UnlocksWith = TechType.Copper,
                CraftingMaterials = new List<TechType>
                {
                   TechType.CopperWire
                }
            };
        }
    }
}

