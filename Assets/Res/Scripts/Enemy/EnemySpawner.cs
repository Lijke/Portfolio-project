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
    public FirstPersonController player;
    public EnemySpawner Instance;

    private void Awake(){
        Instance = this;
    }

    private void Start(){
        player = FirstPersonController.Instance;
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
        spawnedPrefab.transform.position = GetSpawnPositino();
        pooledObjects.Add(spawnedPrefab);
    }

    private Vector3 GetSpawnPositino(){
        var playerPos = player.transform.position;
        var distanceFromPlayer = spawnerStatsSo.distanceFromPlayer;
        return player.transform.position + (UnityEngine.Random.insideUnitSphere * distanceFromPlayer);
    }

    public GameObject GetPooledObject(){
        return pooledObjects.First(x => !x.activeInHierarchy);
    }
    
}
