using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip Clip;

    public bool IsLoop;
    public bool OnAwake;

    [Range(0f, 1f)]
    public float Volume;
    [Range(.1f, 3f)]
    public float Pitch;

    [HideInInspector] // Wont show the variable
    public AudioSource Source;


}
