using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ITargetable{
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

    public void Setup(){
        currentHealth = maxHealth;
        takeDamageAction?.Invoke(currentHealth);
    }

    public void Hit(int damage){
        TakeDamage(damage);
    }
}
