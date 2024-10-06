using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public bool waveIsOn = false ;

    public static WaveScript instance;
    private void Awake()
    {
        if (instance != null)
        { Debug.LogWarning("careful more than one instance of WaveScript"); return; }
        instance = this;
    }

    public void SpawnWawe(float wavePoint)
    {
        float totalPoint = 0;
        waveIsOn = true;
        while (totalPoint < wavePoint)
        {
            spawnEnemies.instance.SpawnEnemy(spawnEnemies.instance.ChooseRdmScriptabl());
        }

    }

}
