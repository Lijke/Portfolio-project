using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class EnemyShooting : MonoBehaviour{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float bulletTimeBeetwenShoots = 0.05f;
    private bool canShoot = true;
    public void Shoot(FirstPersonController player){
        RotateTowardsPlayer(player);
        var spawnedBullet =Instantiate(bulletPrefab);
        var bulletScript = spawnedBullet.GetComponent<EnemyBullet>();
        spawnedBullet.transform.position = shootPoint.transform.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = transform.forward * 10;
        canShoot = false;
       
    }

    private void RotateTowardsPlayer(FirstPersonController player){
        Vector3 directionToPlayer = player.transform.position - transform.position;

        // Calculate the rotation required to look at the player
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        // Smoothly rotate the object towards the player
        transform.root.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 100f * Time.deltaTime);
    }
}
