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
    
    private bool _day;
    public bool day
    {
        get { return _day; }
        set
        {
            //Tell music player to change day/night
            
            MP.Daytime = value;
            //Change bg to day/night
            if (value)
            {
                if (rain)
                {
                    skySR.sprite = dayRainBG;
                }
                else
                {
                    skySR.sprite = dayNoRainBG;
                }
            }
            else
            {
                if (rain)
                {
                    skySR.sprite = nightNoRainBG;
                }
                else
                {
                    skySR.sprite = nightRainBG;
                }
            }
            _day = value;
        }
    }
    
    private bool _rain;
    public bool rain
    {
        get { return _rain; }
        set
        {
            //Tell Music Player to change Rain 
            MP.Raining = value;
            
            //Change bg to day/night
            if (value)
            {
                if (day)
                {
                    skySR.sprite = dayRainBG;
                }
                else
                {
                    skySR.sprite = nightNoRainBG;
                }
            }
            else
            {
                if (day)
                {
                    skySR.sprite = dayNoRainBG;
                }
                else
                {
                    skySR.sprite = nightRainBG;
                }
            }

            _rain = value;
        }
    }

    public Sprite dayRainBG, dayNoRainBG, nightRainBG, nightNoRainBG;

    public SpriteRenderer skySR;

    
    // Start is called before the first frame update
    void Start()
    {
        day = true;
        rain = false;

        MP = GetComponent<MusicPlayer>();
    }
    
    
    
}
