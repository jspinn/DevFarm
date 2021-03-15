// Refernces and sources:
// https://www.youtube.com/watch?v=QL29aTa7J5Q
// https://www.youtube.com/watch?v=6OT43pvUyfY
using UnityEngine;
using UnityEngine.Audio;
using System;

/*
 * Uses:
 * FindObjectOfType<AudioManager>().Play("name");
 * The list of sounds can be found in the AudioManager game object.
 */
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [HideInInspector]
    public AudioSource source;
}

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
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { Debug.LogWarning("Sound " + name + " not found."); }
        else { s.source.Play(); }
    }

    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { Debug.LogWarning("Sound " + name + " not found."); }
        else { s.source.Stop(); }
    }
}