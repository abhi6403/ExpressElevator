using System;
using ExpressElevator.Utilities;
using UnityEngine;

namespace ExpressElevator.Sound
{
    public class SoundService : GenericMonoSingleton<SoundService>
    {
        public AudioSource soundEffect;
        public AudioSource soundMusic;

        public SoundType[] Sounds;

        public bool isMute = false;
        private void Start()
        {
            PlayMusic(Sound.MUSIC);
        }

        public void Mute(bool status)
        {
            isMute = status;
        }
        public void PlayMusic(Sound sound)
        {
            if (isMute)
                return;


            AudioClip clip = getSoundClip(sound);
            if(clip != null)
            {
                soundMusic.clip = clip;
                soundMusic.Play();
            }
            else
            {
                Debug.LogError("Clip not found for sound type: +  sound");
            }
        }

        public void StopSound(Sound sound)
        {
            soundEffect.Stop();
        }
        public void Play(Sound sound)
        {
            if (isMute)
                return;

            AudioClip clip = getSoundClip(sound);
            if(clip != null)
            {
                soundEffect.PlayOneShot(clip);
            }else
            {
                Debug.LogError("Clip not found for sound type: " +  sound);
            }
        }

        private AudioClip getSoundClip(Sound sound)
        {
            SoundType item = Array.Find(Sounds, i => i.soundType == sound);
            if(item != null)
                return item.soundClip;
            return null;
        }
    }

    [Serializable]
    public class SoundType
    {
        public Sound soundType;
        public AudioClip soundClip;
    }

    public enum Sound
    {
        BUTTONCLICK,
        ELEVATORMOVING,
        DOOROPENING,
        DOORCLOSING,
        REACHEDFLOOR,
        FLOORBUTTON,
        MUSIC,
    }
}
