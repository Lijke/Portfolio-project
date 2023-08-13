using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState{
    protected Animator animator;
    protected EnemyBaseStateManager enemyStateManager;
    public override void EnterState(EnemyBaseStateManager enemyStateManager){
        animator = enemyStateManager.GetAnimator();
        animator.SetBool("Death",true);
        this.enemyStateManager = enemyStateManager;
        enemyStateManager.enemyAnimatorController.behaviourSolver.OnExit.AddListener(DeathEndState);
        enemyStateManager.OnDeath();
    }

    private void DeathEndState(StateInfo arg0){
        enemyStateManager.enemyAnimatorController.behaviourSolver.OnExit.RemoveListener(DeathEndState);

    }

    public override void UpdateState(EnemyBaseStateManager enemyStateManager){ }

    public override void OnCollisionEnter(EnemyBaseStateManager enemyStateManager, Collider collision){ }

    public override void SwitchState(EnemyBaseState enemyBaseState){
        throw new System.NotImplementedException();
    }
}
