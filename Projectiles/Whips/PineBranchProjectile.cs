using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSB.Projectiles.Whips
{
    public class PineBranchProjectile : WhipClass
    {
        public override void SetDefaults()
        {
            summonTagDamage = 10;
            summonTagCrit = 20;
            rangeMult = 1.45f;
        }
    }
}
