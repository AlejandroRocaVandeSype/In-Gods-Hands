using UnityEngine.Audio;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Sound[] m_Sounds;
   // private const string BACKGROUND_MUSIC = "BackgroundMusic";

    private void Awake()
    {
        foreach (Sound s in m_Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.IsLoop;
            s.Source.playOnAwake = s.OnAwake;
        }
    }

    public void PlaySound(string name, bool waitSoundEnd)
    {
        Sound s = Array.Find(m_Sounds, sound => sound.Name == name);

        if (s != null)
        {
            if (waitSoundEnd == false)
            {
                // Dont wait the sound to end in order to play again
                s.Source.Play();
            }
            else
            {
                // Wait until the sound has finished playing
                if (!s.Source.isPlaying)
                    s.Source.Play();
            }
        }


    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(m_Sounds, sound => sound.Name == name);

        if (s != null && s.Source.isPlaying)
            s.Source.Stop();

    }

    public void PlayMusic()
    {
        //PlaySound(BACKGROUND_MUSIC, false);
    }

    public void StopMusic()
    {
        //StopSound(BACKGROUND_MUSIC);
    }
}
