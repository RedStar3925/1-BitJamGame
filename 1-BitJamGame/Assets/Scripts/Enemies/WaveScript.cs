using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public bool waveIsOn = false ;
    private bool isRdyToSpawn = false;
    public List<GameObject> enemiesWave;
    
    public static WaveScript instance;

    public int wavePower, scalingWavePower;

    private float totalPoint, wavePoint;
    private void Awake()
    {
        if (instance != null)
        { Debug.LogWarning("careful more than one instance of WaveScript"); return; }
        instance = this;
    }

    private void Start()
    {
        SpawnWave();
    }

    private void Update()
    {
        if (totalPoint < wavePoint && isRdyToSpawn && waveIsOn)
        {
            GameObject enemy = spawnEnemies.instance.SpawnEnemy(spawnEnemies.instance.ChooseRdmScriptabl());
            enemiesWave.Add(enemy);
            totalPoint += enemy.GetComponent<BasicEnemieScript>().enemyType.costPoint;
            //Debug.Log(totalPoint);

            StartCoroutine(StartCdSpawnWave());
        }

        ClearEnemyList();

        if (enemiesWave.Count <= 0 && totalPoint >= wavePoint && waveIsOn)
        {
            EndWave();
        }
    }

    public void ClearEnemyList()
    {
        for (int i = enemiesWave.Count - 1; i >= 0; i--)
        {
            if (enemiesWave[i] == null)
            {
                enemiesWave.RemoveAt(i);
            }
        }
    }

    public void SpawnWave()
    {
        wavePoint = wavePower;
        waveIsOn = true;
        isRdyToSpawn = true;
        wavePower += scalingWavePower;

    }

    IEnumerator StartCdSpawnWave()
    {
        isRdyToSpawn = false;

        yield return new WaitForSeconds(spawnEnemies.instance.cdSpawnEnemy);
        //float cdRemaning = spawnEnemies.instance.cdSpawnEnemy;
        //while (cdRemaning > 0)
        //{
        //    yield return null;
        //    cdRemaning -= Time.deltaTime;
        //}
        isRdyToSpawn = true;

    }

    public void RemoveEnemy(GameObject enemyToRemove)
    {
        if (enemyToRemove == null)
        {
            Debug.LogWarning("Enemy to remove is already null");
            return;
        }

        if (enemiesWave.Remove(enemyToRemove))
        {
            Destroy(enemyToRemove);
        }

        ClearEnemyList();


        if (enemiesWave.Count <= 0 && totalPoint >= wavePoint && waveIsOn)
        {
            EndWave();
        }
    }

    private void EndWave()
    {
        waveIsOn = false;
        totalPoint = 0;
        StartCoroutine(PeaceBeforeWave());
    }

    IEnumerator PeaceBeforeWave()
    {
        yield return new WaitForSeconds(5);
        SpawnWave();
    }



}
