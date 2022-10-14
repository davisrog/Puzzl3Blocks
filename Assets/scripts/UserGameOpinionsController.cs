using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserGameOpinionsController : MonoBehaviour
{
    private static int currentScreen;
    
    
     // Update is called once per frame good for receiving inputs
     void Update() {
         if (SendToGoogleForm.Instance.GetUploadCompletedStatus().Equals(true)) {
             ButtonSkipForm();
         }
     }

     public static void SetCurrentScreen() {
         currentScreen = SceneManager.GetActiveScene().buildIndex;
     }
     
     public static int GetCurrentScreen() {
         return currentScreen;
     }

     //puts user back on previous screen
     public void ButtonSkipForm() {
         SceneManager.LoadScene(GetCurrentScreen());
     }
}
