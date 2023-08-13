using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerEnemyStateManager : EnemyBaseStateManager{
    private RangeEnemyAttackState rangedAttackState = new();

    public override void Awake(){
        base.Awake();
        attackState = rangedAttackState;
        attackState.Init(this);
        moveState.SetupRange(10f);
    }
}
