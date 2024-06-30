using Terraria.ModLoader;
namespace alchemistri.Content.Compat
{
    public abstract class ModCompat
    {
        public static bool isEnabled = false; // Is the mod enabled?
        public static string modName; // What's the mod's name (<modName>.cs usually)
        public static void CompatPostInit()
        {
            isEnabled = ModLoader.HasMod(modName);
            if(isEnabled) alchemistri.Instance.Logger.DebugFormat("ENABLE COMPAT: Alchemistri + {0}", modName);
        }
    }
}
