using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {
    
    private static int lastLevel;

    //TODO: Create navigation controller and model. Move model methods out of controller
    public static void SetLastLevel() {
        lastLevel = SceneManager.GetActiveScene().buildIndex;
    }
     
    //TODO: Create navigation controller and model. Move model methods out of controller
    public static int GetLastLevel() {
        return lastLevel;
    }
    
    //Loads pause screen
    public void ButtonPauseScreen() {
        SetLastLevel();
        SceneManager.LoadScene("PauseScene");
    }
    
    //Loads character selection screen
    public void ButtonResumeGame() {
        Debug.Log("UNDER CONSTRUCTION");
        SceneManager.LoadScene(GetLastLevel());
    }
    
    //puts user back on previous screen
    public void ButtonNewGame() {
        Debug.Log("UNDER CONSTRUCTION");
        DataCollector.Instance.SetLives();
        SceneManager.LoadScene(GetLastLevel());
    }
    
    //Loads character selection screen
    public void ButtonControlsScreen() {
        SceneManager.LoadScene("ControlsScene");
    }
    
    //Loads character selection screen
    public void ButtonBackToMenu() {
        DataCollector.Instance.SetLives();
        SceneManager.LoadScene("MainMenu");
    }
    
    //Closes the application 
    public void ButtonQuitScreen() {
        Application.Quit(); 
    }
    
}
