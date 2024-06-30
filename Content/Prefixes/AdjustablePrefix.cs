using alchemistri.Config;
using System;
using Terraria;
using Terraria.ModLoader;

namespace alchemistri.Content.Prefixes
{
    public class AdjustablePrefix : ModPrefix
    {
        public static float damageMultS = 1f;
        public static float knockbackMultS = 1f;
        public static float useTimeMultS = 1f;
        public static int critBonusS = 1;
        public static bool restatRan = false;

        public override PrefixCategory Category => PrefixCategory.AnyWeapon;
        public override float RollChance(Item item)
        {
            return 1f; // 1%
        }

        public override bool CanRoll(Item item)
        {
            if(AlchemistriConfig.Instance.EnableAdjustablePrefix) return true;
            return false;
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            if (!restatRan)
            {
                float[] spacers = new float[5];
                spacers[0] = 0f;
                spacers[1] = 1.04f;
                for (int i = 0; i < 4; i++) spacers[i] = Main.rand.NextFloat(0f, 2.04f);
                Array.Sort(spacers);
                float[] N = new float[5];
                for (int i = 0; i < 4; i++)
                {
                    N[i] = spacers[i + 1] - spacers[i];
                } // generating 5 numbers that all sum to 1.04f
                damageMultS = N[0] + 0.95f;
                knockbackMultS = N[1] + 0.95f;
                useTimeMultS = N[2] + 0.95f;
                critBonusS = (int)Math.Ceiling(N[3] * 100 - 100);
                restatRan = true;
            }
            damageMult = damageMultS;
            knockbackMult = knockbackMultS;
            useTimeMult = useTimeMultS;
            critBonus = critBonusS;
        }
        public override void SetStaticDefaults()
        {
            restatRan = false;
            base.Load();
        }
        public override void Unload()
        {
            restatRan = true;
            base.Load();
        }
    }
}
