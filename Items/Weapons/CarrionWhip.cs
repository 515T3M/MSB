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
    public class CarrionWhip : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("\n5 summon tag damage" + "\nYour summons will focus struck enemies");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.knockBack = 4f;
            item.crit = 9;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 40;
            item.useTime = 30;
            item.width = 30;
            item.height = 40;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.summon = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CarrionWhipProjectile");
            item.shootSpeed = 4.5f;
            item.value = 1000;
            item.rare = ItemRarityID.Blue;

        }
        public override void HoldItem(Player player)
        {
            item.autoReuse = player.GetModPlayer<MSBPlayer>().WhipAutoswing;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 12);
            recipe.AddIngredient(ItemID.Chain, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
