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
    public class GoldenWhip : ModItem
    {
        public override void SetStaticDefaults()
        {

            Tooltip.SetDefault("\n5 summon tag damage" + "\nYour summons will focus struck enemies");
        }
        public override void SetDefaults()
        {
            item.damage = 13;
            item.knockBack = 4f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 50;
            item.useTime = 50;
            item.width = 38;
            item.height = 40;
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.summon = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GoldWhipProjectile");
            item.shootSpeed = 4f;
            item.rare = ItemRarityID.Blue;
            item.value = 1000;

        }
        public override void HoldItem(Player player)
        {
            item.autoReuse = player.GetModPlayer<MSBPlayer>().WhipAutoswing;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 12);
            recipe.AddIngredient(ItemID.Chain, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
