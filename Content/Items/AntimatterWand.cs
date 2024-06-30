using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using alchemistri.Content.Projectiles;
using alchemistri.Content.Tiles;
using static alchemistri.Config.AlchemistriConfig;

namespace alchemistri.Content.Items
{
    public class AntimatterWand : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = Instance.AntimatterWandDamage;
            Item.DamageType = DamageClass.Magic;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 1;
            Item.useAnimation = 20;
            Item.useStyle = 5;
            Item.knockBack = 6;
            Item.value = 10000000;
            Item.rare = -12;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<AntiProjectile>(); // shoot the anti projectiles
            Item.shootSpeed = 20f;
        }

        public override void AddRecipes() // 7 antihydrogen required @ antimatter synthesizer.
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<AntiHydrogen>(7)
                  .AddTile(ModContent.TileType<AntimatterSynthesizerTile>())
                  .Register();
        }
    }
}
