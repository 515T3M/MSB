using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSB.Projectiles.Whips
{
    class DestroyerProj : WhipClass

    {
        public override void SetDefaults()
        {
            summonTagDamage = 4;
            summonTagCrit = 30;
            rangeMult = 1.6f;
        }
    }
}