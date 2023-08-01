using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveState : EnemyBaseState{
    private EnemyStateManager enemyStateManager;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private FirstPersonController player;

    public override void EnterState(EnemyStateManager enemyStateManager){
        navMeshAgent = enemyStateManager.GetNavMeshAgent();
        player = enemyStateManager.GetPlayer();
        this.enemyStateManager = enemyStateManager;
    }

    public override void UpdateState(EnemyStateManager enemyStateManager){
        if (navMeshAgent == null && player == null){
            return;
        }

        navMeshAgent.SetDestination(GetPlayerTransform());
        

        if (IsAttackDistance()){
            SwitchState(enemyStateManager.attackState);
        }
    }

    private bool IsAttackDistance(){
        if (Vector3.Distance(player.transform.position, enemyStateManager.transform.position) < 0.03f){
            return true;
        }

        return false;
    }

    private Vector3 GetPlayerTransform(){
        return player.transform.position;
    }

    public override void OnCollisionEnter(EnemyStateManager enemyStateManager){
        throw new System.NotImplementedException();
    }

    public override void SwitchState(EnemyBaseState enemyBaseState){
        enemyStateManager.SwitchState(enemyBaseState);
    }
}
