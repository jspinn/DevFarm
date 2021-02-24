using UnityEngine;
using UnityEngine.Audio;
using System; 

public class AudioManager{

    public Sound[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play (string name)
    {
        // Use a dictionary/hash map instead
        Array.Find(sounds, sound => sound.name == name).source.play;
    }
}
