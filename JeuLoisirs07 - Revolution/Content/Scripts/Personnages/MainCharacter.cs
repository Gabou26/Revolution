using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLoisirs07___Revolution.Content.Scripts.Personnages
{
    class MainCharacter
    {
        Vector2 position;
        //Champs
        Texture2D spriteSheet;
        CameraManager followingCamera;

        public MainCharacter(Game1 game, CameraManager followingCamera)
        {
            position = new Vector2(-20, 0);
            this.followingCamera = followingCamera;
            spriteSheet = game.Content.Load<Texture2D>("Pictures/SpriteSheets/Perso-prototype");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            followingCamera.UpdatePosition(position);
            spriteBatch.Draw(spriteSheet, new Rectangle((int)position.X, (int)position.Y, 16, 32), new Rectangle(0, 0, 16, 32), Color.White);
        }
    }
}
