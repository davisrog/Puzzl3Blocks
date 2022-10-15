using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {
    
    private static int lastLevelScene;

    //puts user back on previous screen
    public void ButtonStartGameOver() {
        SceneManager.LoadScene(GetLevelScene());
    }
    
    //TODO: Create navigation controller and model. Move model methods out of controller
    public static void SetLevelScene() {
        lastLevelScene = SceneManager.GetActiveScene().buildIndex;
    }
     
    //TODO: Create navigation controller and model. Move model methods out of controller
    public static int GetLevelScene() {
        return lastLevelScene;
    }
    
    public void ButtonBackToMenu() {
        DataCollector.Instance.IncrementQuits();
        Debug.Log(DataCollector.Instance.GetQuits());
        SceneManager.LoadScene("MainMenu");
    }
    
    //Loads next level of current level build index
    public void ButtonNextLevel() {
        Debug.Log("Current Level"+GetLevelScene());
        if (GetLevelScene().Equals(1)) {
            SceneManager.LoadScene("Level2");
        }
        else if (GetLevelScene().Equals(10)) { 
            SceneManager.LoadScene("Level3");
        }
        else if (GetLevelScene().Equals(13)) {
            SceneManager.LoadScene("Level4");
        }
        else if (GetLevelScene().Equals(11)) {
            SceneManager.LoadScene("Level5");
        }
        //sphere levels
        else if (GetLevelScene().Equals(2)){
            SceneManager.LoadScene("SphereLevel2");
        }
        else if (GetLevelScene().Equals(16)){
            SceneManager.LoadScene("SphereLevel3");
        }
        else if (GetLevelScene().Equals(17)){
            SceneManager.LoadScene("SphereLevel4");
        }
                else if (GetLevelScene().Equals(18)){
            SceneManager.LoadScene("SphereLevel5");
        }
        else {
            DataCollector.Instance.SetLives();
            SceneManager.LoadScene("MainMenu");
        }
    }
    
    public void ButtonGiveFeedback() {
        UserGameOpinionsController.SetCurrentScreen();
        SceneManager.LoadScene("UserGameOpinions");
    }
    
    //Closes the application 
    public void ButtonQuitGame() {
        DataCollector.Instance.IncrementQuits();
        Debug.Log(DataCollector.Instance.GetQuits());
        SendToGoogleForm.Instance.Send(DataCollector.Instance.GetMoves(), 
            DataCollector.Instance.GetMoveTookLongest(), 
            DataCollector.Instance.GetDeltaTime().ToString("G"), 
            DataCollector.Instance.GetMaxMoveTime().ToString("G"), 
            DataCollector.Instance.GetDeaths(), DataCollector.Instance.GetHints(), 
            "n/a", "n/a", "non-cube", 
            SceneManager.GetActiveScene().name, 
            "n/a", "n/a");
        Application.Quit(); 
    }
    
}
