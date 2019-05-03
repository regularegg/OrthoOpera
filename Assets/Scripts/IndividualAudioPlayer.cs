using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualAudioPlayer : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip[] ClipsToPlay;
    public bool[] Playing;
    public int CurrentClipPlaying;
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentClipPlaying = 0;
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!AS.isPlaying)
        {
            if (CurrentClipPlaying == Playing.Length)
            {
                CurrentClipPlaying = 0;
            }

            if (Playing[CurrentClipPlaying])
            {
                AS.clip = ClipsToPlay[CurrentClipPlaying];
                AS.Play();
            }
        }
    }
    
}
