using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public Health health;

    private void Awake(){
        health.takeDamageAction += TakeDamage;
    }
    private void OnDestroy(){
        health.takeDamageAction -= TakeDamage;
    }

    private void TakeDamage(int takenDamage){
        GameEvents.Player.OnPlayerTakeDamage(takenDamage);
    }

  
}
