using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealth : TankHealth{

    public static int NoOfEnemyKilled=0;
    public static int KillScore=0;
    
    public AudioSource m_explosionAudio;
    public AudioClip m_explosionAudioClip;            

    protected override void PlayerDead(){

        NoOfEnemyKilled++;
        KillScore++;
        base.PlayerDead();
        IsDead = true;
        if(explosionCoroutine==null){
            explosionCoroutine = StartCoroutine(playerDeathEffects());
        }

        EnemyManager.No_OfActiveEnemy--;

    }


}
