using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnObject : MonoBehaviour
{

    public bool selecting = false;
    public Transform beingDragged;
    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButton (0)){ 
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            
            if (hit) {
                if (hit.transform.CompareTag("Beetle"))
                {
                    selecting = true;
                    beingDragged = hit.transform;
                    hit.transform.SetParent(null);
                    hit.transform.GetComponent<Bug>().beingDragged = true;
                }
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selecting = false;
            beingDragged.GetComponent<Bug>().beingDragged = false;
        }

        if (selecting)
        {
            Vector3 pos = new Vector3(
                Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 
                10);;
            beingDragged.transform.position = pos;
        }
    }
    
}
