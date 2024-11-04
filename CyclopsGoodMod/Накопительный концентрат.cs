using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

internal class RedPeeper_storage_concentrate: Craftable
{
    public override string AssetsFolder => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets");
    public static TechType thisTechType;

    public RedPeeper_storage_concentrate()
        : base("RedPeeper_storage_concentrate", "Накопительный концентрат", "Сложная комбинация органических веществ, способная задерживать, сохранять и передавать электрический ток. Применятся в производстве базовой электроники.")
    {
        OnFinishedPatching += () =>
        {
            thisTechType = TechType;
        };
    }
    public override GameObject GetGameObject()
    {
        var prefab = CraftData.GetPrefabForTechType(TechType.Polyaniline);
        //var path = "WorldEntities/Environment/Wrecks/cyclopsbridgefragment3";
        //var prefab = Resources.Load<GameObject>(path);
        //prefab.GetComponent<BoxCollider>().size *= 1f;
        var renderer = prefab.GetComponentInChildren<Renderer>();
        //renderer.transform.localScale *= 2;
        //CraftDataHandler.SetBackgroundType(thisTechType, CraftData.BackgroundType.ExosuitArm);
        var obj = GameObject.Instantiate(prefab);
        return obj;
    }

    public override bool HasSprite => true;
    public override TechCategory CategoryForPDA => TechCategory.Electronics;
    public override TechGroup GroupForPDA => TechGroup.Resources;
    public override CraftTree.Type FabricatorType => CraftTree.Type.Fabricator;
    public override string[] StepsToFabricatorTab => new string[] { "Resources", "Electronics" };
    public override float CraftingTime => 3f;
    public override Vector2int SizeInInventory => new Vector2int(1, 2);
    protected override Atlas.Sprite GetItemSprite()
    {
        return ImageUtils.LoadSpriteFromFile(Path.Combine(AssetsFolder, "StorageConcentrate.png"));
    }

    protected override TechData GetBlueprintRecipe()
    {
        return new TechData
        {
            craftAmount = 1,
            Ingredients = new List<Ingredient>
            {
                new Ingredient(TechType.PurpleBrainCoral, 2),
                new Ingredient(TechType.CopperWire, 1),
                new Ingredient(TechType.AcidMushroom, 4)
            }
        };
    }
}