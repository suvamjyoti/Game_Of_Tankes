using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private Button m_exitButton;

    
    private void Start(){
        m_exitButton = GetComponent<Button>();
        m_exitButton.onClick.AddListener(ObExit);
    }

//```````````````````````````````````````````````````````````````````````````
//```````````````````````````````````````````````````````````````````````````

    private void ObExit(){

        Application.Quit();
    }
}
