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
    public EnemyDeathState enemyDeathState = new();
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    FirstPersonController player => FirstPersonController.Instance;
    public EnemyAnimatorController enemyAnimatorController;
    public EnemyStatsSO enemyStatsSo;
    public Health health;

    public UiHealthBar uiHealthBar;
    public NavMeshAgent GetNavMeshAgent(){
        return navMeshAgent;
    }
    
    private void Start(){
        currentState = moveState;
        currentState.EnterState(this);
        if (health != null){
            health.takeDamageAction += CheckHealth;
        }
    }

    private void OnDestroy(){
        health.takeDamageAction += CheckHealth;
    }

    private void CheckHealth(int takenDamage){
        uiHealthBar.SetupBar(health);
        if (takenDamage <= 0){
            currentState = enemyDeathState;
            currentState.EnterState(this);
            IvokeDeadEvent();
        }
    }

    private void IvokeDeadEvent(){
        GameEvents.Enemy.OnEnemyDead();
    }

    public void OnDeath(){
        transform.root.gameObject.SetActive(false);
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
