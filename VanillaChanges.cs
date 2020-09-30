using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
        }
    }
}
