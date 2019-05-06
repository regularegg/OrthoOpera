using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HolderBehavior : MonoBehaviour
{
    /*
         ////////////////////////////////////////INSTRUCTIONS////////////////////////////////////////

    PURPOSE: A button that turns each segment of audio on and off. Also changes the sprite of that
             segment to reflect on/off state.
    HOW IT WORKS: When clicked, it will tell the IndividualAudioPlayer that it reports to whether or not 
                  it this chunk of audio is on or off.
    USAGE:  1. Put it on a button object on the canvas. 
            2. Drag the IndividualAudioPlayer that it responds to into IAP.
            3. Then go into the button component and set OnClick() to this script's ChangeStatus().
            
    */
    
    
    public IndividualAudioPlayer IAP;     //The IndividualAudioPlayer that it reports to
    public int bugArrayIndex;             //The index of the soundclip that it turns on and off

    private bool _play;                   //Whether or not the insect sound should be played
    public bool Play
    {
        get { return _play; }
        set
        {
            if (value)
            {
                img.sprite = playing;
            }
            else
            {
                img.sprite = notPlaying;
            }
            _play = value;
        }
    }
    
    public bool eightseconds;

    public Image img;                    //The sprite renderer/image renderer
    public Sprite playing, notPlaying;   //The two different sprites for each state
    
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    public void ChangeStatus()
    {
        Play = !Play;
        IAP.Playing[bugArrayIndex] = Play;
        if (eightseconds)
        {
            if (Play)
            {
                IAP.ImmediatePlay();
            }
            else
            {
                IAP.ImmediateStop();
            }
        }
        IAP.ChangeSprite();
    }
}
