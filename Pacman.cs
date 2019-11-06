using Microsoft.Xna.Framework;

using Pac.Constants;
using Pac.App;

namespace Pac.Character
{
    public class Pacman : GameCharacter
    {
        public static Vector2 init = new Vector2(100+10+GameConstants.TEXTURE_WIDTH*13, 0+9+GameConstants.TEXTURE_HEIGHT*23);
        public int score = -GameConstants.PELLET_EAT_SCORE;
        public bool isPowerUpMode = false;
        public double powerUpTime = GameConstants.POWER_UP_TIME;
        public int lives = GameConstants.NO_OF_LIVES;

        public int pelletEatenTime = 0;
        public double lifetime = 0;
        public int totalTime = 0;
        public int pelletsEaten = 0;
        
        public Pacman()
        {
            bound = new Vector2(init.X, init.Y);
            speed = GameConstants.PACMAN_SPEED;
        }

        public Pacman(float x,float y)
        {
            bound = new Vector2(x, y);
            speed = GameConstants.PACMAN_SPEED;
        }

        public override void move(GameTime gameTime)
        {
            if (isPowerUpMode)
            {
                if (speedX != 0)
                {
                    speedX = speedX < 0 ? -GameConstants.POWER_UP_SPEED : GameConstants.POWER_UP_SPEED;
                }
                if (speedY != 0)
                {
                    speedY = speedY < 0 ? -GameConstants.POWER_UP_SPEED : GameConstants.POWER_UP_SPEED;
                }
            }
            bound.X += (float)gameTime.ElapsedGameTime.TotalSeconds * speedX;
            bound.Y += (float)gameTime.ElapsedGameTime.TotalSeconds * speedY;
        }
        
        public bool eatPellet()
        {
            int x1 = (int)(((this.bound.X - 10) - 100 + GameConstants.TEXTURE_WIDTH / 2) + 1) / GameConstants.TEXTURE_WIDTH;
            int y1 = (int)((this.bound.Y - 9) + 1 + GameConstants.TEXTURE_HEIGHT / 2) / GameConstants.TEXTURE_HEIGHT;
            
            if (GameConstants.MAP[y1, x1] == GameConstants.MAP_PELLET)
            {
                this.score += 10;
                GameConstants.MAP[y1, x1] = GameConstants.MAP_EMPTY;
                GameConstants.pelletsLeft--;
                pelletEatenTime = 0;
                pelletsEaten++;
                Game1.sound.eat();
            }
            else if (GameConstants.MAP[y1, x1] == GameConstants.MAP_POWERUP)
            {
                this.score += GameConstants.POWERUP_EAT_SCORE;
                GameConstants.MAP[y1, x1] = GameConstants.MAP_EMPTY;
                this.isPowerUpMode = true;
                this.powerUpTime += GameConstants.POWER_UP_TIME;
                GameConstants.pelletsLeft--;
                pelletEatenTime = 0;
                pelletsEaten++;
                Game1.sound.eat();
                return true;
            }
            return false;
        }
    }
}
