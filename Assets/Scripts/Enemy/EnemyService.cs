using System;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    public event Action OnDeath;
    private bool isInvoked=false;

    [SerializeField]private EnemyHealth enemyHealth;

    private void Update() {
        if(enemyHealth.IsDead && !isInvoked){
            isInvoked=true;
            OnDeath?.Invoke();
        }
    }

}
