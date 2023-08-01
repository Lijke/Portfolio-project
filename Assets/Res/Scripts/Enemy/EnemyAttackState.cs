using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState{

    public override void EnterState(EnemyStateManager enemyStateManager){
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyStateManager enemyStateManager){
        if (true){
            enemyStateManager.SwitchState(enemyStateManager.attackState);
        }
    }

    public override void OnCollisionEnter(EnemyStateManager enemyStateManager){
        throw new System.NotImplementedException();
    }
}
