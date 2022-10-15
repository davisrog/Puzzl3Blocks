using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//using UnityEditor.Experimental.GraphView;


public class SelectionController : MonoBehaviour {
    
    [SerializeField] TextMeshProUGUI inputDataElement;

    // Start is called before the first frame update
    // void Start() {
        //TODO: fix character database
        // SelectionModel.CharacterSelected(0);
    // }

    // Guard for button press to prevent data input issues
    public void ButtonGuard(string inputValue) {
        if (inputValue == "Start") {
            Debug.Log(SelectionModel.StartGameActivated());
            if (!SelectionModel.GetLevelMap().Equals("Not Unlocked")) {
                if (GameObject.Find("DataCollector")){
                    DataCollector.Instance.ResetOnQuitToMain();
                    Debug.Log("reset called on DataCollector");
                }
                SceneManager.LoadScene(SelectionModel.StartGameActivated());

            } else {
                Debug.Log("Level under construction");
            }
            // //TODO:Fix error handling            
            // try {
            //     SceneManager.LoadScene(SelectionModel.StartGameActivated());
            // } catch (Exception ex){
            //     Debug.Log("Level under construction");
            // }
        } else {
            //TODO: might need to move to model
            var value  = Convert.ToInt32(inputValue);
            var characterSelected = SelectionModel.CharacterSelected(value);
            inputDataElement.text = characterSelected;

        }
    }

    // When button is pressed record input for character 1
    public void ButtonCharacter01() {
        ButtonGuard("0");
    }
    
    // When button is pressed record input for character 2
    public void ButtonCharacter02() {
        ButtonGuard("1");
    }

    // When button is pressed record input for character 3
    public void ButtonCharacter03() {
        ButtonGuard("2");
    }

    // When button is pressed record input for character 4
    public void ButtonCharacter04() {
        ButtonGuard("3");
    }

    // When button is pressed record input for character 5
    public void ButtonCharacter05() {
        ButtonGuard("4");
    }

    // When button is pressed record input for character 6
    public void ButtonCharacter06() {
        ButtonGuard("5");
    }

    // When button is pressed record input for character 7
    public void ButtonCharacter07() {
        ButtonGuard("6");
    }
    
    // When button is pressed record input for character 8
    public void ButtonCharacter08() {
        ButtonGuard("7");
    }
    
    // When button is pressed record input for character 9
    public void ButtonCharacter09() {
        ButtonGuard("8");
    }
    
    // When button is pressed record input for character 10
    public void ButtonCharacter10() {
        ButtonGuard("10");
    }
    
    // When button is pressed record input for character 11
    public void ButtonCharacter11() {
        ButtonGuard("11");
    }
    
    // When button is pressed record input for character 12
    public void ButtonCharacter12() {
        ButtonGuard("12");
    }
    
    // When button is pressed record input for Start
    public void ButtonStart() {
        
        ButtonGuard("Start");
    }
    
    // Goes back to Main Menu
    public void ButtonBackMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
