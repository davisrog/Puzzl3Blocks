using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HintController : MonoBehaviour {
    
    public void ButtonHintScreen() {
        PauseController.SetLastLevel();
        DataCollector.Instance.IncrementHints();
        Debug.Log(DataCollector.Instance.GetHints());
        SceneManager.LoadScene("HintScene");
    }
    
    public void ButtonResumeGameHintScreen() {
        Debug.Log("UNDER CONSTRUCTION");
        SceneManager.LoadScene(PauseController.GetLastLevel());
    }
}
