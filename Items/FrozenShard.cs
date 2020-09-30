using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MSB.Items
{
    public class FrozenShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Leather");
            Tooltip.SetDefault("Could probably do with a better name");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.maxStack = 999;
            item.value = 100;
            item.rare = 1;
        }
    }
}