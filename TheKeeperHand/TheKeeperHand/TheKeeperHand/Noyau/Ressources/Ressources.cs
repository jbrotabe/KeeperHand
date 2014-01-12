using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TheKeeperHand
{
    class Ressources
    {
        public static Texture2D cursor, tileSet1;
        public static Texture2D tileSetInterieur;

        public static void LoadContent(ContentManager content)
        {
            cursor = content.Load<Texture2D>("Textures/TileSets/cursorTileSet2");
            tileSet1 = content.Load<Texture2D>("Textures/TileSets/tileSet1");
            tileSetInterieur = content.Load<Texture2D>("Textures/TileSets/tileSetInterieur");
        }
    }
}
