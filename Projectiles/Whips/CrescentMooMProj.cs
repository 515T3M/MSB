using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSB.Projectiles.Whips
{
    public class CrescentMooMProj : WhipClass

    {
        public override void SetDefaults()
        {
            summonTagDamage = 13;
            summonTagCrit = 20;
            rangeMult = 1.8f;
        }
    }
}
