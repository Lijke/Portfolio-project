using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyAttackState")]
public class EnemyAttackState : EnemyBaseState{

    public override void EnterState(EnemyBaseStateManager enemyStateManager){
        var animator = enemyStateManager.GetAnimator();
        enemyStateManager.SetupOnExitListener();
        DamagePlayer(enemyStateManager);
        animator.SetBool("Attack", true);
    }

    public override void UpdateState(EnemyBaseStateManager enemyStateManager){ }
    public override void SwitchState(EnemyBaseState enemyBaseStateManager){ }

    private void DamagePlayer(EnemyBaseStateManager enemyBaseStateManager){
        var damage = enemyBaseStateManager.enemyStatsSo.damage;
        enemyBaseStateManager.GetPlayer().health.TakeDamage(damage);
        GameEvents.Player.OnPlayerTakeDamage(damage);
    }
}
