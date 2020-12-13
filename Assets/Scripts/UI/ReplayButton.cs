using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    private Button m_replayButton;
    public event Action OnReplay;

    private void Start(){
        m_replayButton = GetComponent<Button>();
        m_replayButton.onClick.AddListener(Replay);
    }

//```````````````````````````````````````````````````````````````````````````
//```````````````````````````````````````````````````````````````````````````

    private void Replay(){

        OnReplay?.Invoke();

        Scene _scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(_scene.buildIndex);
    }
}
