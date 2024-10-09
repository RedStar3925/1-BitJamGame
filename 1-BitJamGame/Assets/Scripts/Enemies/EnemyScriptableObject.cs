using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyType", menuName = "ScriptableObject/EnemyType")]
public class EnemyScriptableObject : ScriptableObject
{
    public string enemyName;
    public spawnEnemies.EnemyBehavior enemyBehavior;

    public Sprite enemySprite;
    public float health;

    public float speed, fireRange, fireRate, damage, chanceToSpawn, costPoint;
    public int goldGain;
    public bool selfDestruction = false;
    
}
