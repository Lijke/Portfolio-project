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
        SetAnimator(enemyStateManager);
        var nav = GetNavMesh(enemyStateManager);
        SetNavMeshDestination(nav, enemyManager);
    }

    private void SetAnimator(EnemyBaseStateManager enemyBaseStateManager){
        enemyBaseStateManager.GetAnimator().SetBool("Move",true);
    }

    private NavMeshAgent GetNavMesh(EnemyBaseStateManager enemyBaseStateManager){
        return enemyBaseStateManager.GetNavMeshAgent();
    }

    private void SetNavMeshDestination(NavMeshAgent nav, EnemyBaseStateManager enemyBaseStateManager){
        var distanceToPlayer = Vector3.Distance(enemyBaseStateManager.transform.root.position, GetPlayerPosition(enemyBaseStateManager));
        if ( distanceToPlayer < attackDistance){
            return;
        }
        nav.SetDestination(GetPlayerPosition(enemyBaseStateManager));
    }

    public override void UpdateState(EnemyBaseStateManager enemyStateManager){
        if (IsAttackDistance(enemyStateManager)  && CanAttack(enemyStateManager)){
            SwitchStateTemp(enemyStateManager.attackState, enemyStateManager);
        }
        var nav = GetNavMesh(enemyStateManager);
        if (!IsAttackDistance(enemyStateManager)){
            nav.SetDestination(GetPlayerPosition(enemyStateManager));
        }
        else{
            nav.SetDestination(enemyStateManager.transform.root.position);
        }
    }

    private bool CanAttack(EnemyBaseStateManager enemyBaseStateManager){
        return enemyBaseStateManager.enemyShooting.CanShoot();
    }

    public override void SwitchState(EnemyBaseState enemyBaseStateManager){ }


    private bool IsAttackDistance(EnemyBaseStateManager enemyBaseStateManager){
        if (Vector3.Distance(GetPlayerPosition(enemyBaseStateManager), enemyBaseStateManager.transform.position) < attackDistance){
            return true;
        }

        return false;
    }

    private Vector3 GetPlayerPosition(EnemyBaseStateManager enemyBaseStateManager){
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
