using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : TankHealth{

    public static int NoOfEnemyKilled=0;

    protected override void PlayerDead(){

        NoOfEnemyKilled++;
        base.PlayerDead();
        IsDead = true;
        if(explosionCoroutine==null){
            explosionCoroutine = StartCoroutine(playerDeathEffects());
        }
    }


}
