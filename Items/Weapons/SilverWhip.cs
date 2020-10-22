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
    public class SilverWhip : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("\n4 summon tag damage" + "\nYour summons will focus struck enemies");
        }
        public override void SetDefaults()
        {
            item.damage = 11;
            item.knockBack = 4f;
            item.crit = 7;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 35;
            item.useTime = 28;
            item.width = 30;
            item.height = 40;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.summon = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SilverWhipProjectile");
            item.shootSpeed = 4f;
            item.value = 1000;

        }
        public override void HoldItem(Player player)
        {
            item.autoReuse = player.GetModPlayer<MSBPlayer>().WhipAutoswing;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SilverBar, 12);
            recipe.AddIngredient(ItemID.Chain, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
