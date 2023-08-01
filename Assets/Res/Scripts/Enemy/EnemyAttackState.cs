using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState{
    private int attackAnimHash;
    private Animator animator;
    private string attackParameter;
    public override void EnterState(EnemyStateManager enemyStateManager){
        attackAnimHash = Animator.StringToHash("Attack");
        animator = enemyStateManager.GetAnimator();
        attackParameter = enemyStateManager.enemyAnimatorController.enemyAnimatorHashManager.attackParameter;
        animator.SetBool(attackParameter, true);
        Debug.LogError("EnemyAttackState start");
    }

    public override void UpdateState(EnemyStateManager enemyStateManager){
        if (enemyStateManager.enemyAnimatorController.enemyAnimatorHashManager.lastExitTag == attackAnimHash){
            animator.SetBool(attackParameter, false);
            //try switch state
            SwitchState(enemyStateManager.moveState);
        }
    }

    public override void OnCollisionEnter(EnemyStateManager enemyStateManager){
        throw new System.NotImplementedException();
    }

    public override void SwitchState(EnemyBaseState enemyBaseState){
        
    }
    
    
}
