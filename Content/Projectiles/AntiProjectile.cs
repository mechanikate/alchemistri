using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static alchemistri.Config.AlchemistriConfig;

namespace alchemistri.Content.Projectiles
{
    public class AntiProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.timeLeft = 600;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.damage = Instance.AntimatterWandDamage;
        }
    }
}
