using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveState : EnemyBaseState{
    private EnemyBaseStateManager enemyStateManager;
    private NavMeshAgent navMeshAgent;
    private FirstPersonController player;
    [SerializeField] private float attackDistance = 0.5f;

    public override void EnterState(EnemyBaseStateManager enemyStateManager){
        
        navMeshAgent = enemyStateManager.GetNavMeshAgent();
        player = enemyStateManager.GetPlayer();
        this.enemyStateManager = enemyStateManager;
        if (IsAttackDistance()){
            SwitchState(enemyStateManager.attackState);
        }
        enemyStateManager.GetAnimator().SetBool("Move",true);
    }

    public override void UpdateState(EnemyBaseStateManager enemyStateManager){
        if (navMeshAgent == null && player == null){
            return;
        }
        if (IsAttackDistance()){
            SwitchState(enemyStateManager.attackState);
        }

        navMeshAgent.SetDestination(GetPlayerTransform());
    }

    public override void OnCollisionEnter(EnemyBaseStateManager enemyStateManager, Collider collision){ }

    private bool IsAttackDistance(){
        if (Vector3.Distance(player.transform.position, enemyStateManager.transform.position) < attackDistance){
            return true;
        }

        return false;
    }

    private Vector3 GetPlayerTransform(){
        return player.transform.position;
    }

 

    public override void SwitchState(EnemyBaseState enemyBaseState){
        enemyStateManager.GetAnimator().SetBool("Move",false);
        enemyStateManager.SwitchState(enemyBaseState);
    }
}
