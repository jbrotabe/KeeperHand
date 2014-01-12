using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TheKeeperHand
{
    class Map
    {
        // Fields.

        private List<CollisionTile> collisionsTiles = new List<CollisionTile>();
        private Texture2D tileSet;
        private int tileSetX, tileSetY;

        // Constructor.

        public Map(Texture2D tileSet, int tileSetX, int tileSetY)
        {
            this.tileSet = tileSet;
            this.tileSetX = tileSetX;
            this.tileSetY = tileSetY;
        }

        // Get & Set.

        internal List<CollisionTile> CollisionsTiles
        {
            get { return collisionsTiles; }
            set { collisionsTiles = value; }
        }

        // Methods.

        public void Generate(int[,] map)
        {
            int sizeX = tileSet.Width;
            int sizeY = tileSet.Height;
            if (tileSetX > 0)
            {
                sizeX = (tileSet.Width / tileSetX);
            }
            if (tileSetY > 0)
            {
                sizeY = (tileSet.Height / tileSetY);
            }

            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];
                    int xMap = 0;
                    int yMap = 0;

                    if (number > 0)
                    {
                        for (int n = 1; n < number; n++)
                        {
                            xMap++;
                            if (xMap > tileSetX - 1)
                            {
                                xMap = 0;
                                yMap++;
                                if (yMap > tileSetY)
                                {
                                    yMap = 0;
                                }
                            }
                        }
                        collisionsTiles.Add(new CollisionTile(tileSet, new Rectangle(x * sizeX, y * sizeY, sizeX, sizeY), xMap, yMap, tileSetX, tileSetY));
                    }
                }
            }
        }

        // Update & Draw.

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTile tile in collisionsTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
