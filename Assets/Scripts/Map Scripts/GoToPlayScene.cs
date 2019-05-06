using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPlayScene : MonoBehaviour
{

    public void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayScene");
    }
    
    public void ReturnToWorld()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WorldSelection");
    }
}
