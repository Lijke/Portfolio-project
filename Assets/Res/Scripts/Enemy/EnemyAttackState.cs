using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState{

    public override void EnterState(EnemyStateManager enemyStateManager){
        Debug.LogError("EnemyAttackState start");
    }

    public override void UpdateState(EnemyStateManager enemyStateManager){
        
    }

    public override void OnCollisionEnter(EnemyStateManager enemyStateManager){
        throw new System.NotImplementedException();
    }

    public override void SwitchState(EnemyBaseState enemyBaseState){
        throw new System.NotImplementedException();
    }
    
    
}
