using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatsSO", menuName = "ScriptableObjects/EnemyStatsSO")]
public class EnemyPrefabsSO : ScriptableObject{
    private List<GameObject> enemyPrefabs;

    public GameObject GetRandomEnemyPrefab(){
        return enemyPrefabs.GetRandom();
    }
}
