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
        Vector3 direction = player.transform.position-transform.position;
        direction .Normalize();
        float rotation = Mathf.Atan2(direction .y, direction .x) * Mathf.Rad2Deg;
        var spawnedBullet =Instantiate(bulletPrefab, shootPoint.localPosition, Quaternion.Euler(0f, 0f, rotation - 90));
        spawnedBullet.GetComponent<Rigidbody>().velocity = shootPoint.forward * 10;
        canShoot = false;
       
    }
    
    

}
