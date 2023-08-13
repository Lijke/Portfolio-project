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
    public static EnemySpawner Instance;

    private void Awake(){
        Instance = this;
        GameEvents.Enemy.onEnemyDead += SpawnEnemy;
    }

    private void OnDestroy(){
        GameEvents.Enemy.onEnemyDead -= SpawnEnemy;
    }

    private void SpawnEnemy(){
        Debug.Log($"[Spawner] Spawn Dead Enemy");
        GetEnemyFromPool();
    }

    private void GetEnemyFromPool(){
        var prefab = GetPooledObject();
        if (prefab != null){
            prefab.SetActive(true);
            prefab.transform.position = GetSpawnPosition();
        }
    }

    private void Start(){
        player = FirstPersonController.Instance;
        for (int i = 0; i < spawnerStatsSo.maxEnemyCount; i++){
            var singleEnemyPrefab = GetEnemyPrefab();
            SpawnEnemies(singleEnemyPrefab);
        }
    }

    public GameObject GetEnemyPrefab(){
        return enemyPrefabsSo.GetRandomEnemyPrefab();
    }

    public void SpawnEnemies(GameObject enemyPrefab){
        if (player == null){
            return;
        }

        var spawnedPrefab = Instantiate(enemyPrefab);
        spawnedPrefab.transform.position = GetSpawnPosition();
        pooledObjects.Add(spawnedPrefab);
    }

    private Vector3 GetSpawnPosition(){
        var playerPos = player.transform.position;
        var distanceFromPlayer = spawnerStatsSo.distanceFromPlayer;
        return player.transform.position + (UnityEngine.Random.insideUnitSphere * distanceFromPlayer);
    }

    public GameObject GetPooledObject(){
        return pooledObjects.First(x => !x.activeInHierarchy);
    }
    
}
