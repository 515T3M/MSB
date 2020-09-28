using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using MSB.Projectiles;

namespace MSB.Items.Weapons
{

    public class FlyingFish : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flying Fish Bag");
            Tooltip.SetDefault("Summons a flying fish to fight for you");
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
            ItemID.Sets.LockOnIgnoresCollision[item.type] = true;

        }

        public override void SetDefaults()
        {
            item.width = 50;
            item.height = 52;

            item.damage = 12;
            item.summon = true;
            item.mana = 5;
            item.noMelee = true;
            item.knockBack = 3;

            item.shoot = ProjectileType<Projectiles.Minions.FlyingFishProjectile>();
            item.buffType = BuffType<Buffs.FlyingFishBuff>();

            item.useTime = 30;
            item.useAnimation = 36;
            item.UseSound = SoundID.Item44;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.value = Item.buyPrice(0, 0, 30, 0);

        }

        public bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            player.AddBuff(item.buffType, 2);
            position = Main.MouseWorld;
            return true;
        }
    }
}