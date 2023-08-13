using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState{
    private Animator animator;
    private string attackParameter;
    private EnemyBaseStateManager enemyStateManager;
    
    public override void EnterState(EnemyBaseStateManager enemyStateManager){
        if (this.enemyStateManager == null){
            this.enemyStateManager = enemyStateManager;
        }

        if (animator == null){
            animator = enemyStateManager.GetAnimator();
        }

        if (String.IsNullOrEmpty(attackParameter)){
            attackParameter = enemyStateManager.enemyAnimatorController.enemyAnimatorHashManager.attackParameter;
        }

        this.enemyStateManager.enemyAnimatorController.behaviourSolver.OnEnter.AddListener(DamagePlayer);
        this.enemyStateManager.enemyAnimatorController.behaviourSolver.OnExit.AddListener(ChangeState);
        animator.SetBool("Attack", true);
    }

    public override void UpdateState(EnemyBaseStateManager enemyStateManager){ }

    private void ChangeState(StateInfo info){
        if (info.info.IsTag("Attack")){
            animator.SetBool(attackParameter, false);
            SwitchState(enemyStateManager.moveState);
        }

    }

    private void DamagePlayer(StateInfo info){
        if (info.info.IsTag("Attack")){
            var damage = this.enemyStateManager.enemyStatsSo.damage;
            enemyStateManager.GetPlayer().health.TakeDamage(damage);
            GameEvents.Player.OnPlayerTakeDamage(damage);
        }
    }

    public override void OnCollisionEnter(EnemyBaseStateManager enemyStateManager, Collider collision){

    }

    public void DamagePlayer(){
        var damage = this.enemyStateManager.enemyStatsSo.damage;
        enemyStateManager.GetPlayer().health.TakeDamage(damage);
        GameEvents.Player.OnPlayerTakeDamage(damage);
    }


    public override void SwitchState(EnemyBaseState enemyBaseState){
        enemyStateManager.enemyAnimatorController.behaviourSolver.OnEnter.RemoveListener(DamagePlayer);
        enemyStateManager.enemyAnimatorController.behaviourSolver.OnExit.RemoveListener(ChangeState);
        animator.SetBool(attackParameter,false);
        enemyStateManager.SwitchState(enemyBaseState);
    }
    
    
}
