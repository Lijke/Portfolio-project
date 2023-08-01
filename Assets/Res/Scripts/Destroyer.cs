using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour{
    [SerializeField] private float destroyTimer;
    [SerializeField] private ParticleSystem _particleSystem;
    public void Awake(){
        StartCoroutine(DestroyGo());
    }

    private IEnumerator DestroyGo(){
        if (_particleSystem != null){
            _particleSystem.Play(); 
        }

        yield return new WaitForSeconds(destroyTimer);
        Destroy(gameObject);
    }
}
