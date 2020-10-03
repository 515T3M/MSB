using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSB.Projectiles.Whips
{
    class IronWhipProjectile : WhipClass
    {
        public override void SetDefaults()
        {
            summonTagDamage = 2;
            summonTagCrit = 5;
            rangeMult = 0.7f;
        }
    }
}
