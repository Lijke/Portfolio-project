using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimatorController : MonoBehaviour{
    public AnimatorBehaviourSolver behaviourSolver;
    private AnimationController _animationController;
    int lastEnterTagHash;
    private int lastExitTagHash;
    public EnemyAnimatorHashManager enemyAnimatorHashManager;
    [SerializeField] private Animator enemyAnimatorController;
    private void Awake(){
        AddForEnterState(SetEnterState);
        AddForExitState(SetExitState);
    }

    private void AddForExitState(UnityAction<StateInfo> setExitState){
        behaviourSolver.OnEnter.AddListener(setExitState);
    }

    public void AddForEnterState(UnityAction<StateInfo> onEnterState) {
        behaviourSolver.OnEnter.AddListener(onEnterState);
       
    }
    
    void SetEnterState(StateInfo info){
        lastEnterTagHash = info.info.tagHash;
    }    
    void SetExitState(StateInfo info){
        lastExitTagHash = info.info.tagHash;
        enemyAnimatorHashManager.SetExitState(lastExitTagHash);
    }


    public void SetupAnimation(string val){
        enemyAnimatorController.SetBool(val,true);
    }
}