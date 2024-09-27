using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemyBase;
    [SerializeField] Transform[] transformsSpawn; 

    public float cdSpawnEnemy;
    public void SpawnEnemyOnLand() // call this will spawn a ennemy then it will launch a timer before recall this methode 
    {
        System.Random random = new System.Random();
        int a = random.Next(0, transformsSpawn.Length); // chose where the enemy will spawn
        GameObject enemy = Instantiate(enemyBase, transformsSpawn[a]);
        
        // add a random range for the enemy spawn 
        float TransY = Random.Range(-0.5f, 0.5f);
        Debug.Log(TransY);
        Vector2 startingPosition = enemy.GetComponent<Transform>().position;
        startingPosition.y = transformsSpawn[a].position.y + TransY;

        enemy.GetComponent<Transform>().position = startingPosition;
        
        
        StartCoroutine(StartCooldownSpawn());
    }


    IEnumerator StartCooldownSpawn() // spawn timer 
    {
        float cdRemaning = cdSpawnEnemy;
        while (cdRemaning > 0)
        {
            yield return null;
            cdRemaning -= Time.deltaTime;
        }
        SpawnEnemyOnLand();

    }
    void Start()
    {
        SpawnEnemyOnLand();
    }

}
