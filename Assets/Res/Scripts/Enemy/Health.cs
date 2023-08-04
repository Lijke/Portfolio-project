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
        takeDamageAction?.Invoke(currentHealth);
        currentHealth -= dealDamage;
    }
}
