using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseGameButtons : MonoBehaviour
{
    [SerializeField]private Button ResumeButton; 
    [SerializeField]private Button SaveButton; 
    [SerializeField]private Button ExitButton;
    [SerializeField]private GameObject PauseUI;

    [SerializeField]private Player player;

    void Start(){

        ResumeButton.onClick.AddListener(StartGame);
        SaveButton.onClick.AddListener(SaveGame);
        ExitButton.onClick.AddListener(ExitGame);
    }

    private void StartGame(){
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    private void SaveGame(){
        player.SaveGame();
    }

    private void ExitGame(){
        Application.Quit();
    }

}
