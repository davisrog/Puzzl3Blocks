using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {
    //Loads character selection screen
    public void ButtonPauseScreen() {
        SceneManager.LoadScene("PauseScene");
    }

    //Loads character selection screen
    public void ButtonStartGameOver() {
        Debug.Log("UNDER CONSTRUCTION");
        SceneManager.LoadScene("Level1");
    }

    //Loads character selection screen
    public void ButtonBackToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ButtonNextLevel() {
        Debug.Log("UNDER CONSTRUCTION");
    }
    
    public void ButtonGiveFeedback() {
        Debug.Log("UNDER CONSTRUCTION");
    }
    
    //Closes the application 
    public void ButtonQuitGame() {
        Application.Quit(); 
    }
    
}
