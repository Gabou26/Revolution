using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLoisirs07___Revolution.Content.Scripts.Personnages
{
    class MainCharacter
    {
        //Champs
        Texture2D spriteSheet;
        CameraManager followingCamera;
        SpriteAnimation animation;

        //Character Infos
        Vector2 position;
        int movementSpeed = 2;

        public MainCharacter(Game1 game)
        {
            position = new Vector2(200, 223);
            followingCamera = game.mainCamera;
            spriteSheet = game.Content.Load<Texture2D>("Pictures/SpriteSheets/Perso-prototype-sheet");
            animation = new SpriteAnimation(new Point(16, 32), spriteSheet, TimeSpan.FromSeconds(1));
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            position += CheckMouvementInputs();
            followingCamera.UpdatePosition(position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch, position);
        }

        Vector2 CheckMouvementInputs()
        {
            Vector2 directionInput = new Vector2(0, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                directionInput.X = movementSpeed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                directionInput.X = -movementSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                directionInput.Y = -movementSpeed;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                directionInput.Y = movementSpeed;
            }
            return directionInput;
        }
    }
}
