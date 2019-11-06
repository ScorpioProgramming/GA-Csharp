using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pac.Scene
{
    /**
     * BaseScene is the super class for all Scenes in the game. Any Scene to be created must 
     * extend this class and provide its own Update and Draw methods.
     */
    public abstract class BaseScene 
    {
        public KeyboardState keyboardState;
        public float scaleX = 1024/800f;    //Screen Resolution Width Scale.
        public float scaleY = 768/600f;     //Screen Resolution Height Scale.

        /*
         * Used to update the scene from the game master. This method is responsible for
         * updating the scene logic and taking care of scene management.
         * Returns a BaseScene object which indicates the next scene to be updated.
         * If you want to continue the same scene then the same object is returned.
         * Otherwise return the instance of the next scene to be updated.
         */
        public abstract BaseScene Update(GameTime gameTime);

        /*
         * Used to draw the various sprites and graphics required for the particular scene.
         * The draw method for the given gameTime should make use of the spriteBatch to 
         * draw the required sprites and textures of the scene.
         */
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        /*
         * Convert the given x axis value according to the resolution scale. 
         */
        public int ToX(int x)
        {
            return (int)(x * scaleX);
        }

        /*
         * Convert the given y axis value according to the resolution scale. 
         */
        public int ToY(int y)
        {
            return (int)(y * scaleY);
        }

        /*
         * Convert the given x axis value according to the resolution scale. 
         */
        public float ToX(float x)
        {
            return (x * scaleX);
        }

        /*
         * Convert the given y axis value according to the resolution scale. 
         */
        public float ToY(float y)
        {
            return (y * scaleY);
        }
    }
}