using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MSB.Buffs;

namespace MSB
{
    public class VanillaDropChanges : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (Main.rand.Next(10) == 0)
            {
                if (npc.type == 475)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CrystalineTongue"));
                }

                if (npc.type == 474)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Hemolick"));
                }

                if (npc.type == 473)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulSwallow"));
                }

            }

            if (Main.rand.Next(50) == 0)
            {
                if (npc.type == 224)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FlyingFish"));
                }
            }

            if (Main.rand.Next(50) == 0) //Pre-hm underground ice enemies have a chance of dropping Frozen Shards
            {
                if (npc.type == NPCID.IceBat)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrozenLeather"));
                }
                if (npc.type == NPCID.SnowFlinx)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrozenLeather"));
                }
                if (npc.type == NPCID.SpikedIceSlime)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrozenLeather"));
                }
            }

            if (npc.type == NPCID.UndeadViking)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrozenLeather"), Main.rand.Next(1, 4));
            }

            if (Main.rand.Next(7) == 0)
            {
                if (npc.type == NPCID.GoblinSummoner)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowCharm"));
                }

            }

            if (npc.type == NPCID.KingSlime)
            {
                if (Main.rand.NextFloat() < .18f) //.18f
                    Item.NewItem(npc.getRect(), ItemID.SlimeStaff);
            }
        }
    }

    public class VanillaItemChanges : GlobalItem

    {
        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            if (head.type == ItemID.PumpkinHelmet && body.type == ItemID.PumpkinBreastplate && legs.type == ItemID.PumpkinLeggings)
            {
                return "PumpkinArmorSet";
            }
            return "";
        }

        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == "PumpkinArmorSet")
            {
                player.setBonus = "Summons a scary looking pumpkin";
                player.maxMinions += 1;
                if (player.ownedProjectileCounts[mod.ProjectileType("ScaryLookingPumpkinProjectile")] == 0)
                {
                    Projectile.NewProjectile(player.position, player.velocity, mod.ProjectileType("ScaryLookingPumpkinProjectile"), 5, 5, Main.myPlayer);
                    player.AddBuff(mod.BuffType("ScaryLookingPumpkinProjectile"), 2);
                }
            }

        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (item.type == ItemID.PumpkinHelmet)
            {
                player.minionDamageMult += 0.02f;
                item.defense = 2;
            }

            if (item.type == ItemID.PumpkinBreastplate)
            {
                player.minionDamageMult += 0.03f;
                item.defense = 3;
            }
            if (item.type == ItemID.PumpkinLeggings)
            {
                player.minionDamageMult += 0.05f;
                item.defense = 5;
            }
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (Main.rand.NextFloat() < .25f && arg == ItemID.KingSlimeBossBag)
            {
                Item.NewItem(player.getRect(), ItemID.SlimeStaff);
            }
        }
    }
}
