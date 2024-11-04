using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

internal class RedPeeper_plasma_lens : Craftable
{
    public override string AssetsFolder => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets");
    public static TechType thisTechType;

    public RedPeeper_plasma_lens()
        : base("RedPeeper_plasma_lens", "Плазменная линза", "Комбинация  твёрдых, хрупких и прозрачных соединений, способная преломлять ионы поступающей электроэнергии в лазеры.")
    {
        OnFinishedPatching += () =>
        {
            thisTechType = TechType;
        };
    }
    public override GameObject GetGameObject()
    {
        var prefab = CraftData.GetPrefabForTechType(TechType.Aerogel);
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
    public override float CraftingTime => 8f;
    public override Vector2int SizeInInventory => new Vector2int(2, 2);
    protected override Atlas.Sprite GetItemSprite()
    {
        return ImageUtils.LoadSpriteFromFile(Path.Combine(AssetsFolder, "PlasmaLens.png"));
    }

    protected override TechData GetBlueprintRecipe()
    {
        return new TechData
        {
            craftAmount = 1,
            Ingredients = new List<Ingredient>
            {
                new Ingredient(TechType.Diamond, 2),
                new Ingredient(TechType.BluePalmSeed, 2),
                new Ingredient(TechType.Lead, 3)
            }
        };
    }
}
