using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using alchemistri.Content.Tiles;

namespace alchemistri.Content.Items
{
    public class AntimatterSynthesizer : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.value = 1000000;
            Item.maxStack = 9999;
            Item.rare = -12;
            Item.createTile = ModContent.TileType<AntimatterSynthesizerTile>();
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 10;
            Item.useTime = 10;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LunarBar, 50)
                  .AddIngredient(ItemID.ShroomiteBar, 100)
                  .AddIngredient(ItemID.LunarCraftingStation, 1)
                  .AddTile(TileID.LunarCraftingStation)
                  .Register();
        }
    }
}
