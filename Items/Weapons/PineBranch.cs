using MSB.Projectiles.Whips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MSB.Items.Weapons
{
    public class PineBranch : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("\n10 summon tag damage" + "\nYour summons will focus struck enemies");
        }
        public override void SetDefaults()
        {

            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 40;
            item.useTime = 30;
            item.width = 38;
            item.height = 36;
            item.value = 1000;
            item.shoot = mod.ProjectileType("PineBranchProjectile");
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.summon = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.damage = 87;
            item.knockBack = 2f;
            item.shootSpeed = 4f;
            item.rare = ItemRarityID.Yellow;

        }
    }
}
