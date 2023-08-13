using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents  {
    public static class Enemy{
        public static Action onEnemyDead;

        public static void OnEnemyDead(){
            onEnemyDead?.Invoke();
        }
    }

    public static class Player{
        public static Action<float> onPlayerTakeTamage;
        
        public static void  OnPlayerTakeDamage(int damage){
            onPlayerTakeTamage?.Invoke(damage);
        }
    }
}
