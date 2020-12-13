using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour{

    [SerializeField]private AchievementService AchievementService;
    [SerializeField]private ReplayButton replayButton;
    [SerializeField]private GameObject WolfUI;
    [SerializeField]private GameObject DragonUI;

    [SerializeField]private TMP_Text Score;
    
//```````````````````````````````````````````````````````````````````````````````````
//```````````````````````````````````````````````````````````````````````````````````

    private void Start() {
        AchievementService.OnDeath+=WolfAchievement;
        AchievementService.OnFire+=KhaleesiAchievement;

        replayButton.OnReplay+=ResetUi;

    }

//```````````````````````````````````````````````````````````````````````````````````
//```````````````````````````````````````````````````````````````````````````````````

    private void Update() {
        
        if(EnemyHealth.KillScore.ToString()!=Score.text){
            Score.text  = EnemyHealth.KillScore.ToString();
        }

    }

//```````````````````````````````````````````````````````````````````````````````````
//```````````````````````````````````````````````````````````````````````````````````

    private void WolfAchievement(){
        
        WolfUI.SetActive(true);
        StartCoroutine(DisableUI(WolfUI));
    }

    private void KhaleesiAchievement(){
        
        DragonUI.SetActive(true);
        StartCoroutine(DisableUI(DragonUI));
    }

    private void ResetUi(){
        EnemyHealth.KillScore = 0;
        EnemyHealth.NoOfEnemyKilled=0;
    }
//```````````````````````````````````````````````````````````````````````````````````
//```````````````````````````````````````````````````````````````````````````````````

    private IEnumerator DisableUI(GameObject _UIElement){
        yield return new WaitForSeconds(10f);
        _UIElement.SetActive(false);
    }

}
