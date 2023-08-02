using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public EnemyPrefabsSO enemyPrefabsSo;
    
    public FirstPersonController player => FirstPersonController.Instance;
    
    public void SpawnEnemies(){
        if (player == null){
            return;
        }

       var singlePrefab= enemyPrefabsSo.GetRandomEnemyPrefab();
        

    }
    
}
