using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    //DOESN'T MATTER ANYMORE
    public bool beingDragged = false;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Holder") && other.transform.parent.CompareTag(tag))
        {
            Debug.Log("Matching holder!!!");
            
            transform.SetParent(other.transform);
            transform.localPosition = Vector3.zero;
            

        }
        Debug.Log("bug workin'");
    }

}
