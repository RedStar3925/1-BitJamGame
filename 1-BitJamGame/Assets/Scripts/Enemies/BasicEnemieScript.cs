using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemieScript : MonoBehaviour
{
    public float life = 100f;
    // Start is called before the first frame update
    [SerializeField] float speed = 1f; // speed should be equal to the scrolling speed 
    Vector2 direction = new Vector2(-1f, 0f); //  <-- 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction.normalized * Time.deltaTime * speed, Space.World);
    }
}
