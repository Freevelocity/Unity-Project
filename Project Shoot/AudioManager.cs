using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;






    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source =  gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.pitch;
            s.source.outputAudioMixerGroup = s.group;
            s.source.loop = s.loop;
                
        }
    }


   

    public void Play(string SoundName)
    {
        Sound s =  Array.Find(sounds, sound => sound.Name == SoundName);
        s.source.Play();
    }



}
