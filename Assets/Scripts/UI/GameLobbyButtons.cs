using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameLobbyButtons : MonoBehaviour{
    
    [SerializeField]private Button PlayButton; 
    [SerializeField]private Button LoadButton; 
    [SerializeField]private Button ExitButton;

    [SerializeField]private GameObject gameLobbyUI;
    [SerializeField]private Player player;

    void Start(){

        PlayButton.onClick.AddListener(StartGame);
        LoadButton.onClick.AddListener(LoadGame);
        ExitButton.onClick.AddListener(ExitGame);
    }

    private void StartGame(){
        gameLobbyUI.SetActive(false);
    }

    private void LoadGame(){
        player.LoadGame();
        gameLobbyUI.SetActive(false);
    }

    private void ExitGame(){
        //Application.Exit();
    }
}
