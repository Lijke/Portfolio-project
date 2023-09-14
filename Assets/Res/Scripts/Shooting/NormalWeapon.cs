using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;

public class NormalWeapon : MonoBehaviour{
    public ShootingStatsSO shootingStatsSo;
    public StarterAssetsInputs inputs;
    public float bulletTimeBeetwenShoots;
    private bool canShoot;
    public BulletLauncher bulletLauncher;
    [SerializeField] public Camera _camera;

    private void Awake(){
        canShoot = true;
    }

    private void Update(){
        if (inputs.shoot && canShoot){
            canShoot = false;
            bulletLauncher.Launch(this);
            Invoke("PrepareShoot", bulletTimeBeetwenShoots);
        }
    }

    public void PrepareShoot(){
        canShoot = true;
    }

}