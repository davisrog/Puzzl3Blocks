using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SavePlayerData : MonoBehaviour
{

    string username = "";
    string userAge = "";
    string userGender = "";
    string userGameExperience = "";
    //public TMP_InputField InputField;
   // public string theName;
    //public GameObject inputField;
    // public GameObject textDisplay;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void ClickSave()
    {
        SetUserName();
        SetUserAge();
        SetUserGender();
        SetUserGameExperience();
        SaveData();
    }

   public void SetUserName()
    {
        username = GameObject.Find("username").GetComponent<TMP_InputField>().text;
    }

    public void SetUserAge()
    {
        userAge = GameObject.Find("userage").GetComponent<TMP_InputField>().text;
    }
    
    public void SetUserGender()
    {
        userGender = GameObject.Find("usergender").GetComponent<TMP_InputField>().text;
    }

    public void SetUserGameExperience()
    {
        userGameExperience = GameObject.Find("userGameExperience").GetComponent<TMP_InputField>().text;
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("UserName", username);
        PlayerPrefs.SetString("UserAge", userAge);
        PlayerPrefs.SetString("UserGender", userGender);
        PlayerPrefs.SetString("UserGameExp", userGameExperience);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
}
