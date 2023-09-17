using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "EnemyMoveState")]
public class EnemyMoveState : EnemyBaseState{
    [SerializeField] private float attackDistance = 0.5f;
    [SerializeField] private bool isRanged;

    

    public override void EnterState(EnemyBaseStateManager enemyManager){
        var enemyStateManager = enemyManager;
        if (IsAttackDistance(enemyStateManager)){
            SwitchStateTemp(enemyStateManager.attackState, enemyStateManager);
        }
        enemyStateManager.GetAnimator().SetBool("Move",true);
        var nav = enemyStateManager.GetNavMeshAgent();
        SetNavMeshDestination(nav, enemyManager);
    }

    private void SetNavMeshDestination(NavMeshAgent nav, EnemyBaseStateManager enemyBaseStateManager){
        nav.SetDestination(GetPlayerTransform(enemyBaseStateManager));
    }

    public override void UpdateState(EnemyBaseStateManager enemyStateManager){
        if (IsAttackDistance(enemyStateManager)){
            SwitchStateTemp(enemyStateManager.attackState, enemyStateManager);
        }
    }

    public override void SwitchState(EnemyBaseState enemyBaseStateManager){ }


    private bool IsAttackDistance(EnemyBaseStateManager enemyBaseStateManager){
        if (Vector3.Distance(GetPlayerTransform(enemyBaseStateManager), enemyBaseStateManager.transform.position) < attackDistance){
            return true;
        }

        return false;
    }

    private Vector3 GetPlayerTransform(EnemyBaseStateManager enemyBaseStateManager){
        return enemyBaseStateManager.GetPlayer().transform.position;
    }

 

    public  void SwitchStateTemp(EnemyBaseState enemyBaseState, EnemyBaseStateManager enemyBaseStateManager){
        enemyBaseStateManager.SwitchState(enemyBaseState);
        enemyBaseStateManager.GetAnimator().SetBool("Move",false);

    }

    public void SetupRange(float range){
        attackDistance = range;
    }
}
