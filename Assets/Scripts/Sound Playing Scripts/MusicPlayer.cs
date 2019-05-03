using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    /*
     
    ////////////////////////////////////////INSTRUCTIONS////////////////////////////////////////
    
    PURPOSE: Keeps track of each which type of audio to play, depending on the weather conditions.
             It also loops the play head.
    HOW IT WORKS: When SceneManager changes the conditions of the environment, it 
                  gives each IndividualAudioPlayer the correct type of audio to play.
    USEAGE: 1. Put it on a game manager.
            2. Drag the audio clips for each sound into the corresponding AudioClip array
            3. Drag the corresponding IndividualAudioPlayer into the AudioPlayers array.
            
            
    */

    //Playhead object components
    public GameObject playerIndicator;
    public Vector3 startPos, endPos;
    public float speed = 0.5f;

    //Weather condition booleans
    private bool _Raining;
    public bool Raining
    {
        get { return _Raining; }
        set
        {
            ChangeSound();
            _Raining = value;
        }
    }
    private bool _Daytime;
    public bool Daytime
    
    {
        get { return _Daytime; }
        set
        {
            ChangeSound();
            _Daytime = value;
        }
    }

    //Amount of insect tracks that we have
    public int AmountOfInsects;
    
    //Individual AudioPlayers that it keeps track of
    public IndividualAudioPlayer[] AudioPlayers;

    //Tracks to store audio clips
    public AudioClip[] DayRain;
    public AudioClip[] DayNoRain;
    public AudioClip[] NightRain;
    public AudioClip[] NightNoRain;

    
    //TESTING PURPOSES:
    public bool TESTING_MODE;
    private AudioClip tester;

    public int amountOfTracks; 
    public AudioSource[] AudioTracks;

    public float loopTime = 0;

    public AudioSource[] insects;

    
    
    void Start()
    {
        //Array of bools that tell you whether each chunk of insect is playing sound or silence
        //enable all tracks by default
        if (TESTING_MODE)
        {
            for (int i = 0; i < amountOfTracks; i++)
            {
                //sets the current clip to play to "Day No Rain"
                AudioTracks[i].clip = DayNoRain[i];
                AudioTracks[i].Play();
                if (loopTime < DayNoRain[i].length)
                {
                    loopTime = DayNoRain[i].length;
                }
            }
        }

        //Saves the starting position of the playhead
        startPos = playerIndicator.transform.position;
        
        Daytime = true;
        Raining = false;
    }

    
    
    void Update()
    {
        //Moves playhead
        playerIndicator.transform.position += Vector3.right * speed;
        if (playerIndicator.transform.position.x > endPos.x)
        {
            playerIndicator.transform.position = startPos;
            PlaySound();
        }
    }
    
    void ChangeSound()
    {
        //Temporary holder clip
        AudioClip[] clips = new AudioClip[AmountOfInsects];
        
        //Determines which type of audio clip to play
        if (Daytime && Raining)
        {
            clips = DayRain;
        }
        else if (Daytime && !Raining)
        {
            clips = DayNoRain;
        }
        else if (!Daytime && Raining)
        {
            clips = NightRain;
        }
        else if (!Daytime && Raining)
        {
            clips = NightNoRain;
        }
        
        //Changes the audio for each type of insect
        for (int i = 0; i < insects.Length; i++)
        {
            AudioPlayers[i].Sound = clips[i];
        }
    }

    //TESTING PURPOSES
    void PlaySound()
    {
        for (int i = 0; i < amountOfTracks; i++)
        {
            AudioTracks[i].Play();
        }
    }
}
