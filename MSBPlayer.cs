using System;
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


        public bool PolarArmorSet;


        public bool ShadowCharm;

        public override void ResetEffects()
        {
            WhipAutoswing = false;
            PolarArmorSet = false;
            ShadowCharm = false;
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

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) //if NPC is hit, then
        {
            if (PolarArmorSet && Main.rand.Next(10) == 0 && target.CanBeChasedBy(this))
            {
                target.AddBuff(BuffID.Frostburn, 50); //inflict frostburn
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) //if NPC is hit with projectile, then
        {
            if (PolarArmorSet && Main.rand.Next(5) == 0 && target.CanBeChasedBy(this))
            {
                target.AddBuff(BuffID.Frostburn, 80); //inflict frostburn
            }

            if (ShadowCharm && Main.rand.Next(3) == 0 && target.CanBeChasedBy(this))
            {
                target.AddBuff(BuffID.ShadowFlame, 80); //inflicts shadowflame
            }
        }

    }
}
