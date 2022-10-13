using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SendButton : MonoBehaviour
{
    private string likegame;
    private string suggestions;
    private string usability;
    private string avatarenjoyment;

    public void SetLikeGame()
    {
        likegame = GameObject.Find("enjoygame").GetComponent<TMP_InputField>().text;
    }
    public void SetSuggestions()
    {
        suggestions = GameObject.Find("suggestions").GetComponent<TMP_InputField>().text;
    }

    public void SetEasyControl()
    {
        usability = GameObject.Find("Usability").GetComponent<TMP_InputField>().text;
    }

    public void SetAvatarEnjoyment()
    {
        avatarenjoyment = GameObject.Find("Enjoyment").GetComponent<TMP_InputField>().text;
    }

    public void PopulateGoogle()
    {
        SetLikeGame();
        SetSuggestions();
        SetEasyControl();
        SetAvatarEnjoyment();
        SendToGoogleForm.Instance.Send(0, 0, "null", "null", 0, likegame, suggestions, "null", "null", usability, avatarenjoyment);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
