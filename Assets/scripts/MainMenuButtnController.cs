using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtnController : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene(1); //Loads by build index
        //SceneManager.LoadScene(ScreenManager.GetActiveScene().buildIndex + 1); //Loads next scene
        SceneManager.LoadScene("Level1"); //Loads by scene name Level1
    }

    public void QuitGame()
    {
        Application.Quit(); //This quits the game
    }
}
