using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditor
{
    class GameMain : HUDState
    {
        // Fields.

        private Game1 game;
        private SelectionTile selection;
        private Sprite sprite;
        private Map mapMiddleground, mapBackground;
        private HUD hud;
        private Cursor cursor;

        private int[,] map1 = new int[,] { {0, 0, 0, 0, 0, 0, 0, 0, 0},
                              {0, 0, 0, 0, 0, 0, 0, 0, 0},
                              {0, 1, 1, 1, 1, 0, 0, 0, 0},
                              {0, 1, 5, 1, 1, 0, 0, 0, 0},
                              {0, 1, 1, 1, 1, 0, 0, 0, 0},
                              {0, 1, 1, 2, 1, 0, 0, 0, 0},
                              {0, 1, 1, 1, 1, 0, 0, 0, 0},
                              {0, 1, 3, 4, 1, 0, 0, 0, 0},
                              {0, 1, 1, 1, 6, 0, 0, 0, 0}};
        private int[,] map2 = new int[,] { { 1, 2, 3, 0, 0, 16, 2, 2, 3 }, 
                                                { 6, 0, 8, 0, 0, 8, 0, 0, 0 }, 
                                                { 6, 0, 14, 2, 2, 15, 0, 0, 0 }, 
                                                { 6, 0, 9, 4, 4, 7, 0, 0, 0 }, 
                                                { 10, 4, 5, 0, 0, 17, 0, 0, 0 } };

        // Constructor.

        public GameMain(Game1 game, int sizeX, int sizeY)
        {
            this.game = game;
            selection = new SelectionTile(Ressources.SelectionTest);
            mapBackground = new Map(Ressources.tileSetFloorInt, this.cursor, this.selection, 6, 0, map1);
            mapMiddleground = new Map(Ressources.tileSetInterieur, this.cursor, this.selection, 5, 4, map2);
            cursor = new Cursor(32, 32, 2);
            sprite = new Sprite(new Vector2(875, 30), 5, 4, 6 ,0, 0 ,0);
            hud = new HUD(this.game, Ressources.textureHUD, this.cursor, this.sprite);
        }

        // Get & Set.

        // Methods.

        private void UpdateAllGround(MouseState mouse)
        {
            if (planB)
            {
                mapBackground.Update(mouse);
            }
            if (planM)
            {
                mapMiddleground.Update(mouse);
            }
        }

        private void DrawSelection(SpriteBatch spriteBatch)
        {
            if (planB)
            {
                selection.Draw(spriteBatch);
            }
            else if (planM)
            {
                selection.Draw(spriteBatch);
            }
        }

        // Update & Draw.

        public void Update(GameTime gameTime, KeyboardState keyboard, MouseState mouse)
        {
            UpdateAllGround(mouse);
            InitBackground();
            cursor.Update(gameTime, mouse, keyboard);
            hud.Update(gameTime, mouse);
            sprite.Update(mouse);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mapBackground.Draw(spriteBatch, Mouse.GetState());
            mapMiddleground.Draw(spriteBatch, Mouse.GetState());
            DrawSelection(spriteBatch);
            hud.Draw(spriteBatch);
            sprite.Draw(spriteBatch);
            cursor.Draw(spriteBatch);
        }
    }
}
