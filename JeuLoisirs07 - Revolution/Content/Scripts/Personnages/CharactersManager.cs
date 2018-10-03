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
    class CharactersManager
    {
        MainCharacter player;

        public void GenerateCharacters(Game1 game)
        {
            GenerateMainCharacter(game);
        }

        void GenerateMainCharacter(Game1 game)
        {
            //Create Main Camera

            player = new MainCharacter(game);
        }

        public void UpdateAll(GameTime gameTime)
        {
            player.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }
    }
}
