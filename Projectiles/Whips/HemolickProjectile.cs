using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MSB.Projectiles.Whips
{
    class HemolickProjectile : WhipClass
    {
        public override void SetStaticDefaults()
        {
            summonTagDamage = 7;
            summonTagCrit = 15;
            rangeMult = 1.45f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 120);
        }
    }
}
