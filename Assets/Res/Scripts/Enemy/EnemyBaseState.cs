using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : ScriptableObject{
    public abstract void EnterState(EnemyBaseStateManager enemyManager);
    public abstract void UpdateState(EnemyBaseStateManager enemyBaseStateManager);
    public abstract void SwitchState(EnemyBaseState enemyBaseStateManager);
}