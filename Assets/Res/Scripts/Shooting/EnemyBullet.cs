using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet{
    
    public override void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "Player"){
            Debug.LogError(collider.gameObject.name);
            var healthScript = collider.gameObject.GetComponentInParent<Health>();
           // healthScript.TakeDamage(shootingStatsSo.bulletDamage);
        }
        else{
            Debug.LogError(collider.gameObject.name);
        }
        Destroy(this.gameObject);
    }
}
