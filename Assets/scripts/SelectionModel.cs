using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionModel : MonoBehaviour {
    //TODO: add unlock functions
    static public bool playerCharacterUnlocked;
    //TODO: add timer
    //TODO: fix character database
    // public static CharacterDatabase characterDB;
    static public string characterSelected;
    static public string levelMap;



    // Method to check is character has been unlocked
    public static bool CharacterAvailable() {
        //TODO: IS TOON UNLOCKED?
        playerCharacterUnlocked = true;
        return playerCharacterUnlocked;
    }
    
    // Set character
    public static void SetCharacter(string character) {
        characterSelected = character;
    }
    
    // Get character
    public static string GetCharacter() {
        return characterSelected;
    }
    
    // Set Level Map
    public static void SetLevelMap(string map) {
        levelMap = map;
    }
    
    // Get Level Map
    public static string GetLevelMap() {
        return levelMap;
    }
    

    // Case method for selecting character
    public static string CharacterSelected(int inputValue) {

        if (CharacterAvailable().Equals(true)) {
            switch (inputValue) {
                case 0:
                    characterSelected = "Square";
                    SetCharacter(characterSelected);
                    break;
                case 1:
                    characterSelected = "Circle";
                    SetCharacter(characterSelected);
                    break;
                case 2:
                    characterSelected = "Beach Ball";
                    SetCharacter(characterSelected);
                    break;
                case 6:
                    characterSelected = "Box";
                    SetCharacter(characterSelected);
                    break;
                case 7:
                    characterSelected = "Button";
                    SetCharacter(characterSelected);
                    break;
            }
        }
        //TODO: fix character database
        // if (inputValue >= characterDB.CharacterCount)
        // {
            // Character character = characterDB.GetCharacter(inputValue);
            //TODO: add sprite value for ame screen
            // nameText.text = character.characterName;  
        // }
        //return else for is locked
        return characterSelected;
    }
    
    // Method to start game
    public static string StartGameActivated() {
       //TODO: START GAME! AND TIMER
       switch (GetCharacter()) {
           case "Square":
               SetLevelMap("Level1");
               break;
           case "Circle":
               SetLevelMap("SphereLevel1");
               break;
           case "Beach Ball":
               //TODO: Level under construction 
               SetLevelMap("Not Unlocked");
               break;
           case "Box":
               //TODO: Level under construction 
               SetLevelMap("Not Unlocked");
               break;
           case "Button":
               //TODO: Level under construction 
               SetLevelMap("Not Unlocked");
               break;
           case "Not Unlocked":
               SetLevelMap("Not Unlocked");
               break;
       }
       return GetLevelMap();
    }
}
