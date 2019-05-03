using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToInfobox : MonoBehaviour
{
    /*
         ////////////////////////////////////////INSTRUCTIONS////////////////////////////////////////

    PURPOSE: Moves the camera from music player screen to the info box screen
    HOW IT WORKS: When clicked, this lerps the camera to the info box screen. It also calls the ChangeInfo script
                  to change the information about which bug is clicked.
                  It also keeps the information about this insect.
    USAGE: 1. Put this on each bug button.
           2. Set the Sprite to be the sprite of the bug that it respresents
           3. Set the Bug_Name and Bug_Info to the information about this bug.
    
    */

    public SceneManager SM;
    public ChangeInfo CI;
    
    public Sprite Bug;
    public string BugName, BugInfo;
    public GameObject Cam;

    public bool LazyMove;

    void Start()
    {
        SM = FindObjectOfType<SceneManager>();
    }

    public void ChangeScenePosition()
    {
        //Change the BugInfo screen to match the insect clicked
        CI.BugName.text = BugName;
        CI.BugInfo.text = BugInfo;
        if (LazyMove)
        {
            
            //Lazy Move
            Cam.transform.position = SM.Camera_InfoScreen;

        }
        else
        {
            //Lerp Camera to position move
            StartCoroutine(MoveCamera());
        }
        
    }

    IEnumerator MoveCamera()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        float count = 0;
        while (count < 1)
        {
            Cam.transform.position = Vector3.Lerp(SM.Camera_MusicPlayerScreen, SM.Camera_InfoScreen, count);
            count+=0.01f;
            yield return wait;
        }
    }
}
