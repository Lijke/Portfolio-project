using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class NavMeshPointFinder {

    public bool IsTransformOnNavMesh(Vector3 position, float maxDistance ){
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, maxDistance, NavMesh.AllAreas)){
            return true;
        }

        return false;
    }

    public Vector3 GetNearestNavVector3FromPosition(Vector3 position){
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, Mathf.Infinity, NavMesh.AllAreas)){
            return hit.position;
        }

        return position;
    }
}

public class EnemySpawner : MonoBehaviour{
    public EnemyPrefabsSO enemyPrefabsSo;
    public SpawnerStatsSO spawnerStatsSo;
    public List<GameObject> pooledObjects;
    public FirstPersonController player;
    public static EnemySpawner Instance;
    public NavMeshPointFinder navMeshPoint = new NavMeshPointFinder();

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
            var healthScript = prefab.GetComponentInChildren<Health>();
            healthScript.Setup();
            var enemyManager = prefab.GetComponentInChildren<EnemyBaseStateManager>();
            enemyManager.SetStateAfterDeath();
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
        var nearestPos = navMeshPoint.GetNearestNavVector3FromPosition(player.transform.position + (UnityEngine.Random.insideUnitSphere * distanceFromPlayer));
#if UNITY_EDITOR
        Debug.DrawLine(nearestPos, nearestPos + Vector3.up * 100, Color.red,10f);
#endif
        return nearestPos;
    }

    public GameObject GetPooledObject(){
        return pooledObjects.First(x => !x.activeInHierarchy);
    }
    
}
