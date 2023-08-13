using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState{
    public abstract void EnterState(EnemyBaseStateManager enemyStateManager);
    public abstract void UpdateState(EnemyBaseStateManager enemyStateManager);
    public abstract void OnCollisionEnter(EnemyBaseStateManager enemyStateManager, Collider collision);
    public abstract void SwitchState(EnemyBaseState enemyBaseState);
}