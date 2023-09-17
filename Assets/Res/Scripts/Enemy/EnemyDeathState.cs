using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDeathState")]
public class EnemyDeathState : EnemyBaseState{
    protected Animator animator;
    protected EnemyBaseStateManager enemyStateManager;


    public override void EnterState(EnemyBaseStateManager enemyManager){
        animator = enemyManager.GetAnimator();
        animator.SetBool("Death",true);
        this.enemyStateManager = enemyManager;
        enemyManager.enemyAnimatorController.behaviourSolver.OnExit.AddListener(DeathEndState);
        enemyManager.OnDeath();
    }

    private void DeathEndState(StateInfo arg0){
        enemyStateManager.enemyAnimatorController.behaviourSolver.OnExit.RemoveListener(DeathEndState);

    }

    public override void UpdateState(EnemyBaseStateManager enemyStateManager){ }


    public override void SwitchState(EnemyBaseState enemyBaseState){
        throw new System.NotImplementedException();
    }
}
