using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace MSB.Projectiles.Whips
{
    public class CrescentMooMProj : WhipClass

    {
        public override void SetDefaults()
        {
            summonTagDamage = 13;
            summonTagCrit = 20;
            rangeMult = 2f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0,ProjectileID.LunarFlare, damage, 12, projectile.owner, 0);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0,ProjectileID.MoonLeech, damage, 12, projectile.owner, 0);

        }

        public override void AI()
        {
            Lighting.AddLight(projectile.position, Color.LightSeaGreen.ToVector3() * 0.18f);
        }
    }
}
