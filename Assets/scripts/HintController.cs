using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HintController : MonoBehaviour {
    
    public void ButtonHintScreen() {
        SceneManager.LoadScene("HintScene");
    }
    
    public void ButtonResumeGameHintScreen() {
        // if (!SelectionModel.GetLevelMap().Equals("Not Unlocked")) {
        //     SceneManager.LoadScene(SelectionModel.StartGameActivated());
        // } else {
        //     Debug.Log("Level under construction");
        // }
        Debug.Log("UNDER CONSTRUCTION");
        SceneManager.LoadScene("Level1");
    }
}
