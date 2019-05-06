using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    
    //Amount of insect tracks that we have
    public int AmountOfInsects;
    
    //Individual AudioPlayers that it keeps track of
    public IndividualAudioPlayer[] AudioPlayers;
    public BackgroundSoundPlayer BSP;

    //Tracks to store audio clips
    public AudioClip[] DayRain;
    public AudioClip[] DayNoRain;
    public AudioClip[] NightRain;
    public AudioClip[] NightNoRain;
    public AudioClip[] BackgroundSounds;

    
    //Insect sprites and corresponding texts for info box
    public Sprite[] InsectTypes;
    public Sprite[] InsectText;
    public SpriteRenderer[] InsectType_SR;
    public SpriteRenderer[] InsectText_SR;
    
    //Weather condition booleans
    private bool _Raining;
    public bool Raining
    {
        get { return _Raining; }
        set
        {
            _Raining = value;
            ChangeSound();
        }
    }
    private bool _Daytime;
    public bool Daytime
    
    {
        get { return _Daytime; }
        set
        {
            _Daytime = value;
            ChangeSound();
        }
    }

    //Audio Stuff
    public AudioMixer AM;
    
    public float modifier = 0.05f;
    public float baseVol = 1f;
    
    private int _TracksActive;
    public int TracksActive
    
    {
        get { return _TracksActive; }
        set
        {
            Debug.Log("Tracks active " + value);
            _TracksActive = value;
            ChangeVolume(value);
        }
    }
    
    //TESTING PURPOSES:
    public bool[] testerBools;
    
    
    void Start()
    {
        //Saves the starting position of the playhead
        startPos = playerIndicator.transform.position;
        TracksActive = 0;
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
        if (_Daytime && _Raining)
        {
            clips = DayRain;
            BSP.Sound = BackgroundSounds[0];
        }
        else if (_Daytime && !_Raining)
        {
            clips = DayNoRain;
            BSP.Sound = BackgroundSounds[1];
        }
        else if (!_Daytime && _Raining)
        {
            clips = NightRain;
            BSP.Sound = BackgroundSounds[2];
            testerBools[2] = true;
        }
        else if (!_Daytime && !_Raining)
        {
            clips = NightNoRain;
            BSP.Sound = BackgroundSounds[3];
            testerBools[3] = true;
        }
        
        /*
        //Changes the audio for each type of insect
        for (int i = 0; i < AudioPlayers.Length; i++)
        {
            AudioPlayers[i].Sound = clips[i];
        }*/
    }

    public void ChangeVolume(int amount)
    {
        Debug.Log("Change volume " + (baseVol-(amount * modifier)));
        AM.SetFloat("MyVolume", baseVol-(amount * modifier));
    }
}
