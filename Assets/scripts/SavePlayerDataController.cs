using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SavePlayerDataController : MonoBehaviour {
    // Goes back to Main Menu
    public void ButtonSkipMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
