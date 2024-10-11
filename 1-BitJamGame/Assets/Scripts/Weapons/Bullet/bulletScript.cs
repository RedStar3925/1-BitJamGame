using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float lifetime = 3f;
    Rigidbody2D rb;
    
    
    void Start()
    {
        //CoinManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        Destroy(gameObject, lifetime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }  
}
