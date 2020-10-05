using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MSB.Items.Weapons
{
    public class SentreeStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 60;
            item.mana = 10;
            item.width = 56;
            item.height = 56;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.noMelee = true;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = ItemRarityID.Yellow;
            item.UseSound = SoundID.Item44;
            item.autoReuse = true;
            item.summon = true;
            item.sentry = true;
            item.shoot = mod.ProjectileType("SentreeProjectile");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.MouseWorld;
            return true;
        }
    }
}
