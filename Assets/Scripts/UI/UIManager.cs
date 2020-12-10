using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour{

    private int NoOfEnemiesKilled=0;

    [SerializeField]private AchievementService AchievementService;
    [SerializeField]private GameObject WolfUI;
    [SerializeField]private GameObject DragonUI;
    
//```````````````````````````````````````````````````````````````````````````````````
//```````````````````````````````````````````````````````````````````````````````````

    private void Start() {
        AchievementService.OnDeath+=WolfAchievement;
        AchievementService.OnFire+=KhaleesiAchievement;
    }

//```````````````````````````````````````````````````````````````````````````````````
//```````````````````````````````````````````````````````````````````````````````````

    private void WolfAchievement(){
        
        Debug.Log("yeahKilled");
        WolfUI.SetActive(true);
        StartCoroutine(DisableUI(WolfUI));
    }

    private void KhaleesiAchievement(){
        
        Debug.Log("fire fire fire Away");
        DragonUI.SetActive(true);
        StartCoroutine(DisableUI(DragonUI));
    }

//```````````````````````````````````````````````````````````````````````````````````
//```````````````````````````````````````````````````````````````````````````````````

    private IEnumerator DisableUI(GameObject _UIElement){
        yield return new WaitForSeconds(10f);
        _UIElement.SetActive(false);
    }

}
