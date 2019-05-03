using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    /*
         ////////////////////////////////////////INSTRUCTIONS////////////////////////////////////////

    PURPOSE: Keeps track of the states of the scene. Tells Music player when states change.
    HOW IT WORKS: 
    USAGE: 
    */

    public Vector3 Camera_MusicPlayerScreen, Camera_InfoScreen;
    public MusicPlayer MP;

    public bool day_debug, rain_debug;
    
    private bool _day;
    public bool day
    {
        get { return _day; }
        set
        {
            //Tell music player to change day/night
            
            day_debug = value;
            MP.Daytime = value;
            _day = value;
            ChangeBackground();
        }
    }
    
    private bool _rain;
    public bool rain
    {
        get { return _rain; }
        set
        {
            
            rain_debug = value;
            //Tell Music Player to change Rain 
            MP.Raining = value;
            _rain = value;
            
            ChangeBackground();
        }
    }

    public Sprite dayRainBG, dayNoRainBG, nightRainBG, nightNoRainBG;

    public SpriteRenderer skySR;

    
    // Start is called before the first frame update
    void Start()
    {
        day = true;
        rain = false;

        day_debug = day;
        rain_debug = rain;
        
        MP = GetComponent<MusicPlayer>();
    }

    void ChangeBackground()
    {
        if (_day && _rain)
        {
            skySR.sprite = dayRainBG;
        }
        else if (_day && !_rain)
        {
            skySR.sprite = dayNoRainBG;
        }
        else if (!_day && _rain)
        {
            skySR.sprite = nightRainBG;
        }
        else if (!_day && !_rain)
        {
            skySR.sprite = nightNoRainBG;
        }
    }
    
    
    
}
