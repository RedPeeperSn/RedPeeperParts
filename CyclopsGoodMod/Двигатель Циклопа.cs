using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using SMLHelper.V2.Utility;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

// Перед : твоё название предмета для Main.cs
internal class R_E_B_item : Craftable
{
    public override string AssetsFolder => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Assets");
    public static TechType thisTechType;

    //Первое значение в кавычках - игровой айдишник, Второе - Игровое название, Третее - Игровое описание
    public R_E_B_item()
        : base("redpeeper_cyclops_engie", "Двигатель Циклопа", "Высокотехнологичный и громоздкий двигатель, способный вырабатывать огромную механическую тягу, позволяя Циклопу передвигаться. Имеет встроенную консоль модификации. Склонен к перегреву при слишком высокой нагрузке.")
    {
        OnFinishedPatching += () =>
        {
            thisTechType = TechType;
        };
    }
    public override GameObject GetGameObject()
    {
        //В скобках айдишник существующего в игре предмета который будет использовать игра для модельки
        var prefab = CraftData.GetPrefabForTechType(TechType.Magnesium);
        //Снизу в комментариях неработающие строки, их пока не включай
        //var path = "WorldEntities/Environment/Wrecks/cyclopsbridgefragment3";
        //var prefab = Resources.Load<GameObject>(path);
        //prefab.GetComponent<BoxCollider>().size *= 1f;
        var renderer = prefab.GetComponentInChildren<Renderer>();
        //renderer.transform.localScale *= 2;
        //Предмет, фон которого будет использовать игра для твоего предмета в инвентаре
        CraftDataHandler.SetBackgroundType(thisTechType, CraftData.BackgroundType.ExosuitArm);
        var obj = GameObject.Instantiate(prefab);
        return obj;
    }

    // Здесь параметры пути крафта и его отображения во вкладке крафтов КПК
    public override bool HasSprite => true;
    public override TechCategory CategoryForPDA => TechCategory.Cyclops;
    public override TechGroup GroupForPDA => TechGroup.Cyclops;
    public override CraftTree.Type FabricatorType => CraftTree.Type.Workbench;
    public override string[] StepsToFabricatorTab => new string[] { "CyclopsMenu" };
    //Время создания предмета в секундах
    public override float CraftingTime => 60f;
    //Размер предмета в инвентаре. Первое значение - по горизонтали, второе по вертикали
    public override Vector2int SizeInInventory => new Vector2int(3, 4);
    protected override Atlas.Sprite GetItemSprite()
        //Название картинки которое игра будет использовать для предмета. Должно лежать в папке Assets, там где находится мод
    {
        return ImageUtils.LoadSpriteFromFile(Path.Combine(AssetsFolder, "CyclopsEngie.png"));
    }

    // Крафт предмета
    protected override TechData GetBlueprintRecipe()
    {
        return new TechData
        {
            craftAmount = 1,
            Ingredients = new List<Ingredient>
            {
                new Ingredient(TechType.TitaniumIngot, 3),
                new Ingredient(TechType.Lubricant, 8),
                new Ingredient(TechType.ComputerChip, 3),
                new Ingredient(TechType.Silicone, 2),
                new Ingredient(TechType.PowerCell, 6)
            }
        };
    }
}