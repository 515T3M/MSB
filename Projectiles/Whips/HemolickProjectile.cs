using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
