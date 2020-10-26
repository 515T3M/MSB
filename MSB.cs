using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.UI;
using Terraria.UI;
using MSB.UI;

namespace MSB
{
	public class MSB : Mod
	{
        public static bool visible = false;
        private UserInterface MSBInterface;
        internal CharismaResource CharismaResource;
        public override void Load()
        {
            if (!Main.dedServ)
            {
                CharismaResource = new CharismaResource();
                CharismaResource.Activate();
				MSBInterface = new UserInterface();
                MSBInterface.SetState(CharismaResource);
            }
        }

        public override void Unload()
        {
            CharismaResource = null;
        }

        private GameTime _lastUpdateUiGameTime;
        public override void UpdateUI(GameTime gameTime)
        {
           MSBInterface?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
            if (resourceBarIndex != -1)
            {
                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                    "MSB: Charisma Resource",
                    delegate
                    {
                        if ( _lastUpdateUiGameTime != null && MSBInterface?.CurrentState != null)
                        {
                            MSBInterface.Draw(Main.spriteBatch, new GameTime());
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Evil Bar", new int[]
           {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar,
            });
            RecipeGroup.RegisterGroup("EvilBar", group);
        }
    }
}