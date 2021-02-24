using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;
    // TODO: Move this to audiomanager and rewrite the awake function.
    [HideInInspector]
    public AudioSource source; 
}
