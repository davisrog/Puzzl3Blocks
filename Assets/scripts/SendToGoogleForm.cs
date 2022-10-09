using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToGoogleForm : MonoBehaviour
{
    private string uname = "";
    private string uage = "";
    private string ugender = "";
    private string ugameexp = "";
    private string BASE_URL = "";  //get from google
    // Start is called before the first frame update
    void Start()
    {
       uname = PlayerPrefs.GetString("UserName", "missing");
       uage = PlayerPrefs.GetString("UserAge", "missing");
       ugender = PlayerPrefs.GetString("UserGender", "missing");
       ugameexp = PlayerPrefs.GetString("UserGameExp", "missing");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Post(string uname, string uage, string ugender, string ugameexp, int moves, float time, int deaths, string likegame, string suggestions)
    {
        WWWForm form = new WWWForm();
        //dependent variables the user provides
        form.AddField("", uname);
        form.AddField("", uage);
        form.AddField("", ugender);
        form.AddField("", ugameexp);
        //game tracks
        form.AddField("", moves);
        form.AddField("", time);
        form.AddField("", deaths);

        //user provides after playing
        form.AddField("", likegame);
        form.AddField("", suggestions);




        Debug.Log("test ?");
        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
        www.Dispose(); //have to dispose this or we get a memory leak
    }

    public void Send()
    {
        //teststring = test.GetComponent<InputField>().text;

        StartCoroutine(Post(uname, uage,  ugender,  ugameexp,  moves,  time,  deaths,  likegame,  suggestions));
    }
}
