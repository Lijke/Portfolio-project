using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPrefabsSO", menuName = "ScriptableObjects/EnemyPrefabsSO")]
public class EnemyPrefabsSO : ScriptableObject{
    public List<GameObject> enemyPrefabs;

    public GameObject GetRandomEnemyPrefab(){
        return enemyPrefabs.GetRandom();
    }
}
