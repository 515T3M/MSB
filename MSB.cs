using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace MSB
{
	public class MSB : Mod
	{
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Evil Bar", new int[]
           {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar,
            });
            RecipeGroup.RegisterGroup("EvilBar", group);
        }
    }
}