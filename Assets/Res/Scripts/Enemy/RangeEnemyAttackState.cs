using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using StarterAssets;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeEnemyAttackState")]
public class RangeEnemyAttackState : EnemyAttackState{
    
    public override void EnterState(EnemyBaseStateManager enemyManager){
        if (enemyManager.enemyShooting.CanShoot()){
            enemyManager.enemyShooting.PrepareShoot(enemyManager.GetPlayer());
        }

        ChangeState(enemyManager);
    }

    private void ChangeState(EnemyBaseStateManager enemyManager){
        enemyManager.SwitchState(enemyManager.moveState);
    }

    public override void UpdateState(EnemyBaseStateManager enemyStateManager){ }
    
}