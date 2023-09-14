using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using StarterAssets;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeEnemyAttackState")]
public class RangeEnemyAttackState : EnemyAttackState{
    private EnemyShooting enemyShooting;
    public float bulletTimeBeetwenShoots = 1f;
    private CancellationToken cts;

    public override void Init(EnemyBaseStateManager enemyBaseStateManager){
        base.Init(enemyBaseStateManager);
        enemyShooting = enemyBaseStateManager.enemyShooting;
    }

    public override void EnterState(EnemyBaseStateManager enemyStateManager){
        animator.SetBool("Attack", true);
        enemyShooting.Shoot(player);
        CheckState();
    }

    public override void UpdateState(EnemyBaseStateManager enemyStateManager){ }

    private async void CheckState(){
        await ReloadTimer();
        Debug.Log("Reload");
        if (!IsPlayerInShootingRange()){
            SwitchState(enemyStateManager.moveState);
        }
        else{
            EnterState(enemyStateManager);
        }
    }

    private async UniTask ReloadTimer(){
        await UniTask.Delay(TimeSpan.FromSeconds(bulletTimeBeetwenShoots));
    }

    private bool IsPlayerInShootingRange(){
        var distance = Vector3.Distance(player.transform.position, enemyStateManager.transform.root.position);
        if (distance < 10f){
            return true;
        }

        return false;
    }
}