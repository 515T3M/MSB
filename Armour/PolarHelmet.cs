using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MSB.Armour
{
  [AutoloadEquip(EquipType.Head)]
  public class PolarHelmet : ModItem
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Polar Hood");
      //Tooltip.SetDefault("");
    }

    public override void SetDefaults()
    {
      item.width = 18;
      item.height = 18;
      item.value = 7000;
      item.rare = 0;
      item.defense = 2;
    }

        public override void UpdateEquip(Player player)
        {
            player.minionDamage *= 1.01f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) //Check if the player is wearing the full armour set
    {
      if (body.type == ModContent.ItemType<PolarBreastplate>())
        return legs.type == ModContent.ItemType<PolarGreaves>();
      return false;
    }
	
	public override void UpdateArmorSet(Player player) //Do this is full armour set
    {
      player.setBonus = "Gives an extra minion slot";
      Player player1 = player;
	  player1.maxMinions += 1; //Extra minion slot
            player.GetModPlayer<MSBPlayer>().PolarArmorSet = true;
        }

    
	/*public override void UpdateEquip(Player player)
	{
	 Player player1 = player;
     player1.=;
	}*/

    public override void AddRecipes() 
	{
		ModRecipe recipe = new ModRecipe(mod);
		recipe.AddIngredient(ItemID.SnowBlock, 10);
		recipe.AddIngredient(ItemID.IceBlock, 15);
            recipe.AddRecipeGroup("IronBar", 4);
		recipe.AddIngredient(mod.ItemType("FrozenShard"));
		recipe.AddTile(TileID.IceMachine);
		recipe.SetResult(this);
		recipe.AddRecipe();
	}
  }
}