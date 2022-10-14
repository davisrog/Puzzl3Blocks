using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {
    //Loads character selection screen
    public void ButtonPauseScreen() {
        SceneManager.LoadScene("PauseScene");
    }
    
    //Loads character selection screen
    public void ButtonResumeGame() {
        Debug.Log("UNDER CONSTRUCTION");
    }
    
    //Loads character selection screen
    public void ButtonNewGame() {
        // if (!SelectionModel.GetLevelMap().Equals("Not Unlocked")) {
        //     SceneManager.LoadScene(SelectionModel.StartGameActivated());
        // } else {
        //     Debug.Log("Level under construction");
        // }
        
        //TODO 
        //if current level equals this go to that
        // SceneManager.LoadScene("Level1");
        // SceneManager.LoadScene("Level2");
        // SceneManager.LoadScene("Level4");
        // SceneManager.LoadScene("Level5");
        
        
        Debug.Log("UNDER CONSTRUCTION");
        SceneManager.LoadScene("Level1");
    }
    
    //Loads character selection screen
    public void ButtonControlsScreen() {
        Debug.Log("UNDER CONSTRUCTION");
    }
    
    //Loads character selection screen
    public void ButtonBackToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    
    //Closes the application 
    public void ButtonQuitScreen() {
        Application.Quit(); 
    }
    
}
