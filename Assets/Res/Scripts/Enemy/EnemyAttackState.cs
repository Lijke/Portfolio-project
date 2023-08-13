using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState{
    protected Animator animator;
    protected string attackParameter;
    protected EnemyBaseStateManager enemyStateManager;
    protected FirstPersonController player => FirstPersonController.Instance;

    public override void Init(EnemyBaseStateManager enemyBaseStateManager){
        if (enemyStateManager == null){
            enemyStateManager = enemyBaseStateManager;
        }

        if (animator == null){
            animator = enemyStateManager.GetAnimator();
        }

        if (String.IsNullOrEmpty(attackParameter)){
            attackParameter = enemyStateManager.enemyAnimatorController.enemyAnimatorHashManager.attackParameter;
        }
    }

    public override void EnterState(EnemyBaseStateManager enemyStateManager){
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
