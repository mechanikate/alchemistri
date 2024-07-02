using alchemistri.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace alchemistri.Content.Items
{
    public class AntiHydrogen : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.alchemistri.hjson file.

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.value = 10000000;
            Item.maxStack = 9999;
            Item.rare = -12;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LunarBar, 50)
                  .AddIngredient(ItemID.LunarCraftingStation, 1)
                  .AddTile(ModContent.TileType<AntimatterSynthesizerTile>())
                  .Register();
        }
    }
}