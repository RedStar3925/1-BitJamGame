using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemyBase;
    [SerializeField] Transform[] transformsSpawn; 

    public float cdSpawnEnemy;
    [SerializeField] List<EnemyScriptableObject> allTypeOfEnemies;
    public enum EnemyBehavior { moveOnLand, stayOnLand, moveOnWater}

    public GameObject player;
    public static spawnEnemies instance;
    private void Awake()
    {
        if (instance != null)
        { Debug.LogWarning("careful more than one instance of SpawnEnemies"); return; }
        instance = this;
    }

    public void SpawnEnemy(EnemyScriptableObject enemyScripObj) // call this will spawn a ennemy then it will launch a timer before recall this methode 
    {
        GameObject enemy = Instantiate(enemyBase, transformsSpawn[0]);
        BasicEnemieScript basicEnemieScript = enemy.GetComponent<BasicEnemieScript>();
        basicEnemieScript.enemyType = enemyScripObj;
        
        switch (enemyScripObj.enemyBehavior)
        {
            case EnemyBehavior.stayOnLand:

                System.Random random = new System.Random();
                int a = random.Next(0, transformsSpawn.Length); // chose where the enemy will spawn
                enemy.transform.SetParent(transformsSpawn[a]);

                
                // add a random range for the enemy spawn 
                float transY = Random.Range(-0.5f, 0.5f);
               // Debug.Log(transY);
                Vector2 startingPosition = enemy.GetComponent<Transform>().position;
                startingPosition.y = transformsSpawn[a].position.y + transY;

                enemy.GetComponent<Transform>().position = startingPosition;
                break;

            case EnemyBehavior.moveOnLand:

                break;

            case EnemyBehavior.moveOnWater:

                break;

        }
        basicEnemieScript.Init();
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
        SpawnEnemy(ChooseRdmScriptabl());

    }


    private EnemyScriptableObject ChooseRdmScriptabl()
    {
        System.Random random = new System.Random();
        int a = random.Next(0, allTypeOfEnemies.Count );

        return allTypeOfEnemies[a];

    }

    void Start()
    {
        SpawnEnemy(allTypeOfEnemies[0]);
    }

}
