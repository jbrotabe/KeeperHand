using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace TheKeeperHand
{
    class GameMain
    {
        // Fields.

        private Map mapForeground;
        private Cursor cursor;

        // Constructor.

        public GameMain(int sizeX, int sizeY)
        {
            mapForeground = new Map(Ressources.tileSetInterieur, 5, 3);
            cursor = new Cursor(32, 32, 2);
            mapForeground.Generate(new int[,] { {1,2,3,0,0}, {6,0,8,0,0}, {6,0,0,0,0},{10,4,5,0,0} });
        }

        // Get & Set.

        // Methods.

        // Update & Draw.

        public void Update(GameTime gameTime, KeyboardState keyboard, MouseState mouse)
        {
            cursor.Update(mouse);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mapForeground.Draw(spriteBatch);
            cursor.Draw(spriteBatch);
        }
    }
}
