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

        public static void GenerateCharacters(Game1 game)
        {
            GenerateMainCharacter(game);
        }

        static void GenerateMainCharacter(Game1 game)
        {
            //Create Main Camera

            player = new MainCharacter(game);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }
    }
}
