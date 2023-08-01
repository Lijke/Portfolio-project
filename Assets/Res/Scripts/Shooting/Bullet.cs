using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    public ParticleSystem particleSystem;
    [SerializeField] private Destroyer _destroyer;
    private void OnTriggerEnter(Collider other){
        var obj = Instantiate(particleSystem, transform.position, Quaternion.identity);
        _destroyer.Awake();
    }
}
