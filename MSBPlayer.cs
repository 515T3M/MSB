﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MSB
{
    public class MSBPlayer : ModPlayer
    {
        public int summonTagDamage;
        public int summonTagCrit;
        public bool WhipAutoswing;

        public override void ResetEffects()
        {
            WhipAutoswing = false;
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {

            if ((proj.minion || ProjectileID.Sets.MinionShot[proj.type]) && target.whoAmI == player.MinionAttackTargetNPC) { damage += summonTagDamage; if (summonTagCrit > 0) { if (Main.rand.Next(1, 101) < summonTagCrit) { crit = true; } } }

        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (player.ZoneRain && liquidType == 0 && Main.rand.Next(15) == 0)
            {
                caughtType = mod.ItemType("FlyingFish");
            }
        }

    }
}
