using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryPlacer : MonoBehaviour
{
    public GameObject sentryPrefab;


    void Update()
    {
        Debug.Log("Update Callded");
        if(Input.GetMouseButtonDown(0))
        {
            PlaceSentryInFront();
        }
    }  
    
    Vector3 MousePosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;

        mouseScreenPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseScreenPosition.z = 0;

        return mouseScreenPosition;
    }

    void PlaceSentryInFront()
    {
        Vector2 mousePosition = MousePosition();
        Instantiate(sentryPrefab, mousePosition, Quaternion.identity);
    }
}
