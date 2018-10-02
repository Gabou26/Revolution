using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLoisirs07___Revolution.Content.Scripts.Personnages
{
    static class CharactersManager
    {
        static MainCharacter player;

        public static void GenerateCharacters(Game1 game, CameraManager mainCamera)
        {
            GenerateMainCharacter(game, mainCamera);
        }

        static void GenerateMainCharacter(Game1 game, CameraManager mainCamera)
        {
            //Create Main Camera
            player = new MainCharacter(game, mainCamera);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }
    }
}
