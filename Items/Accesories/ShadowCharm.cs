using IL.Terraria.GameContent.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MSB.Items.Accesories
{
    public class ShadowCharm : ModItem
    {

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Summons have a chance of inflicting shadow flame");
        }
        public override void SetDefaults()
        {
            item.height = 34;
            item.width = 30;
            item.accessory = true;
            item.rare = ItemRarityID.Green;
            
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<MSBPlayer>().ShadowCharm = true;
        }
    }
}
