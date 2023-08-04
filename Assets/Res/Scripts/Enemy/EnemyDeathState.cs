using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState{
    protected Animator animator;
    protected EnemyStateManager enemyStateManager;
    public override void EnterState(EnemyStateManager enemyStateManager){
        animator = enemyStateManager.GetAnimator();
        animator.SetBool("Death",true);
        this.enemyStateManager = enemyStateManager;
        enemyStateManager.enemyAnimatorController.behaviourSolver.OnExit.AddListener(DeathEndState);
    }

    private void DeathEndState(StateInfo arg0){
        enemyStateManager.enemyAnimatorController.behaviourSolver.OnExit.RemoveListener(DeathEndState);
        enemyStateManager.OnDeath();

    }

    public override void UpdateState(EnemyStateManager enemyStateManager){ }

    public override void OnCollisionEnter(EnemyStateManager enemyStateManager, Collider collision){ }

    public override void SwitchState(EnemyBaseState enemyBaseState){
        throw new System.NotImplementedException();
    }
}
