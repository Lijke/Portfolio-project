using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour{
    private EnemyBaseState currentState;
    public EnemyMoveState moveState= new ();
    public EnemyAttackState attackState = new();
    FirstPersonController player => FirstPersonController.Instance;
    
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
}
