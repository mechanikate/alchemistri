using Terraria.ModLoader;
using static alchemistri.Config.AlchemistriConfig;
namespace alchemistri
{
    
	public class alchemistri : Mod
    {
        internal static alchemistri Instance;
        public override void Load()
        {
            Instance = this;
        }
    }
}