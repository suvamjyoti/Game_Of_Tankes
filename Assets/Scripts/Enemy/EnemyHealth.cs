using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : TankHealth{

    protected override void PlayerDead(){

        base.PlayerDead();
        IsDead = true;
        if(explosionCoroutine==null){
            explosionCoroutine = StartCoroutine(playerDeathEffects());
        }
    }


}
