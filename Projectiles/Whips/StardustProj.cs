using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSB.Projectiles.Whips
{
    class StardustProj : WhipClass

    {
        public override void SetDefaults()
        {
            summonTagDamage = 13;
            summonTagCrit = 18;
            rangeMult = 1.7f;
        }
    }
}
