using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState{
    private Animator animator;
    private string attackParameter;
    private EnemyStateManager enemyStateManager;
    
    public override void EnterState(EnemyStateManager enemyStateManager){
        if (this.enemyStateManager == null){
            this.enemyStateManager = enemyStateManager;
        }

        if (animator == null){
            animator = enemyStateManager.GetAnimator();
        }

        if (attackParameter == null){
            attackParameter = enemyStateManager.enemyAnimatorController.enemyAnimatorHashManager.attackParameter;
        }

        this.enemyStateManager.enemyAnimatorController.behaviourSolver.OnEnter.AddListener(DamagePlayer);
        this.enemyStateManager.enemyAnimatorController.behaviourSolver.OnExit.AddListener(ChangeState);
        animator.SetBool("Attack", true);
    }

    public override void UpdateState(EnemyStateManager enemyStateManager){ }

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

    public override void OnCollisionEnter(EnemyStateManager enemyStateManager, Collider collision){

    }

    public void DamagePlayer(){
        var damage = this.enemyStateManager.enemyStatsSo.damage;
        enemyStateManager.GetPlayer().health.TakeDamage(damage);
        GameEvents.Player.OnPlayerTakeDamage(damage);
    }


    public override void SwitchState(EnemyBaseState enemyBaseState){
        this.enemyStateManager.enemyAnimatorController.behaviourSolver.OnEnter.RemoveListener(DamagePlayer);
        this.enemyStateManager.enemyAnimatorController.behaviourSolver.OnExit.RemoveListener(ChangeState);
        animator.SetBool(attackParameter,false);
        enemyStateManager.SwitchState(enemyBaseState);
    }
    
    
}
