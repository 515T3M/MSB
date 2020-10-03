using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSB.Projectiles.Whips
{
    public class TungstenWhipProjectile : WhipClass
    {
        public override void SetDefaults()
        {
            summonTagDamage = 4;
            summonTagCrit = 7;
            rangeMult = 0.8f;
        }
    }
}
