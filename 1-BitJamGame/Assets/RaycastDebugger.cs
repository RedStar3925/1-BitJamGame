using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class RaycastDebugger : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = Input.mousePosition;

            // Liste pour stocker tous les résultats de raycast
            List<RaycastResult> results = new List<RaycastResult>();

            // Lancer le raycast et remplir la liste
            EventSystem.current.RaycastAll(pointerData, results);

            // Afficher les objets touchés par le raycast
            foreach (RaycastResult result in results)
            {
                Debug.Log("Raycast hit: " + result.gameObject.name);
            }
        }
    }
}
