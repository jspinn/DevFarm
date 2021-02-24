using UnityEngine;
using UnityEngine.Audio;
using System; 

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
        }
    }

    void Start()
    {
        Play("chiptune");
    }

    public void Play (string name)
    {
        // Use a dictionary/hash map instead and check for element not found errors.  
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop (string name)
    {
        // Use a dictionary/hash map instead and check for element not found errors. 
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
