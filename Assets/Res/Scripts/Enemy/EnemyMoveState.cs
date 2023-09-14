using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "EnemyMoveState")]
public class EnemyMoveState : EnemyBaseState{
    private EnemyBaseStateManager enemyStateManager;
    private NavMeshAgent navMeshAgent;
    private FirstPersonController player;
    [SerializeField] private float attackDistance = 0.5f;
    [SerializeField] private bool isRanged;

    public override void Init(EnemyBaseStateManager enemyBaseStateManager){
       
    }

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
            return;
        }

        navMeshAgent.SetDestination(GetPlayerTransform());
    }


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
        enemyStateManager.SwitchState(enemyBaseState);
        navMeshAgent.SetDestination(enemyStateManager.transform.root.position);
        enemyStateManager.GetAnimator().SetBool("Move",false);

    }

    public void SetupRange(float range){
        attackDistance = range;
    }
}
