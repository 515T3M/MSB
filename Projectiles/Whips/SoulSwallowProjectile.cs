using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSB.Projectiles.Whips
{
    class SoulSwallowProjectile : WhipClass
    {
        public override void SetDefaults()
        {
            summonTagDamage = 7;
            rangeMult = 1f;
        }
    }
}
