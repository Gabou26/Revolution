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
        Camera2D cam;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Game1 currentScene;

        //functions
        public CameraManager(Game1 currentScene)
        {
            this.currentScene = currentScene;
            graphics = new GraphicsDeviceManager(currentScene);
        }

        public void LoadCamera(Vector2 size, bool isFullScreen)
        {
            SetWindowSize(size);
            SetFullscreen(isFullScreen);

            var viewPortAdapter = new BoxingViewportAdapter(currentScene.Window, currentScene.GraphicsDevice, 800, 480);

            cam = new Camera2D(viewPortAdapter);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(currentScene.GraphicsDevice);
        }

        public void UpdatePosition(Vector2 targetPosition)
        {
            cam.Position = targetPosition;
        }

        public void DrawCamera()
        {
            cam.Zoom = 2;
            // Transform matrix is only needed if you have a Camera2D
            // Setting the sampler state to `SamplerState.PointClamp` is reccomended to remove gaps between the tiles when rendering
            spriteBatch.Begin(transformMatrix: cam.GetViewMatrix(), samplerState: SamplerState.PointClamp);

            // map Should be the `TiledMap`
            // Once again, the transform matrix is only needed if you have a Camera2D
            InfoBank.currentMapRenderer.Draw(InfoBank.currentMap, cam.GetViewMatrix());

            // End the sprite batch
            spriteBatch.End();
        }

        void SetFullscreen(bool config)
        {
            graphics.IsFullScreen = config;
        }

        void SetWindowSize(Vector2 size)
        {
            //(PouPou)Sert à définir la grandeur de la fenêtre
            graphics.PreferredBackBufferWidth = (int)size.X;
            graphics.PreferredBackBufferHeight = (int)size.Y;
        }

    }
}
