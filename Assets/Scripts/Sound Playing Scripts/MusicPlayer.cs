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
    
    public bool[] testerBools;

    
    
    void Start()
    {

        //Saves the starting position of the playhead
        startPos = playerIndicator.transform.position;
    }

    
    
    void Update()
    {
        //Moves playhead
        playerIndicator.transform.position += Vector3.right * speed;
        if (playerIndicator.transform.position.x > endPos.x)
        {
            playerIndicator.transform.position = startPos;
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
            testerBools[0] = true;
        }
        else if (Daytime && !Raining)
        {
            clips = DayNoRain;
            testerBools[1] = true;
        }
        else if (!Daytime && Raining)
        {
            clips = NightRain;
            testerBools[2] = true;
        }
        else if (!Daytime && !Raining)
        {
            clips = NightNoRain;
            testerBools[3] = true;
        }
        
        //Changes the audio for each type of insect
        for (int i = 0; i < AudioPlayers.Length; i++)
        {
            Debug.Log(clips[i].name);
            AudioPlayers[i].Sound = clips[i];
        }
    }
}
