﻿using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseStateManager : MonoBehaviour{
    private EnemyBaseState currentState;
    public EnemyMoveState moveState;
    public EnemyDeathState enemyDeathState;
    public EnemyAttackState attackState;
    
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    FirstPersonController player => FirstPersonController.Instance;
    public EnemyAnimatorController enemyAnimatorController;
    public EnemyStatsSO enemyStatsSo;
    public Health health;
    public UiHealthBar uiHealthBar;
    public EnemyShooting enemyShooting;
    
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
    
    private void Update(){
        currentState.UpdateState(this);
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
    private void OnDestroy(){
        health.takeDamageAction += CheckHealth;
    }
    public void OnDeath(){
        transform.root.gameObject.SetActive(false);
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

    public void SetStateAfterDeath(){
        currentState = moveState;
        currentState.EnterState(this);
    }

    public void SetupOnExitListener(){
        enemyAnimatorController.behaviourSolver.OnExit.AddListener(ChangeState);
    }

    private void ChangeState(StateInfo info){
        Debug.LogError("change state to move");
        if (info.info.IsTag("Attack")){
            SwitchState(moveState);
        }
    }
}