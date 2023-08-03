using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    public ParticleSystem particleSystem;
    [SerializeField] private Destroyer _destroyer;
    [SerializeField] private ShootingStatsSO shootingStatsSo;
    private void OnTriggerEnter(Collider collider){
        if (collider.CompareTag("Enemy")){
            var enemyHealth = collider.gameObject.GetComponentInChildren<Health>();
            enemyHealth.TakeDamage(shootingStatsSo.bulletDamage);
        }
        var obj = Instantiate(particleSystem, transform.position, Quaternion.identity);
    }
}
