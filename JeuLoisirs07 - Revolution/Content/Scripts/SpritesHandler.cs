using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuLoisirs07___Revolution
{
    static class SpritesHandler
    {
        public static void ChangeColorTextureRandom(Texture2D texture)
        {
            Color[] textureColor = new Color[texture.Width * texture.Height];
            texture.GetData<Color>(textureColor);

            for (int i = 0; i < textureColor.Length; i++)
            {
                switch (textureColor[i].R)
                {
                    case 227:
                        textureColor[i].R = 162;
                        textureColor[i].G = 218;
                        textureColor[i].B = 230;
                        break;
                    case 214:
                        textureColor[i].R = 143;
                        textureColor[i].G = 209;
                        textureColor[i].B = 223;
                        break;
                    case 190:
                        textureColor[i].R = 123;
                        textureColor[i].G = 202;
                        textureColor[i].B = 219;
                        break;
                    case 102:
                        textureColor[i].R = 224;
                        textureColor[i].G = 112;
                        textureColor[i].B = 125;
                        break;
                    default:
                        break;
                }
            }

            //(PouPou)Change the color of the texture
            texture.SetData<Color>(textureColor);
        }




    }
}
