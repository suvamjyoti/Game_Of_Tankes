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

    void Start(){

        ResumeButton.onClick.AddListener(StartGame);
        SaveButton.onClick.AddListener(LoadGame);
        ExitButton.onClick.AddListener(ExitGame);
    }

    private void StartGame(){
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    private void LoadGame(){
        //Load Game mecha
    }

    private void ExitGame(){
        //Application.Exit();
    }

}
