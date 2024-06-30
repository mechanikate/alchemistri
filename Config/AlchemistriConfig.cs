using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace alchemistri.Config
{
    class AlchemistriConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static AlchemistriConfig Instance => ModContent.GetInstance<AlchemistriConfig>();

        #region recipes

        [Header("$Mods.alchemistri.Config.Recipes")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool EnableAncientManipulatorRecipe;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool EnableLuminiteRecipe;

        #endregion recipes

        #region damagevalues

        [Header("$Mods.alchemistri.Config.DamageValues")]
        [Range(1, 1000000)]
        [DefaultValue(6000)]
        [ReloadRequired]
        public int AntimatterWandDamage;

        #endregion damagevalues

        #region other

        [Header("$Mods.alchemistri.Config.Other")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool EnableAdjustablePrefix;

        #endregion other
    }
}
