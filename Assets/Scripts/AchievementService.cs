using System;
using UnityEngine;

public class AchievementService : MonoBehaviour
{
    public event Action OnDeath;
    public event Action OnFire;
    
    private bool isDeadInvoked=false;
    // private int NoOfEnemyKilled=0;
    // private int currentEnemyKilled=0;

    [SerializeField]private EnemyHealth enemyList;
    [SerializeField]private TankShoot playerFire;

    private void Update() {
        // foreach(var _enemy in enemyList){
        //     if(_enemy.IsDead){
        //         currentEnemyKilled++;
        //         Debug.Log("Killed");
        //     }
        // }

        if(EnemyHealth.NoOfEnemyKilled>=2){
            OnDeath?.Invoke();
        }

        if(playerFire.CurrentCount>20){                         //after 20 shells fired it will invoke
            OnFire?.Invoke();
        }


    }

}
