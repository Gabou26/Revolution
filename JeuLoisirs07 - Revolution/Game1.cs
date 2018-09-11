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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // The tile map
        private TiledMap map;
        // The renderer for the map
        private TiledMapRenderer mapRenderer;
        Camera2D cam;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //(PouPou)Sert à définir la grandeur de la fenêtre
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = false;
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
            // Create the map renderer
            mapRenderer = new TiledMapRenderer(GraphicsDevice);
        }

        //Place to load all of your content
        protected override void LoadContent()
        {
            var viewPortAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 480);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            cam = new Camera2D(viewPortAdapter);
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

            // Transform matrix is only needed if you have a Camera2D
            // Setting the sampler state to `SamplerState.PointClamp` is reccomended to remove gaps between the tiles when rendering
            spriteBatch.Begin(transformMatrix: cam.GetViewMatrix(), samplerState: SamplerState.PointClamp);

            // map Should be the `TiledMap`
            // Once again, the transform matrix is only needed if you have a Camera2D
            mapRenderer.Draw(map, cam.GetViewMatrix());

            // End the sprite batch
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
