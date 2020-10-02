using MSB.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace MSB.Projectiles.Minions
{
    public class ScaryLookingPumpkinProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scary Looking Pumpkin");
            Terraria.Main.projFrames[projectile.type] = 6;
            Terraria.Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 0f;
            projectile.penetrate = -1;
            projectile.aiStyle = 26;
            aiType = ProjectileID.BabySlime;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override bool MinionContactDamage()
        {
            return true;
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            target.AddBuff(BuffID.Slow, 80);
        }

        public override void AI()
        {
            Terraria.Player player = Terraria.Main.player[projectile.owner];
            if (player.dead || !player.active)
            {
                player.ClearBuff(BuffType<ScaryLookingPumpkinBuff>());
            }
            if (player.HasBuff(BuffType<ScaryLookingPumpkinBuff>()))
            {
                projectile.timeLeft = 2;
            }

            //General behavior
            Vector2 idlePosition = player.Center;

            float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
            idlePosition.X += minionPositionOffsetX; // Go behind the player

            // Teleport to player if distance is too big
            Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
            float distanceToIdlePosition = vectorToIdlePosition.Length();
            if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 800f)
            {
                projectile.position = idlePosition;
                projectile.velocity *= 0.1f;
                projectile.netUpdate = true; //multiplayer related
            }
        }
    }
}
