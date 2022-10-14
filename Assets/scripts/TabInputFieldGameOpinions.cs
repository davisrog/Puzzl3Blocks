using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TabInputFieldGameOpinions : MonoBehaviour
{
    public TMP_InputField enjoygame; //0
    public TMP_InputField usability; //1
    public TMP_InputField enjoyment; //2
    public TMP_InputField suggestions; //3

    public int inputselected;


    //assign these to set the input selected when they are clicked on
    public void EnjoygameSelected()
    {
        inputselected = 0;
    }
    public void UsabilitySelected()
    {
        inputselected = 1;
    }
    public void EnjoymentSelected()
    {
        inputselected = 2;
    }
    public void SuggestionsSelected()
    {
        inputselected = 3;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            inputselected--;
            if (inputselected < 0)
            {
                inputselected = 3;
            }
            SelectInputField();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.RightShift))
        {
            inputselected--;
            if (inputselected < 0)
            {
                inputselected = 3;
            }
            SelectInputField();
        }

        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputselected++;
            if (inputselected > 3)
            {
                inputselected = 0;
            }
            SelectInputField();
        }
        
        void SelectInputField()
        {
            switch (inputselected)
            {
                case 0: enjoygame.Select();
                    break;
                case 1: usability.Select();
                    break;
                case 2: enjoyment.Select();
                    break;
                case 3: suggestions.Select();
                    break;
            }
        }

    }
}
