using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtnGroup : MonoBehaviour
{
    public void PlayGame()
    {
       
        if (PlayerPrefs.GetString("UserName") == "" || PlayerPrefs.GetString("UserGender") == "" || PlayerPrefs.GetString("UserAge") == "" || PlayerPrefs.GetString("UserGameExp") == "")
        {
            //this asks for player information before they start...we don't really need their name, looks like there's a unique userid that unity assigns in the registry that we can get
            SceneManager.LoadScene("UserDataMenu");
        }
        else
        {
            SceneManager.LoadScene("Level1"); //Loads by scene name Level1
        }
        //SceneManager.LoadScene(1); //Loads by build index
        //SceneManager.LoadScene(ScreenManager.GetActiveScene().buildIndex + 1); //Loads next scene
        
    }

    public void QuitGame()
    {
        Application.Quit(); //This quits the game
    }
}
