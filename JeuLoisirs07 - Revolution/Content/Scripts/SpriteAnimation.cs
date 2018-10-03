using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLoisirs07___Revolution.Content.Scripts
{
    class SpriteAnimation
    {
        //Champs
        Texture2D spriteSheet;

        //Values animation
        Point characterSize;
        Point sheetSize;
        Point currentFrame = new Point(0, 0);
        TimeSpan frameInterval;
        TimeSpan nextFrame;


        public SpriteAnimation(Point characterSize, Texture2D spriteSheet, TimeSpan interval)
        {
            this.characterSize = characterSize;
            this.sheetSize = new Point(2, 1);
            this.spriteSheet = spriteSheet;
            this.frameInterval = interval;
        }

        public void Update(GameTime gameTime)
        {
            if (nextFrame >= frameInterval)
            {
                currentFrame.X++;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    currentFrame.Y++;
                }
                if (currentFrame.Y >= sheetSize.Y)
                    currentFrame.Y = 0;

                nextFrame = TimeSpan.Zero;
            }
            else
            {
                nextFrame += gameTime.ElapsedGameTime;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(spriteSheet, new Rectangle((int)position.X, (int)position.Y, 16, 32), new Rectangle(characterSize.X * currentFrame.X, characterSize.Y * currentFrame.Y, characterSize.X, characterSize.Y), Color.White);
        }
    }
}
