using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace alchemistri.Content.Projectiles
{
    public class AntiProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.arrow = true;
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.damage = 6000;
        }
    }
}
