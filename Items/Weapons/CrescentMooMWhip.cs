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
    public class CrescentMooMWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crescent Moon");
            Tooltip.SetDefault("\n13 summon tag damage" + "\nYour summons will focus struck enemies" + "\n'The mighty Moan... i mean, Moon'");
        }
        public override void SetDefaults()
        {

            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 40;
            item.useTime = 30;
            item.width = 17;
            item.height = 14;
            item.value = 1000;
            item.shoot = mod.ProjectileType("CrescentMooMProj");
            item.UseSound = SoundID.Item1;
            item.noMelee = true;
            item.summon = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.damage = 190;
            item.knockBack = 2.5f;
            item.shootSpeed = 4f;
            item.rare = ItemRarityID.Red;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 12);
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
