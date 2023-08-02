using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour{
    private EnemyBaseState currentState;
    public EnemyMoveState moveState= new ();
    public EnemyAttackState attackState = new();
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    FirstPersonController player => FirstPersonController.Instance;
    public EnemyAnimatorController enemyAnimatorController;
    public EnemyStatsSO enemyStatsSo;
    public NavMeshAgent GetNavMeshAgent(){
        return navMeshAgent;
    }
    
    private void Start(){
        currentState = moveState;
        currentState.EnterState(this);
    }
    
    private void Update(){
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state){
        currentState = state;
        state.EnterState(this);
    }

    public FirstPersonController GetPlayer(){
        return player;
    }

    public Animator GetAnimator(){
        return animator;
    }
}
