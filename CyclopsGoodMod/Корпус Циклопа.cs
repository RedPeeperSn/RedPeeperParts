using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

internal class R_H_B_item : Craftable
{
    public override string AssetsFolder => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets");
    public static TechType thisTechType;

    public R_H_B_item()
        : base("redpeeper_cyclops_hull", "Корпус Циклопа", "Проводящая электричество обшивка, позволяющая Циклопу подниматься и опускаться. Из-за особенности конструкции может легко повредится. Может менять окрас при соответствующей команде с мостика.")
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
    public override float CraftingTime => 40f;
    public override Vector2int SizeInInventory => new Vector2int(6, 4);
    protected override Atlas.Sprite GetItemSprite()
    {
        return ImageUtils.LoadSpriteFromFile(Path.Combine(AssetsFolder, "CyclopsHull.png"));
    }

    protected override TechData GetBlueprintRecipe()
    {
        return new TechData
        {
            craftAmount = 1,
            Ingredients = new List<Ingredient>
            {
                new Ingredient(TechType.PlasteelIngot, 4),
                new Ingredient(TechType.AdvancedWiringKit, 1),
                new Ingredient(TechType.Aerogel, 2),
                new Ingredient(TechType.CopperWire, 4),
                new Ingredient(TechType.EnameledGlass, 4)
            }
        };
    }
}

