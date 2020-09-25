using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSB.Projectiles.Whips
{
    class CrystalineTongueProjectile : WhipClass

    {
        public override void SetDefaults()
        {
            summonTagDamage = 7;
            rangeMult = 1.2f;
        }
    }
}
