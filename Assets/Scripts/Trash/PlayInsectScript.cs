using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInsectScript : MonoBehaviour
{
    //Purpose: 
    //
    //How it Works:

    public AudioSource AS;
    public AudioClip[] ClipsToPlay;

    private int currentPlayIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        currentPlayIndex = 0;
    }

    private IEnumerator PlayAudioSequence()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();

        while (AS.isPlaying)
        {
            yield return null;
        }

        if (currentPlayIndex < ClipsToPlay.Length-1)
        {
            currentPlayIndex++;
        }
        else if (currentPlayIndex == ClipsToPlay.Length - 1)
        {
            currentPlayIndex = 0;
        }
    }
}
