﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSB.Projectiles.Whips
{
    public class PlatinumWhipProjectile : WhipClass
    {
        public override void SetDefaults()
        {
            summonTagDamage = 5;
            summonTagCrit = 10;
            rangeMult = 0.95f;
        }
    }
}
