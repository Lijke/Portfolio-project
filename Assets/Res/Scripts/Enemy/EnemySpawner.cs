using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using StarterAssets;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public EnemyPrefabsSO enemyPrefabsSo;
    public SpawnerStatsSO spawnerStatsSo;
    public List<GameObject> pooledObjects;
    public FirstPersonController player => FirstPersonController.Instance;

    private void Awake(){
        for (int i = 0; i < spawnerStatsSo.maxEnemyCount; i++){
            var singleEnemyPrefab = enemyPrefabsSo.GetRandomEnemyPrefab();
            SpawnEnemies(singleEnemyPrefab);
        }
    }

    public void SpawnEnemies(GameObject enemyPrefab){
        if (player == null){
            return;
        }

        var spawnedPrefab =Instantiate(enemyPrefab);
        pooledObjects.Add(spawnedPrefab);
    }

    public GameObject GetPooledObject(){
        return pooledObjects.First(x => !x.activeInHierarchy);
    }
    
}
