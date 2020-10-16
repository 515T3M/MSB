using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using MSB.UI;


namespace MSB.UI
{
    internal class CharismaResource : UIState
    {
        public static bool visible = false;
        public UIText text;
		public UIElement area; //position
		public UIImage barFrame; //ui image
        public UIImage coolShades; //ui shades image
        //colors of the bar
		private Color gradientA;
		private Color gradientB;

        public override void OnInitialize()
        {
            //setting position
            area = new UIElement();
            area.Left.Set(-area.Width.Pixels - 600, 1f);
            area.Top.Set(30, 0f);
            area.Width.Set(182, 0f);
            area.Height.Set(60, 0f);

            //getting the charisma frame
            barFrame = new UIImage(ModContent.GetTexture("MSB/UI/CharismaBarFrame"));
			barFrame.Left.Set(22, 0f);
			barFrame.Top.Set(0, 0f);
			barFrame.Width.Set(138, 0f);
			barFrame.Height.Set(34, 0f);

            //get shades icon placed
            coolShades = new UIImage(ModContent.GetTexture("MSB/UI/CoolShades"));
            coolShades.Left.Set(50, 0f);
            coolShades.Top.Set(0, 0f);
            barFrame.Width.Set(138, 0f);
			barFrame.Height.Set(34, 0f);

            //text for showing charisma stats
            text = new UIText("0/0", 0.8f);
			text.Width.Set(138, 0f);
			text.Height.Set(34, 0f);
			text.Top.Set(20, 0f);
			text.Left.Set(0, 0f);

            //setting the colors of the actual bar
            gradientA = new Color(30, 105, 50);
			gradientB = new Color(85, 200, 170);

            area.Append(text);
			area.Append(barFrame);
			Append(area);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Main.LocalPlayer.HeldItem.summon)
            return;
            base.Draw(spriteBatch);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            var modPlayer = Main.LocalPlayer.GetModPlayer<MSBPlayer>();
            float quocient = (float)modPlayer.Charisma / modPlayer.MaxCharisma;

            //adjust the charisma bar to the frame so it doenst fck up in other resolutions
            Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
			hitbox.X += 12;
			hitbox.Width -= 24;
			hitbox.Y += 8;
			hitbox.Height -= 16;

            //draw the gradient bar
            int left = hitbox.Left;
			int right = hitbox.Right;
			int steps = (int)((right - left) * quocient);
			for (int i = 0; i < steps; i += 1)
            {
                float percent = (float)i / (right - left);
				spriteBatch.Draw(Main.magicPixel, new Rectangle(left + i, hitbox.Y, 1, hitbox.Height), Color.Lerp(gradientA, gradientB, percent));
            }
        }

        public override void Update(GameTime gameTime)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<MSBPlayer>();
            if (!Main.LocalPlayer.HeldItem.summon)
            return;
            //text update per tick
            text.SetText($"{modPlayer.Charisma}/{modPlayer.MaxCharisma}");
			base.Update(gameTime);
        }
    }
}