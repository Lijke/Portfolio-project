using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorHashManager : MonoBehaviour{
    public int lastExitTag;
    
    public int attackHash;

    public string attackParameter;

    private void Awake(){
        attackHash = Animator.StringToHash("Attack");
    }

    public void SetExitState(int lastExitTagHash){
        lastExitTag = lastExitTagHash;
    }
}
