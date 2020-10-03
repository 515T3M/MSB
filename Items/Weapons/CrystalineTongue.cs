using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;


namespace MSB.Items.Weapons
{
    public class CrystalineTongue : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("\n7 summon tag damage" + "\nYour summons will focus struck enemies");
        }
        public override void SetDefaults()
        {

            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 40;
            item.useTime = 30;
            item.width = 17;
            item.height = 14;
            item.value = 1000;
            item.shoot = mod.ProjectileType("CrystalineTongueProjectile");
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.summon = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.damage = 45;
            item.knockBack = 1.8f;
            item.shootSpeed = 4f;
            item.rare = ItemRarityID.LightPurple;

        }
        public override void HoldItem(Player player)
        {
            item.autoReuse = player.GetModPlayer<MSBPlayer>().WhipAutoswing;
        }



    }
}
