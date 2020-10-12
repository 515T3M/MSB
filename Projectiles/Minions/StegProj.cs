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
    public class StegProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Desert Steg");
			Terraria.Main.projFrames[projectile.type] = 8;
            Terraria.Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
		}

        public override void SetDefaults()
        {
			projectile.width = 100;
			projectile.height = 70;
            projectile.friendly = false;
            projectile.minion = true;
            projectile.minionSlots = 1f;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override void AI()
        {
            Terraria.Player player = Terraria.Main.player[projectile.owner];
            if (player.dead || !player.active)
            {
                player.ClearBuff(BuffType<StegBuff>());
            }
            if (player.HasBuff(BuffType<StegBuff>()))
            {
                projectile.timeLeft = 2;
            }

            //General behavior

            //idle position
            Vector2 idlePosition = player.Center;
            float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
			idlePosition.X += minionPositionOffsetX; // Go behind the player

            // Teleport to player if distance is too big
			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 1000f)
			{
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true; //multiplayer related
			}

            //Gravity
            projectile.velocity.Y = projectile.velocity.Y + 0.1f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f; // limits gravity affected acceleration to a max cap
            }

            //"minion chain" reorganizing
			float overlapVelocity = 0.04f;
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile other = Main.projectile[i];
				if (i != projectile.whoAmI && other.active && other.owner == projectile.owner && Math.Abs(projectile.position.X - other.position.X) + Math.Abs(projectile.position.Y - other.position.Y) < projectile.width)
				{
					if (projectile.position.X < other.position.X) projectile.velocity.X -= overlapVelocity;
					else projectile.velocity.X += overlapVelocity;

					if (projectile.position.Y < other.position.Y) projectile.velocity.Y -= overlapVelocity;
					else projectile.velocity.Y += overlapVelocity;
				}
			}

            //Find target
			// Starting search distance
			float distanceFromTarget = 400f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;

			// Targeting feature
			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
				if (between < 1000f) // Targetting distance
				{
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget) //if target isn't found, then
			{

				for (int i = 0; i < Main.maxNPCs; i++)
				{
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy())
					{
						float between = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
						// Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
						// The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
						{
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}

            //Movement and Attacking

            //Moving and Attacking Paramenters
            float speed = (6 * player.GetModPlayer<MSBPlayer>().MinionSpeedMult);
            float inertia = (35 / player.GetModPlayer<MSBPlayer>().MinionSpeedMult);
            int damage = projectile.damage;
            float distanceFromTargetX = projectile.Center.X - targetCenter.X;

            if (foundTarget)
            {
                if (distanceFromTargetX > 20f)
                {
                    Vector2 direction = targetCenter - projectile.Center;
					direction.Normalize();
					direction *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
                }
                else
                {
                    speed = 0f;
                    inertia = 0f;
                    
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, targetCenter.X, targetCenter.Y, mod.ProjectileType("StegScaleProj"), damage, 5, Main.myPlayer, 15f, 15f);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (targetCenter.X + 20), targetCenter.Y, mod.ProjectileType("StegScaleProj"), damage, 5, Main.myPlayer, 15f, 0f);
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (targetCenter.X - 20), targetCenter.Y, mod.ProjectileType("StegScaleProj"), damage, 5, Main.myPlayer, 0f, 0f);
                }
            }

            else
            {
                // Minion doesn't have a target: return to player and idle
				if (distanceToIdlePosition > 200f)
				{
					// Speed up the minion if it's away from the player
					speed = 12f;
					inertia = 60f;
				}

				speed = 0f;
                inertia = 0f;
            }

            //Animation and visuals

			projectile.spriteDirection = - projectile.direction; //sprite turns depending on velocity direction

			int frameSpeed = 0;
			projectile.frameCounter++;
            if (speed > 0)
            {
                frameSpeed = 12; //if minion is moving, then run animation
            }
			if (projectile.frameCounter >= frameSpeed)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 0;
				}
			}
        }
    }

    public class StegScaleProj : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.SentryShot[projectile.type] = true;
        }
        public override void SetDefaults()
        {
            projectile.damage = 20;
            projectile.width = 15;
            projectile.height = 20;
            projectile.aiStyle = 5;
            projectile.timeLeft = 7200;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.hostile = false;
        }

        public override bool? CanCutTiles()
        {
            return true;
        }
    }
}