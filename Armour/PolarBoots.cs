using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace MSB.Armour
{
  [AutoloadEquip(EquipType.Legs)]
  public class PolarBoots : ModItem
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Polar Boots");
            Tooltip.SetDefault("+5% movement speed");
    }

    public override void SetDefaults()
    {
      item.width = 18;
      item.height = 18;
      item.value = 9000;
      item.rare = 0;
      item.defense = 2;
    }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.05f;
        }

        public override void AddRecipes() 
	{
		ModRecipe recipe = new ModRecipe(mod);
		recipe.AddIngredient(ItemID.SnowBlock, 18);
		recipe.AddIngredient(ItemID.IceBlock, 25);
            recipe.AddRecipeGroup("IronBar", 6);
            recipe.AddIngredient(mod.ItemType("FrozenLeather"), 2);
            recipe.AddTile(TileID.IceMachine);
		recipe.SetResult(this);
		recipe.AddRecipe();
	}
  }
}