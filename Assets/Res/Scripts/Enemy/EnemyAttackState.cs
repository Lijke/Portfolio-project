using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyAttackState")]
public class EnemyAttackState : EnemyBaseState{

    public override void EnterState(EnemyBaseStateManager enemyManager){
        Debug.LogError("Start attack state");
        enemyManager.SetupOnExitListener();
        DamagePlayer(enemyManager);
        SetupAnimator(enemyManager);
       SwitchStateTemp(enemyManager);
    }

    private void SwitchStateTemp(EnemyBaseStateManager enemyManager){
        enemyManager.SwitchState(enemyManager.moveState);
    }

    private void SetupAnimator(EnemyBaseStateManager enemyBaseStateManager){
        enemyBaseStateManager.enemyAnimatorController.SetupAnimation("Attack");
    }

    public override void UpdateState(EnemyBaseStateManager enemyStateManager){ }

    public override void SwitchState(EnemyBaseState enemyBaseStateManager){
        
    }

    private void DamagePlayer(EnemyBaseStateManager enemyBaseStateManager){
        var damage = enemyBaseStateManager.enemyStatsSo.damage;
        enemyBaseStateManager.GetPlayer().health.TakeDamage(damage);
        GameEvents.Player.OnPlayerTakeDamage(damage);
    }
}
