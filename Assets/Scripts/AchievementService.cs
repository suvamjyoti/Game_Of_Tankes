using System;
using UnityEngine;

public class AchievementService : MonoBehaviour
{
    public event Action OnDeath;
    public event Action OnFire;
    
    private bool isDeadInvoked=false;

    [SerializeField]private EnemyHealth enemyList;
    [SerializeField]private TankShoot playerFire;

    private void Update() {
        if(EnemyHealth.NoOfEnemyKilled>=20){
            OnDeath?.Invoke();
        }

        if(playerFire.CurrentCount>100){                         //after 20 shells fired it will invoke
            OnFire?.Invoke();
        }


    }

}
