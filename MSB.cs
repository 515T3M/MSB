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

namespace MSB
{
	public class MSB : Mod
	{
        public static bool visible = false;
        internal UserInterface MSBInterface;
        public UIState CharismaResource;
        public override void Load()
        {
            if (!Main.dedServ)
            {
                CharismaResource = new UIState();
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
            _lastUpdateUiGameTime = gameTime;
            if (MSBInterface?.CurrentState != null)
            {
                CharismaResource?.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "MSB: CharismaResource",
                    delegate
                    {
                        if ( _lastUpdateUiGameTime != null && MSBInterface?.CurrentState != null)
                        {
                            CharismaResource.Draw(Main.spriteBatch);
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