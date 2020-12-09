using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillCount : MonoBehaviour{

    private int NoOfEnemiesKilled=0;
    [SerializeField]private EnemyService enemyService;
    [SerializeField]private GameObject WolfUI;

    private void Start() {
        enemyService.OnDeath+=IncreamentCount;
    }

    private void IncreamentCount(){
        NoOfEnemiesKilled++;
        if(NoOfEnemiesKilled>0){
            //do something
            Debug.Log("yeahKilled");
            WolfUI.SetActive(true);
            StartCoroutine(DisableUI());
        }
    }

    private IEnumerator DisableUI(){
        yield return new WaitForSeconds(10f);
        WolfUI.SetActive(false);
    }

}
