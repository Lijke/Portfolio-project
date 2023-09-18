using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class EnemyShooting : MonoBehaviour{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletTimeBeetwenShoots = 0.3f;
    private bool canShoot = true;

    private void Awake(){
        canShoot = true;
    }

    public void PrepareShoot(FirstPersonController player){
        RotateTowardsPlayer(player);
        if (canShoot){
            canShoot = false;
            ShootProjectile();
        }
     
      
    }

    private void ShootProjectile(){
        var spawnedBullet =Instantiate(bulletPrefab);
        var bulletScript = spawnedBullet.GetComponent<EnemyBullet>();
        spawnedBullet.transform.position = shootPoint.transform.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = transform.forward * 10;
        Invoke("DelayTime", bulletTimeBeetwenShoots);
    }

    public void DelayTime(){
        canShoot = true;
    }

    private void RotateTowardsPlayer(FirstPersonController player){
        Vector3 directionToPlayer = player.transform.position - transform.position;

        // Calculate the rotation required to look at the player
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        // Smoothly rotate the object towards the player
        transform.root.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 100f * Time.deltaTime);
    }

    public bool CanShoot(){
        return canShoot;
    }
}
