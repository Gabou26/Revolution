using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;

namespace JeuLoisirs07___Revolution
{
    static class SpritesHandler
    {
        public static void ChangeColorTextureRandom(Texture2D texture)
        {
            bool hasNewHsl;
            HslColor pixelHsl;
            Random r = new Random();

            //List of changed colors in the texture
            List<int> colorsChanged = new List<int>();
            List<int> newColors = new List<int>();

            //Gets pixel color data
            Color[] textureColor = new Color[texture.Width * texture.Height];
            texture.GetData<Color>(textureColor);

            for (int i = 0; i < textureColor.Length; i++)
            {
                if (textureColor[i].A != 0)
                {
                    //Checks if the color is set to another one. If not, find random color.
                    pixelHsl = textureColor[i].ToHsl();
                    hasNewHsl = false;
                    for (int n = 0; n < colorsChanged.Count; n++)
                    {
                        if ((int)pixelHsl.H == colorsChanged[n])
                        {
                            pixelHsl = new HslColor(newColors[n], pixelHsl.S, pixelHsl.L);
                            hasNewHsl = true;
                        }
                    }
                    if (!hasNewHsl)
                    {
                        newColors.Add(r.Next(0, 360));
                        colorsChanged.Add((int)pixelHsl.H);
                        pixelHsl = new HslColor(newColors[newColors.Count - 1], pixelHsl.S, pixelHsl.L);
                    }
                    textureColor[i] = pixelHsl.ToRgb();
                }
            }
            //Change the color of the texture
            texture.SetData<Color>(textureColor);
        }

        public static Dictionary<string, Rectangle[]> GetSpriteSheetTextures(Point sizeCharacter, Texture2D spriteSheet)
        {
            Dictionary<string, Rectangle[]> animations = new Dictionary<string, Rectangle[]>();
            Point lengthArray = new Point(spriteSheet.Bounds.X / sizeCharacter.X, spriteSheet.Bounds.Y / sizeCharacter.Y);

            Rectangle[][] animationArray = SeparateAnimations(sizeCharacter, spriteSheet , lengthArray);
            animations["walk_up"] = animationArray[0];
            return animations;
        }

        static Rectangle[][] SeparateAnimations(Point characterBoxSize, Texture2D spriteSheet, Point lengthArray)
        {
            Rectangle[][] animationArray = new Rectangle[lengthArray.Y][];
            for (int y = 0; y < lengthArray.Y; y++)
            {
                animationArray[y] = new Rectangle[lengthArray.X];
                for (int x = 0; x < lengthArray.X; x++)
                {
                    animationArray[y][x] = new Rectangle(characterBoxSize.X * x, characterBoxSize.Y * y, characterBoxSize.X, characterBoxSize.Y);
                }
            }
            return animationArray;
        }
    }
}
