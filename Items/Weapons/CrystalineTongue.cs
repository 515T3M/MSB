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

            Tooltip.SetDefault("\n2 summon tag damage" + "\nYour summons will focus struck enemies");
        }
        public override void SetDefaults()
        {

            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 32;
            item.useTime = 32;
            item.width = 18;
            item.height = 18;
            item.value = 1000;
            item.shoot = mod.ProjectileType("CrystalineTongueProjectile");
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.summon = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.damage = 47;
            item.knockBack = 1.8f;
            item.shootSpeed = 8;
            item.rare = ItemRarityID.Blue;

        }
        public override void HoldItem(Player player)
        {
            item.autoReuse = player.GetModPlayer<MSBPlayer>().WhipAutoswing;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddIngredient(ItemID.Chain, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }



    }
}
