using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemieScript : MonoBehaviour
{
    public float life = 100f;
    public EnemyScriptableObject enemyType;
    [SerializeField] SpriteRenderer enemyRenderer;
    // Start is called before the first frame update
    [SerializeField] float scrollingSpeed = 1f; // speed should be equal to the scrolling speed 
    Vector2 scrollingDirection = new Vector2(-1f, 0f); //  <-- 

    private bool isAiming;
    private new Renderer renderer;
    [SerializeField] GameObject enemy, enemyBulletPrefab;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAiming)
        {
            MoveOnPlayer();
        }

        if (renderer.isVisible)
        {
            ShootAtPlayer();
        }
        
        
        transform.Translate(scrollingDirection.normalized * Time.deltaTime * scrollingSpeed, Space.World);
        CleanOffScreen();
    }

    public void Init()
    {
        life = enemyType.health;
        gameObject.name = enemyType.enemyName;
        if (enemyType.enemySprite != null)
        {
            enemyRenderer.sprite = enemyType.enemySprite;
            
        }

    }


    private void MoveOnPlayer()
    {
        if (enemyType.enemyBehavior == spawnEnemies.EnemyBehavior.moveOnLand || enemyType.enemyBehavior == spawnEnemies.EnemyBehavior.moveOnWater)
        {
            Vector2 dirToPlayer = (spawnEnemies.instance.player.transform.position - transform.position).normalized;
            
            transform.Translate(dirToPlayer.normalized * Time.deltaTime * enemyType.speed, Space.World);
        }

        //limit area
        if (enemyType.enemyBehavior == spawnEnemies.EnemyBehavior.moveOnLand)
        {
            //Debug.Log("check");
            if (transform.position.y < spawnEnemies.instance.topGroundLimit.position.y && transform.position.y > spawnEnemies.instance.botGroundLimit.position.y) // check if GroundEnemy is on ground 
            {
                //Debug.Log("est hors zone");
                if (Mathf.Abs( transform.position.y - spawnEnemies.instance.topGroundLimit.position.y) < Mathf.Abs( transform.position.y - spawnEnemies.instance.botGroundLimit.position.y)) // check where enemy is close of a ground and place it
                {
                    //Debug.Log("Top dis " + (transform.position.y - spawnEnemies.instance.topGroundLimit.position.y) + " bot dis " + (transform.position.y - spawnEnemies.instance.botGroundLimit.position.y));
                    //Debug.Log("replacement Top");
                    transform.position = new Vector2( transform.position.x ,spawnEnemies.instance.topGroundLimit.position.y) ;
                }
                else 
                {
                   // Debug.Log("replacement Bot");
                    transform.position = new Vector2(transform.position.x, spawnEnemies.instance.botGroundLimit.position.y);
                }
            }
        }
        else if (enemyType.enemyBehavior == spawnEnemies.EnemyBehavior.moveOnWater)
        {
            if (transform.position.y > spawnEnemies.instance.topGroundLimit.position.y || transform.position.y < spawnEnemies.instance.botGroundLimit.position.y) // check if GroundEnemy is on Water 
            {
                //Debug.Log("est hors zone");
                if (Mathf.Abs(transform.position.y - spawnEnemies.instance.topGroundLimit.position.y) < Mathf.Abs(transform.position.y - spawnEnemies.instance.botGroundLimit.position.y)) // check where enemy is close of a water and place it
                {
                    //Debug.Log("Top dis " + (transform.position.y - spawnEnemies.instance.topGroundLimit.position.y) + " bot dis " + (transform.position.y - spawnEnemies.instance.botGroundLimit.position.y));
                    //Debug.Log("replacement Top");
                    transform.position = new Vector2(transform.position.x, spawnEnemies.instance.topGroundLimit.position.y);
                }
                else
                {
                    //Debug.Log("replacement Bot");
                    transform.position = new Vector2(transform.position.x, spawnEnemies.instance.botGroundLimit.position.y);
                }
            }
        }
    }

    private void CleanOffScreen() // destroy enemy when they go to far away of the camera
    {
        Camera camera = Camera.main;
        Vector2 topLeft = camera.ViewportToWorldPoint(new Vector2(0, 1));
        if (transform.position.x <= (topLeft.x *1.2f))
        {
            WaveScript.instance.RemoveEnemy(gameObject);
        }
    }

    private void ShootAtPlayer()
    {
        float distance = Vector2.Distance(transform.position, spawnEnemies.instance.player.transform.position);
        if (enemyType.fireRange > distance && !isAiming)
        {
            StartCoroutine(StartAimingTimer());
        }
    }

    IEnumerator StartAimingTimer() 
    {
        isAiming = true;
        float cdRemaning = 1/ enemyType.fireRate;
        while (cdRemaning > 0)
        {
            yield return null;
            cdRemaning -= Time.deltaTime;
        }

        Vector2 direction = ( spawnEnemies.instance.player.transform.position - transform.position ).normalized;
        GameObject bullet = Instantiate(enemyBulletPrefab, transform);
        bullet.GetComponent<EnemyBulletScript>().damage = enemyType.damage; // apply the enemy damage to the bullet 
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f;
        isAiming = false;
    }

    public void EnemyTakeDamage(int dmg = 10)
    {
        life -= dmg;
        if (life <= 0)
        {
            // add a coin 
            WaveScript.instance.RemoveEnemy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            EnemyTakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
