using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    [SerializeField] private Destroyer _destroyer;

    public virtual void OnTriggerEnter(Collider collider){
      
    }

    public void Launch(Vector3 forward){
        //transform.GetComponent<Rigidbody>().velocity = forward * 15;
    }
}



