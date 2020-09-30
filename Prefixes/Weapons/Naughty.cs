using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MSB.Prefixes.Weapons
{
    public class Naughty : ModPrefix
    {

        public Naughty() { }

        public override bool CanRoll(Item item)
        {
            if 
        }

        public override bool Autoload(ref string name)
        {
            if (!base.Autoload(ref name))
            {
                return false;
            }

            mod.AddPrefix("Naughty", new Naughty());

            return false;
        }

        public override void ModifyValue(ref float valueMult)
        {

            valueMult *= 1.1f;
        }

        public override PrefixCategory Category => PrefixCategory.Custom;

        public override float RollChance(Item item)
            => 0.5f;

        public override void Apply(Item item)
        {

            item.damage = (int)(item.damage * 1.10f);
            item.knockBack = (int)(item.knockBack * 1.05f);
            item.scale = (int)(item.scale * 1.25f);
            item.mana = (int)(item.mana * 0.75f);
            item.crit += 5;
            item.rare += 1;

        }

    }
}
