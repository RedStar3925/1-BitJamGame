using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemyBase;
    [SerializeField] Transform[] transSpawnStatic, transSpawnGround, transSpawnWater; 

    public float cdSpawnEnemy;
    [SerializeField] List<EnemyScriptableObject> allTypeOfEnemies;
    public enum EnemyBehavior { moveOnLand, stayOnLand, moveOnWater}



    public Transform topGroundLimit, botGroundLimit;
    [SerializeField] float totalChanceToSpawn;

    public GameObject player;
    public static spawnEnemies instance;
    private void Awake()
    {
        if (instance != null)
        { Debug.LogWarning("careful more than one instance of SpawnEnemies"); return; }
        instance = this;
    }

    public GameObject SpawnEnemy(EnemyScriptableObject enemyScripObj) // call this will spawn a ennemy then it will launch a timer before recall this methode 
    {
        if (WaveScript.instance.waveIsOn)
        {
            GameObject enemy = Instantiate(enemyBase);
            BasicEnemieScript basicEnemieScript = enemy.GetComponent<BasicEnemieScript>();
            basicEnemieScript.enemyType = enemyScripObj;

            System.Random random = new System.Random();
            switch (enemyScripObj.enemyBehavior)
            {


                case EnemyBehavior.stayOnLand:

                    int a = random.Next(0, transSpawnStatic.Length); // chose where the enemy will spawn
                    enemy.transform.SetParent(transSpawnStatic[a]);


                    // add a random range for the enemy spawn 
                    float transY = Random.Range(-0.5f, 0.5f);

                    enemy.transform.position = transSpawnStatic[a].position;
                    // Debug.Log(transY);
                    Vector2 startingPosition = enemy.transform.position;
                    startingPosition.y = transSpawnStatic[a].position.y + transY;

                    enemy.GetComponent<Transform>().position = startingPosition;
                    break;

                case EnemyBehavior.moveOnLand:
                    a = random.Next(0, transSpawnGround.Length); // chose where the enemy will spawn
                    enemy.transform.SetParent(transSpawnGround[a]);
                    //Debug.Log(transSpawnGround[a]);

                    // add a random range for the enemy spawn 
                    float transX = Random.Range(-5f, 5f);

                    enemy.transform.position = transSpawnGround[a].position;
                    // Debug.Log(transY);
                    Vector2 startingPositionGround = enemy.transform.position;
                    startingPositionGround.x = transSpawnGround[a].position.x + transX;

                    enemy.GetComponent<Transform>().position = startingPositionGround;
                    break;

                case EnemyBehavior.moveOnWater:
                    a = random.Next(0, transSpawnWater.Length); // chose where the enemy will spawn
                    enemy.transform.SetParent(transSpawnWater[a]);
                    //Debug.Log(transSpawnGround[a]);

                    // add a random range for the enemy spawn 
                    float transYwater = Random.Range(botGroundLimit.position.y + 0.5f, topGroundLimit.position.y - 0.5f); // chose a Y position on water for make the spawn 
                                                                                                                          //Debug.Log(transYwater);
                    enemy.transform.position = transSpawnWater[a].position;
                    // Debug.Log(transY);
                    Vector2 startingPositionWater = enemy.transform.position;
                    startingPositionWater.y = transSpawnWater[a].position.y + transYwater;

                    enemy.GetComponent<Transform>().position = startingPositionWater;
                    break;

            }

            basicEnemieScript.Init();
            
            //StartCoroutine(StartCooldownSpawn());
            return enemy;
        }
        else
        {
            return null;
        }
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

    //private EnemyScriptableObject ChooseRdmScriptabl()
    //{
    //    System.Random random = new System.Random();
    //    int a = random.Next(0, allTypeOfEnemies.Count );

    //    return allTypeOfEnemies[a];

    //}

    public EnemyScriptableObject ChooseRdmScriptabl() 
    {
        
        float a = Random.Range(1, totalChanceToSpawn);
        float totalCheck = 0;
        for (int i = 0; i < allTypeOfEnemies.Count; i++)
        {
            if (allTypeOfEnemies[i].chanceToSpawn + totalCheck >= a)
            {
                //Debug.Log(a + " " + allTypeOfEnemies[i]);
                return allTypeOfEnemies[i];
            }
            totalCheck += allTypeOfEnemies[i].chanceToSpawn;
        }
        return null;

    }

    private void PlaceAllSpawn()
    {
        Camera camera = Camera.main;
        Vector2 midleTop = camera.ViewportToWorldPoint(new Vector2(0.5f, 1.2f));
        transSpawnGround[0].position = midleTop;

        Vector2 midleBot = camera.ViewportToWorldPoint(new Vector2(0.5f, -0.2f));
        transSpawnGround[1].position = midleBot;

        Vector2 RightTop = camera.ViewportToWorldPoint(new Vector2(1.2f, 0.9f));
        transSpawnStatic[0].position = RightTop;

        Vector2 RightBot = camera.ViewportToWorldPoint(new Vector2(1.2f, 0.1f));
        transSpawnStatic[1].position = RightBot;

        Vector2 RightMidle = camera.ViewportToWorldPoint(new Vector2(1.2f, 0.5f));
        transSpawnWater[0].position = RightMidle;
    }

    private void MaxChanceTospawn()
    {
        foreach (EnemyScriptableObject item in allTypeOfEnemies)
        {
            totalChanceToSpawn += item.chanceToSpawn;
        }
    }

    void Start()
    {
        MaxChanceTospawn();
        
        //SpawnEnemy(allTypeOfEnemies[0]);
        PlaceAllSpawn();
    }

}
