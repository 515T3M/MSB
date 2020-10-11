using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using MSB.Projectiles;
using MSB.Buffs;

namespace MSB.Items.Weapons
{

    public class StegStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sand Steg Staff");
            Tooltip.SetDefault("Summons a ancient sedimental to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;

        }

        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 26;

            item.damage = 12;
            item.summon = true;
            item.noMelee = true;
            item.knockBack = 3;

            item.shoot = mod.ProjectileType("StegProj");
            item.buffType = mod.BuffType("StegBuff");

            item.useTime = 30;
            item.useAnimation = 30;
            item.UseSound = SoundID.Item44;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.value = Item.sellPrice(0, 0, 30, 0);
            item.rare = ItemRarityID.Blue;

        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(mod.BuffType("StegBuff"), 2, true);
            position = Main.MouseWorld;
            return true;
        }
    }
}