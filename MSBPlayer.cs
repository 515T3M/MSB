using Microsoft.Xna.Framework;
using MSB.Projectiles.Minions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MSB
{
    public class MSBPlayer : ModPlayer
    {
        public float MinionSpeedMult;
        public float MinionRangeMult;
        public int summonCrit;
        public int summonTagDamage;
        public int summonTagCrit;
        public bool WhipAutoswing;

        public int MaxCharisma;
        public int Charisma;
        public bool EnableCharisma;
        public int CharismaRegenTimer;
        public float CharismaRegenMult;

        public bool PolarArmorSet;
        public bool PumpkinArmorSet;


        public bool ShadowCharm;
        public bool CriticalSprout;


        public override void ResetEffects()
        {
            WhipAutoswing = false;
            PolarArmorSet = false;
            PumpkinArmorSet = false;
            ShadowCharm = false;
            
            EnableCharisma = false;
            CriticalSprout = false;

            summonCrit = 0;
            MinionSpeedMult = 1f;
            CharismaRegenMult = 1f;
            MaxCharisma = 20;
        }

        public void CharismaMechanics(Player player, int Charisma, int MaxCharisma, bool EnableCharisma, float CharismaRegenMult, float MinionSpeedMult)
        {
            if (Main.LocalPlayer.HeldItem.summon)
            {
                //charisma regeneration
                CharismaRegenTimer++;
                if (CharismaRegenTimer >= 60 * (1 / CharismaRegenMult))
                {
                    //so that charisma doesnt exceed the maximum
                    if (Charisma < MaxCharisma)
                    {
                        Charisma += 1;
                    }
                    CharismaRegenTimer = 0;
                }
            }

            player.maxRunSpeed += Charisma * 10;
            player.accRunSpeed += Charisma * 10;
            MinionSpeedMult += Charisma * 10;
            //if critical sprout is equipped, allow charisma to affect crit strike chances
            if (CriticalSprout)
            {
                summonCrit += Charisma / 4;
            }
        }
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            Charisma = 0;
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {

            if (proj.minion || ProjectileID.Sets.MinionShot[proj.type])
            {
                if (target.whoAmI == player.MinionAttackTargetNPC)
                {
                    summonCrit += summonTagCrit;
                    damage += summonTagDamage;
                }
                if (summonCrit > 0)
                {
                    if (Main.rand.Next(1, 101) < summonCrit)
                        {
                            crit = true;
                        }
                }
            }

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
            if (PolarArmorSet && Main.rand.Next(5) == 0 && target.CanBeChasedBy(this) && proj.minion)
            {
                target.AddBuff(BuffID.Frostburn, 80); //inflict frostburn
            }

            if (ShadowCharm && Main.rand.Next(3) == 0 && target.CanBeChasedBy(this) && proj.minion)
            {
                target.AddBuff(BuffID.ShadowFlame, 80); //inflicts shadowflame
            }

            if (proj.type == mod.ProjectileType("ScaryLookingPumpkinProjectile"))
            {
                target.AddBuff(BuffID.Slow, 80);
            }
        }

        public override void ModifyWeaponDamage (Item item, ref float add, ref float mult, ref float flat)
        {
            if (PolarArmorSet && item.summon)
            {
                flat += 3;
            }
        }

    }
}
