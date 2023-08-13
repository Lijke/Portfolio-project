using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour{
    private void OnTriggerEnter(Collider other){
        Debug.LogError($"{other.gameObject.name}");
        Destroy(this.gameObject);
    }
}
