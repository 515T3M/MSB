using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace MSB.Armour
{
  [AutoloadEquip(EquipType.Body)]
  public class PolarBreastplate : ModItem
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Polar Breastplate");
      //Tooltip.SetDefault("");
    }

    public override void SetDefaults()
    {
      item.width = 360;
      item.height = 370;
      item.value = 10000;
      item.rare = 0;
      item.defense = 3;
    }

    public override void UpdateEquip(Player player)
    {
            player.minionDamageMult += 0.03f;
    }

        public override void AddRecipes() 
	{
	ModRecipe recipe = new ModRecipe(mod);
		recipe.AddIngredient(ItemID.SnowBlock, 20);
		recipe.AddIngredient(ItemID.IceBlock, 30);
            recipe.AddRecipeGroup("IronBar", 10);
		recipe.AddIngredient(mod.ItemType("FrozenLeather"), 3);
		recipe.AddTile(TileID.IceMachine);
		recipe.SetResult(this);
		recipe.AddRecipe();
	}
  }
}