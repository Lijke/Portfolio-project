using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerEnemyStateManager : EnemyBaseStateManager{
    private RangeEnemyAttackState rangedAttackState = new();
    private void Awake(){
        attackState = rangedAttackState;
    }
}
