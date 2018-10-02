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
    class CameraManager
    {
        //Champs
        private Camera2D cam;

        //functions
        public CameraManager(Vector2 size, bool isFullScreen, GraphicsDeviceManager graphics)
        {
            SetWindowSize(size, graphics);
            SetFullscreen(isFullScreen, graphics);
        }

        public void LoadCamera(Game1 game)
        {
            var viewPortAdapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, 800, 480);
            cam = new Camera2D(viewPortAdapter);
        }

        public void UpdatePosition(Vector2 targetPosition)
        {
            cam.Position = targetPosition - (new Vector2(195, 100) * cam.Zoom);
        }

        public void DrawCamera()
        {
            cam.Zoom = 2;
        }

        void SetFullscreen(bool config, GraphicsDeviceManager graphics)
        {
            graphics.IsFullScreen = config;
        }

        void SetWindowSize(Vector2 size, GraphicsDeviceManager graphics)
        {
            graphics.PreferredBackBufferWidth = (int)size.X;
            graphics.PreferredBackBufferHeight = (int)size.Y;
        }

        public Matrix GetViewMatrix()
        {
            return cam.GetViewMatrix();
        }

    }
}
