using JeuLoisirs07___Revolution.Content.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using MonoGame.Extended.ViewportAdapters;

namespace JeuLoisirs07___Revolution
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        // The tile map
        private TiledMap map;
        // The renderer for the map
        private TiledMapRenderer mapRenderer;
        CameraManager mainCamera;

        public Game1()
        {
            Content.RootDirectory = "Content";

            mainCamera = new CameraManager(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();

            // Load the compiled map
            map = Content.Load<TiledMap>("Tiled/jeuloisirs07 - zone sandbox");
            InfoBank.currentMap = map;
            // Create the map renderer
            mapRenderer = new TiledMapRenderer(GraphicsDevice);
            InfoBank.currentMapRenderer = mapRenderer;
        }

        //Place to load all of your content
        protected override void LoadContent()
        {
            mainCamera.LoadCamera(new Vector2(1280, 720), false);

            SpritesHandler.ChangeColorTextureRandom(Content.Load<Texture2D>("Pictures/Pixel Art/JeuLoisirs07/Terrain/Sandbox/Grille-terrain-beta"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            // Update the map
            // map Should be the `TiledMap`
            mapRenderer.Update(map, gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Khaki);

            mainCamera.DrawCamera();
            
            base.Draw(gameTime);
        }
    }
}
