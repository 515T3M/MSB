using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;

namespace MSB.Projectiles.Whips
{
    class SoulSwallowProjectile : WhipClass
    {
        public override void SetDefaults()
        {
            summonTagDamage = 7;
            summonTagCrit = 15;
            rangeMult = 1.45f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 120);
        }
    }
}
