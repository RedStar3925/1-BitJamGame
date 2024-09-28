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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(scrollingDirection.normalized * Time.deltaTime * scrollingSpeed, Space.World);
    }

    public void Init()
    {
        life = enemyType.health;
        if (enemyType.enemySprite != null)
        {
            enemyRenderer.sprite = enemyType.enemySprite;
        }

    }
}
