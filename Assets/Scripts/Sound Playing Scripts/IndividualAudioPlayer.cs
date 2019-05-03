using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualAudioPlayer : MonoBehaviour
{
    //PURPOSE: Controls each individual type of insect audio player. 
    //HOW IT WORKS: It refers to the array of booleans to check if it should be palying sound or silence.
    //              It also keeps track of which index it is currently at.
    //USAGE: Put this on the background bar of each insect type. The background bar should have an audiosource attached to it.
    
    public AudioSource AS;
    public AudioClip Sound;
    public AudioClip Silence;
    
    public bool[] Playing;
    public int CurrentClipPlaying;

    public int AmountOfClips;
    
    void Start()
    {
        Playing = new bool[AmountOfClips];
        for (int i = 0; i < AmountOfClips; i++)
        {
            Playing[i] = false;
        }
        CurrentClipPlaying = 0;
        AS = GetComponent<AudioSource>();
    }

    void Update()
    {
        //If the audioclip is still playing, do nothing.
        
        //If the audioclip is done playing, increment the index and play the next clip.
        if (!AS.isPlaying)
        {
            //STEP 1.
            //if the current clip is the last clip in the array, restart the index to 0
            if (CurrentClipPlaying == AmountOfClips-1)
            {
                CurrentClipPlaying = 0;
            }
            //Otherwise, just increment the clip index by 1
            else
            {
                CurrentClipPlaying++;
            }

            //STEP 2.
            //if the current clip is on, play the sound.
            if (Playing[CurrentClipPlaying])
            {
                AS.clip = Sound;
                AS.Play();
            }
            //if the clip is off, play silence.
            else
            {
                AS.clip = Silence;
                AS.Play();
            }
        }
    }
    
}
