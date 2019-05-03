using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMainScreen : MonoBehaviour
{
    public SceneManager SM;
    public GameObject Cam;
    
    void Start()
    {
        SM = FindObjectOfType<SceneManager>();
    }

    public void ReturnToMusicPlayer()
    {
        StartCoroutine(MoveCamera());
    }
    
    IEnumerator MoveCamera()
    {
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        float count = 0;
        while (count < 1)
        {
            Cam.transform.position = Vector3.Lerp( SM.Camera_InfoScreen, SM.Camera_MusicPlayerScreen,count);
            count+=0.01f;
            yield return wait;
        }
    }
}
