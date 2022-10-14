using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TabInputFieldUserData : MonoBehaviour
{
    public TMP_InputField username; //0
    public TMP_InputField userage; //1
    public TMP_InputField usergender; //2
    public TMP_InputField usergameexperience; //3
    public TMP_InputField userpuzzlegameenjoyment; //4

    public int inputselected;


    //assign these to set the input selected when they are clicked on
    public void UsernameSelected()
    {
        inputselected = 0;
    }
    public void UserageSelected()
    {
        inputselected = 1;
    }
    public void UsergenderSelected()
    {
        inputselected = 2;
    }
    public void UsergameexperienceSelected()
    {
        inputselected = 3;
    }
    public void UserpuzzlegameenjoymentSelected()
    {
        inputselected = 4;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            inputselected--;
            if (inputselected < 0)
            {
                inputselected = 4;
            }
            SelectInputField();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.RightShift))
        {
            inputselected--;
            if (inputselected < 0)
            {
                inputselected = 4;
            }
            SelectInputField();
        }

        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputselected++;
            if (inputselected > 4)
            {
                inputselected = 0;
            }
            SelectInputField();
        }

        void SelectInputField()
        {
            switch (inputselected)
            {
                case 0:
                    username.Select();
                    break;
                case 1:
                    userage.Select();
                    break;
                case 2:
                    usergender.Select();
                    break;
                case 3:
                    usergameexperience.Select();
                    break;
                case 4:
                    userpuzzlegameenjoyment.Select();
                    break;
            }
        }

    }
}
