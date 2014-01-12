using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TheKeeperHand
{
    class Cursor
    {
        // Fields.

        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox;
        private int i, intState;
        private int sizeX, sizeY;

        // Constructor.

        public Cursor(int sizeRectX, int sizeRectY, int state)
        {
            this.texture = Ressources.cursor;
            this.i = 1;
            this.intState = state;
            this.sizeX = texture.Width / intState;
            this.sizeY = texture.Height;
            this.hitbox = new Rectangle(0, 0, sizeRectX, sizeRectY);
        }

        // Get & Set.

        // Methods.

        private void SetPositionHitbox()
        {
            hitbox.X = (int)position.X;
            hitbox.Y = (int)position.Y;
        }

        // Update & Draw.

        public void Update(MouseState mouse)
        {
            position = new Vector2(mouse.X, mouse.Y);
            SetPositionHitbox();

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                this.i = 2;
            }
            else if (mouse.LeftButton == ButtonState.Released)
            {
                this.i = 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, new Rectangle((i - 1) * (texture.Width / intState), 0, sizeX, sizeY), Color.White);
        }
    }
}
