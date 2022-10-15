using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtnGroup : MonoBehaviour
{
    public void PlayGame() {
        if (PlayerPrefs.GetString("UserName") == "" || PlayerPrefs.GetString("UserGender") == "" || PlayerPrefs.GetString("UserAge") == "" || PlayerPrefs.GetString("UserGameExp") == "") {
            //this asks for player information before they start...we don't really need their name, looks like there's a unique userid that unity assigns in the registry that we can get
            SceneManager.LoadScene("UserDataMenu");
        } else {
            Debug.Log(PlayerPrefs.GetString("UserName"));
            Debug.Log(PlayerPrefs.GetString("UserGender"));
            Debug.Log(PlayerPrefs.GetString("UserAge"));
            Debug.Log(PlayerPrefs.GetString("UserGameExp"));
            ButtonSelectionScreen();
        }
        //SceneManager.LoadScene(1); //Loads by build index
        //SceneManager.LoadScene(ScreenManager.GetActiveScene().buildIndex + 1); //Loads next scene
    }

    //Loads character selection screen
    public static void ButtonSelectionScreen() {
        SceneManager.LoadScene("SelectionScene");
    }
    
    //Loads help screen
    public void ButtonHelp() {
        SceneManager.LoadScene("HelpScene");
    }
    
    //loads feedback page
    public void ButtonMenuGiveFeedback() {
        UserGameOpinionsController.SetCurrentScreen();
        SceneManager.LoadScene("UserGameOpinions");
    }
    
    //Loads continue game
    public void ButtonContinueGame() {
        Debug.Log("UNDER CONSTRUCTION");
        Debug.Log(PauseController.GetLastLevel());
        Debug.Log(GameOverController.GetLevelScene());
        if (!PauseController.GetLastLevel().Equals(0)) {
            SceneManager.LoadScene(PauseController.GetLastLevel());
        } else {
            SceneManager.LoadScene(GameOverController.GetLevelScene());
        }
    }
    
    //Loads continue game
    public void ButtonLogoEasterEgg() {
        Debug.Log("UNDER CONSTRUCTION");
    }
    
    public void QuitGame() {
        Debug.Log("exit pressed");
        if (GameObject.Find("DataCollector"))
        {
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
            Application.Quit(); //This quits the game
        }
        else
        {
            SendToGoogleForm.Instance.Send(-1, -1, "undefined", "undefined", -1, -1, "n/a", "n/a", "n/a", 
                SceneManager.GetActiveScene().name, "n/a", "n/a");
            Application.Quit();
        }
    }
}
