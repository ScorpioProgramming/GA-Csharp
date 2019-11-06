using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Pac.Resources
{
    public class Sound
    {
        public SoundEffect soundE_pacdead, soundE_paceat, soundE_begin;
        public SoundBank soundBank;

        public Sound(Game game)
        {
            soundE_paceat = game.Content.Load<SoundEffect>("Sound/paceat");
            soundE_pacdead = game.Content.Load<SoundEffect>("Sound/pacdead");
            soundE_begin = game.Content.Load<SoundEffect>("Sound/pacbegin");
        }

        public void dead()
        {
            soundE_pacdead.Play();
        }

        public void eat()
        {
            soundE_paceat.Play();
        }

        public void begin()
        {
            soundE_begin.Play();
        }

        public void ghostmove()
        {
            soundBank.GetCue("Sound/pacghost").Play();
        }
    }
}
