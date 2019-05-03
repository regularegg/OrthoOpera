using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundPlayer : MonoBehaviour
{

    public AudioClip Sound_Public_Debug;
    
    private AudioClip _Sound;
    public AudioClip Sound
    {
        get { return _Sound; }
        set
        {
            ChangeSound();
            Sound_Public_Debug = value;
            _Sound = value;
        }
    }
    public AudioSource AS;
    
    void ChangeSound()
    {
        AS.Stop();
        AS.clip = Sound;
        AS.Play();
    }

    void Start()
    {
        Sound = Sound_Public_Debug;
    }
}
