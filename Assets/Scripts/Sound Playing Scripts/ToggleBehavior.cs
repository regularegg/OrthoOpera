using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBehavior : MonoBehaviour
{
    /*
     
    ////////////////////////////////////////INSTRUCTIONS////////////////////////////////////////
    
    PURPOSE: Toggles the weather conditions
    HOW IT WORKS: Makes a button act like a toggle. When clicked, it will tell the SceneManager to change the weather 
                  condition that it is responsible for.
    USEAGE: 1. Put it on a Toggle Button.
            2. Set the Image toggle to itself
            3. Set the toggleLeft to the sprite that shows the toggle left position and do the same for ToggleRight
            4. Go into the button component and set OnClick() to this script's SwitchDataWeather() or SwitchDataTime().
            
            
    */ 
    
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

    public bool DayController;
    // Start is called before the first frame update
    void Start()
    {
        toggleL = startToggle;
        SM = FindObjectOfType<SceneManager>();
        if (DayController)
        {
            toggleL = true;
        }
        
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
