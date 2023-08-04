using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour{
    public StarterAssetsInputs inputs;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 30f;
    public float bulletTimeBeetwenShoots;
    public float currentTime;
    private bool canShoot;

    private void Awake(){
        canShoot = true;
    }

    private void Update(){
        if (inputs.shoot && canShoot){
            canShoot = false;
            var spawnedBullet = Instantiate(bullet,bulletSpawnPoint.position, bulletSpawnPoint.rotation );
            spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            Invoke("PrepareShoot", bulletTimeBeetwenShoots);
        }
    }

    public void PrepareShoot(){
        canShoot = true;
    }

}