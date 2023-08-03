using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour{
    public int currentHealth;
    public int maxHealth;
    public Action<int> takeDamageAction;

    private void Awake(){
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dealDamage){
        currentHealth -= dealDamage;
        if (currentHealth <= 0){
            Debug.Log("[Health] Health <= 0");
            takeDamageAction?.Invoke(currentHealth);
        }
    }
}
