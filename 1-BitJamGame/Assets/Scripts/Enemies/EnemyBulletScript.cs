using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    
    public float damage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // delete bullet if Off screen 
        Renderer renderer = GetComponent<Renderer>();

        if (renderer.isVisible == false)
        {
           // Debug.Log(transform.position + "  non visible ");
            Destroy(this.gameObject);
        }
        else if (renderer.isVisible)
        {
          //  Debug.Log("est visible");
        }
    }

    public void Init(float dmg)
    {
        damage = dmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Damage the player
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.PlayerTakingDamage(damage);
            }

            Destroy(this.gameObject);
        }
    }
}
