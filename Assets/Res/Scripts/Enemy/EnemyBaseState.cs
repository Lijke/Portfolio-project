using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : ScriptableObject{
    public abstract void Init(EnemyBaseStateManager enemyBaseStateManager);
    public abstract void EnterState(EnemyBaseStateManager enemyBaseStateManager);
    public abstract void UpdateState(EnemyBaseStateManager enemyBaseStateManager);
    public abstract void SwitchState(EnemyBaseState enemyBaseStateManager);
}