using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public MusicPlayer MP;

    public Image button;

    public bool active;
    
    void Start()
    {
        Playing = new bool[AmountOfClips];
        for (int i = 0; i < AmountOfClips; i++)
        {
            Playing[i] = false;
        }
        CurrentClipPlaying = -1;
        AS = GetComponent<AudioSource>();
        MP = FindObjectOfType<MusicPlayer>();
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
                if (CurrentClipPlaying != 0)
                {
                    if (Playing[CurrentClipPlaying] != Playing[CurrentClipPlaying - 1])
                    {
                        MP.TracksActive++;
                    }
                }
                else
                {
                    if (Playing[CurrentClipPlaying] != Playing[Playing.Length-1])
                    {
                        MP.TracksActive++;
                    }
                }
                AS.Play();
            }
            //if the clip is off, play silence.
            else
            {
                AS.clip = Silence;
                if (CurrentClipPlaying != 0)
                {
                    if (Playing[CurrentClipPlaying] != Playing[CurrentClipPlaying - 1])
                    {
                        MP.TracksActive--;
                    }
                }
                else
                {
                    if (Playing[CurrentClipPlaying] != Playing[Playing.Length-1])
                    {
                        MP.TracksActive--;
                    }
                }
                AS.Play();
            }
        }
    }

    public void ChangeSprite()
    {
        int count = 0;

        foreach (bool bug in Playing)
        {
            if (bug)
            {
                count++;
            }
        }

        if (count != 0)
        {
            button.color = Color.white;
        }
        else
        {
            button.color = new Color(0.7f,0.7f,0.7f);
        }
    }

    public void ImmediateStop()
    {
        AS.clip = Silence;
        AS.Stop();
    }
    public void ImmediatePlay()
    {
        AS.clip = Sound;
        AS.Play();
    }
}
