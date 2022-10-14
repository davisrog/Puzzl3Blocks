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
        //TODO: fix for all levels
        UserGameOpinionsController.SetCurrentScreen();
        SceneManager.LoadScene(UserGameOpinionsController.GetCurrentScreen());
    }

    //Loads character selection screen
    public void ButtonBackToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ButtonNextLevel() {
        Debug.Log("UNDER CONSTRUCTION");
    }
    
    public void ButtonGiveFeedback() {
        UserGameOpinionsController.SetCurrentScreen();
        SceneManager.LoadScene("UserGameOpinions");
    }
    
    //Closes the application 
    public void ButtonQuitGame() {
        Application.Quit(); 
    }
    
}
