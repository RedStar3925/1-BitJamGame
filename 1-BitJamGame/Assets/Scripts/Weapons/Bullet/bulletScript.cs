using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public LogicScript CoinManager;
    public float lifetime = 3f;
    Rigidbody2D rb;
    
    
    void Start()
    {
        //CoinManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
            //  Destroy(gameObject, lifetime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Bullet Collision");
        if (collision.gameObject.tag == "Ennemy")
        {
          
            //CoinManager.AddCoin();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
  
    
}
