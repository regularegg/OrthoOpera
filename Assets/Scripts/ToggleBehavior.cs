using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBehavior : MonoBehaviour
{
    //Purpose: Controls the toggle for 
    //How it works:  
    
    public SceneManager SM;

    public Image toggle;
    public Sprite toggleLeft, toggleRight;

    private bool _toggleL;

    public bool startToggle;
    public bool toggleL
    {
        get { return _toggleL; }
        set
        {
            if (value)
            {
                toggle.sprite = toggleLeft;
            }
            else
            {
                toggle.sprite = toggleRight;
            }
            _toggleL = value;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        toggleL = startToggle;
        SM = FindObjectOfType<SceneManager>();
    }

    public void SwitchDataTime()
    {
        SM.day = !SM.day;
        toggleL = !toggleL;
    }

    public void SwitchDataWeather()
    {
        SM.rain = !SM.rain;
        toggleL = !toggleL;
    }
}
