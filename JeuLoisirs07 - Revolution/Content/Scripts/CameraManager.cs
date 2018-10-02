using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLoisirs07___Revolution.Content.Scripts
{
    public class CameraManager
    {
        //Champs
        private Camera2D cam;
        private Game1 game;

        //functions
        public CameraManager(Vector2 size, bool isFullScreen, Game1 game)
        {
            this.game = game;
            SetWindowSize(size);
            SetFullscreen(isFullScreen);
        }

        public void LoadCamera()
        {
            var viewPortAdapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, 800, 480);
            cam = new Camera2D(viewPortAdapter);
        }

        public void UpdatePosition(Vector2 targetPosition)
        {
            cam.Position = targetPosition - (new Vector2(392, 224));
        }

        public void DrawCamera()
        {
            cam.Zoom = 2.2f;
        }

        void SetFullscreen(bool config)
        {
            game.graphics.IsFullScreen = config;
        }

        void SetWindowSize(Vector2 size)
        {
            game.graphics.PreferredBackBufferWidth = (int)size.X;
            game.graphics.PreferredBackBufferHeight = (int)size.Y;
        }

        public Matrix GetViewMatrix()
        {
            return cam.GetViewMatrix();
        }

    }
}
