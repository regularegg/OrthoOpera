using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private bool _day;
    public bool day
    {
        get { return _day; }
        set
        {
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

    public Animator rainAnim;

    public AudioClip[] InsectsRainDay;
    public AudioClip[] InsectsSunDay;
    public AudioClip[] InsectsRainNight;
    public AudioClip[] InsectsSunNight;

    
    // Start is called before the first frame update
    void Start()
    {
        day = true;
        rain = false;
    }
    
    
    
}
