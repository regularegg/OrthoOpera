using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HolderBehavior : MonoBehaviour
{
    public MusicPlayer MP;
    public IndividualAudioPlayer IAP;

    public int bugType;
    public int bugArrayIndex;

    private bool _play;

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

    public Image img;
    public Sprite playing, notPlaying;
    
    // Start is called before the first frame update
    void Start()
    {
        MP = FindObjectOfType<MusicPlayer>();
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeStatus()
    {
        Play = !Play;
        IAP.Playing[bugArrayIndex] = Play;
        if (bugType == 0)
        {
            MP.Insect0[bugArrayIndex] = Play;
        }else if (bugType == 1)
        {
            MP.Insect1[bugArrayIndex] = Play;
        }else if (bugType == 2)
        {
            MP.Insect2[bugArrayIndex] = Play;
        }
        else
        {
            MP.Insect3[bugArrayIndex] = Play;
        }
    }
}
