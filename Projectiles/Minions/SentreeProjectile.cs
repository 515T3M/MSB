using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MSB.Projectiles.Minions
{
    public class SentreeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 3;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            ProjectileID.Sets.TurretFeature[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 48;
            projectile.height = 64;
            projectile.aiStyle = 134;
            projectile.timeLeft = 72000;
            projectile.light = 0.25f;
            projectile.ignoreWater = true;
            projectile.sentry = true;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.minionSlots = 1f;
            projectile.penetrate = -1;
        }

        public override bool? CanCutTiles()
        {
            return true;
        }

        public override void AI()
        {
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];

                //Get shooting trajectory
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + (float)target.height * 0.5f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                //If the distance between the projectile and the live target is active
                if (distance < 520f && !target.friendly && target.active)
                {
                    if (projectile.ai[0] > 120f)//this make so the projectile1 shoot a projectile every X (60 = 1s)
                    {
                        //Dividing the factor of 2f which is the desired velocity by distance
                        distance = 1.6f / distance;
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 70;                   
                                          //Shoot projectile and set ai back to 0
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, mod.ProjectileType("ChristmasStarProjectile"), damage, 5, Main.myPlayer, 0f, 0f);
                        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 24); //24 is the sound
                        projectile.ai[0] = 0f;
                    }
                }
            }

            projectile.ai[0] += 1f;

            projectile.tileCollide = true;


            //Animation
            int frameSpeed = 5;
            projectile.frameCounter++;
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

    public class ChristmasStarProjectile : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.SentryShot[projectile.type] = true;
        }
        public override void SetDefaults()
        {
            projectile.width = 9;
            projectile.height = 10;
            projectile.aiStyle = 5;
            projectile.timeLeft = 7200;
            projectile.light = 0.75f;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
        }

        public override bool? CanCutTiles()
        {
            return true;
        }
    }
}
