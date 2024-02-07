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

        [DefaultValue(true)]
        [ReloadRequired]
        public bool EnableAncientManipulatorRecipe;

        [DefaultValue(true)]
        [ReloadRequired]
        public bool EnableLuminiteRecipe;

        #endregion recipes
    }
}
