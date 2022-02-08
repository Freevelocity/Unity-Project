using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public AudioClip Clip;

    public string Name;

    [Range(0,1f)]
    public float Volume;

    [Range(0.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;

    public AudioMixerGroup group;
}
