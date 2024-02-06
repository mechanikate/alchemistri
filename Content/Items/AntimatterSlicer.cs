using alchemistri.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace alchemistri.Content.Items
{
    public class AntimatterSlicer : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.alchemistri.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 8192;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 1;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 20;
            Item.value = 5000000;
            Item.rare = -12;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.scale = 2f;
        }

        public override void AddRecipes()  // 5 antihydrogen required @ ancient manipiulator
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<AntiHydrogen>(5)
                  .AddTile(ModContent.TileType<AntimatterSynthesizerTile>())
                  .Register();
        }
    }
}