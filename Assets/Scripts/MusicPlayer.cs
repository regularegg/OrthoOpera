using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //Say thing that it's attached to, and how it functions
    
    //Loops through time and plays each sound that is within that time


    public GameObject playerIndicator;

    public Vector3 startPos, endPos;

    public bool Raining;

    public bool Daytime;

    public bool[] tracks;

    //Tracks to store audio clips
    public int amountOfTracks; 
    public AudioClip[] DayRain;
    public AudioClip[] DayNoRain;
    public AudioClip[] NightRain;
    public AudioClip[] NightNoRain;

    private AudioClip[] CurrentlyPlaying;
    
    //value of on/off for each insect
    public bool[] Insect0;
    public bool[] Insect1;
    public bool[] Insect2;
    public bool[] Insect3;

    
    public int Insect0_amount, Insect1_amount, Insect2_amount, Insect3_amount;
    private AudioClip tester;

    public AudioSource[] AudioTracks;

    public float loopTime = 0;

    public AudioSource[] insects;

    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Insect0 = new bool[Insect0_amount];
        Insect1 = new bool[Insect1_amount];
        Insect2 = new bool[Insect2_amount];
        Insect3 = new bool[Insect3_amount];
        //enable all tracks by default
        for (int i = 0; i < amountOfTracks; i++)
        {
            //sets the current clip to play to "Day No Rain"
            tracks[i] = true;
            AudioTracks[i].clip = DayNoRain[i];
            AudioTracks[i].Play();
            if (loopTime < DayNoRain[i].length)
            {
                loopTime = DayNoRain[i].length;
            }
        }

        
        for (int i = 0; i < Insect0_amount; i++)
        {
            Insect0[i] = false;
        }
        for (int i = 0; i < Insect1_amount; i++)
        {
            Insect0[i] = false;
        }
        for (int i = 0; i < Insect2_amount; i++)
        {
            Insect0[i] = false;
        }
        for (int i = 0; i < Insect3_amount; i++)
        {
            Insect0[i] = false;
        }
        //Saves the starting position of the playhead
        startPos = playerIndicator.transform.position;
        
        Daytime = true;
        Raining = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves playhead
        playerIndicator.transform.position += Vector3.right * speed;
        if (playerIndicator.transform.position.x > endPos.x)
        {
            playerIndicator.transform.position = startPos;
            PlaySound();
        }

        //Change the array of tracks to be palying
        if (Raining)
        {
            if (Daytime)
            {
                CurrentlyPlaying = DayRain;
            }
            else
            {
                CurrentlyPlaying = NightRain;
            }
        }
        else
        {
            if (Daytime)
            {
                CurrentlyPlaying = DayNoRain;
            }
            else
            {
                CurrentlyPlaying = NightNoRain;
            }
            
        }
        
    }

    IEnumerator PlaySounds()
    {
        WaitForSeconds wait = new WaitForSeconds(loopTime);
        while (true)
        {
            for (int i = 0; i < amountOfTracks; i++)
            {
                AudioTracks[i].Play();
            }

            yield return wait;
        }
    }
    
    void ChangeSound()
    {
        for (int i = 0; i < insects.Length; i++)
        {
            
        }
    }

    void PlaySound()
    {
        for (int i = 0; i < amountOfTracks; i++)
        {
            AudioTracks[i].Play();
        }
    }
}
