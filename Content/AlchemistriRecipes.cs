using alchemistri.Content.Items;
using alchemistri.Content.Tiles;
using static alchemistri.Config.AlchemistriConfig;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace alchemistri.Content
{
    public class AlchemistriRecipes : ModSystem
    {

        public override void AddRecipes()
        {
            if (Instance.EnableAncientManipulatorRecipe)
            {
                Recipe ancientManipulatorRecipe = Recipe.Create(ItemID.LunarCraftingStation, 2)
                                                        .AddIngredient(ItemID.LunarBar, 10)
                                                        .AddIngredient(ItemID.SpectreBar, 20)
                                                        .AddTile(TileID.LunarCraftingStation)
                                                        .Register();
            }
            if (Instance.EnableLuminiteRecipe)
            {
                Recipe luminiteBarRecipe = Recipe.Create(ItemID.LunarBar, 65)
                                             .AddIngredient(ItemID.LunarBar, 50)
                                             .AddIngredient(ModContent.ItemType<AntiHydrogen>(), 1)
                                             .AddTile(ModContent.TileType<AntimatterSynthesizerTile>())
                                             .Register();
            }
        }
    }
}
