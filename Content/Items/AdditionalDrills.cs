using alchemistri.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace alchemistri.Content.Items
{
    public class AdditionalDrills : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.alchemistri.hjson file.

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.value = 10000000;
            Item.maxStack = 9999;
            Item.rare = -12;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<AntiHydrogen>(3)
                  .AddIngredient(3460,5)
                  .AddIngredient(947, 5)
                  .AddIngredient(366, 5)
                  .AddIngredient(365, 5)
                  .AddIngredient(364, 5)
                  .AddIngredient(14, 5)
                  .AddIngredient(13, 5)
                  .AddIngredient(12, 5)
                  .AddIngredient(11, 5)
                  .AddTile(ModContent.TileType<AntimatterSynthesizerTile>())
                  .Register();
        }
    }
}