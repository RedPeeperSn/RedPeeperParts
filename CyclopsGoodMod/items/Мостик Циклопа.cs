using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

internal class R_C_B_item : Craftable
{
    public override string AssetsFolder => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets");
    public static TechType thisTechType;

    public R_C_B_item()
        : base("redpeeper_cyclops_bridge", "Мостик Циклопа", "Центральная рубка Циклопа. Позволяет отдавать команды о запуске двигателя, передвижении, активировать функционал модификаций, режим просмотра внешних камер и редактирования окраски.")
    {
        OnFinishedPatching += () =>
        {
            thisTechType = TechType;
        };
    }

    public override GameObject GetGameObject()
    {
        var prefab = CraftData.GetPrefabForTechType(TechType.Magnesium);
        //var path = "WorldEntities/Environment/Wrecks/cyclopsbridgefragment3";
        //var prefab = Resources.Load<GameObject>(path);
        //prefab.GetComponent<BoxCollider>().size *= 1f;
        var renderer = prefab.GetComponentInChildren<Renderer>();
        //renderer.transform.localScale *= 2;
        CraftDataHandler.SetBackgroundType(thisTechType, CraftData.BackgroundType.ExosuitArm);
        var obj = GameObject.Instantiate(prefab);
        return obj;
    }

    public override bool HasSprite => true;
    public override TechCategory CategoryForPDA => TechCategory.Cyclops;
    public override TechGroup GroupForPDA => TechGroup.Cyclops;
    public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
    public override string[] StepsToFabricatorTab => new string[] { "CyclopsMenu" };
    public override float CraftingTime => 30f;
    public override Vector2int SizeInInventory => new Vector2int(3, 4);
    protected override Atlas.Sprite GetItemSprite()
    {
        return ImageUtils.LoadSpriteFromFile(Path.Combine(AssetsFolder, "CyclopsBridge.png"));
    }

    protected override TechData GetBlueprintRecipe()
    {
        return new TechData
        {
            craftAmount = 1,
            Ingredients = new List<Ingredient>
            {
                new Ingredient(TechType.TitaniumIngot, 2),
                new Ingredient(TechType.AdvancedWiringKit, 2),
                new Ingredient(TechType.MapRoomHUDChip, 1),
                new Ingredient(TechType.Silicone, 5),
                new Ingredient(TechType.FireExtinguisher, 2)
            }
        };
    }
}
