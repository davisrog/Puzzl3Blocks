using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; //webrequest
using System;

public class SendToGoogleForm : MonoBehaviour
{
    

    private string uname = "";
    private string uage = "";
    private string ugender = "";
    private string ugameexp = "";
   // private string likepuzzlegames = "";

    //private int moves;
    //private string timeonlevel;
    //private int deaths;
    private string likegame;
    private string suggestions;
    private string avatar_type;

    private static SendToGoogleForm _instance;

    public static SendToGoogleForm Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        
    }


    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSeB_AIXc1_scX8sK3FcIrVIBRrS2NSj8heA06DXil5QrbeccA/formResponse";  //get from google
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

    //IEnumerator Post(string uname, string uage, string ugender, string ugameexp, int moves, string timeonlevel, int deaths, string likegame, string suggestions, string avatar_type, string likepuzzlegames)
    IEnumerator Post(int moves, TimeSpan timeonlevel, int deaths, string likegame, string suggestions, string avatar_type, string likepuzzlegames)
    {
        WWWForm form = new WWWForm();
       // timeonlevel = timeonlevel.ToString(@"hh\:mm\:ss");
        //dependent variables the user provides
        form.AddField("entry.911002939", uname);
        form.AddField("entry.96120943", uage);
        form.AddField("entry.776381412", ugender);
        form.AddField("entry.59901152", ugameexp);
        form.AddField("entry.1004050490", likepuzzlegames);
        //game tracks
        form.AddField("entry.1234682582", moves);
       // form.AddField("entry.1738161824", timeonlevel);
        form.AddField("entry.1758611915", deaths);

        //user provides after playing
        form.AddField("entry.1147099413", likegame);
        form.AddField("entry.1912895330", suggestions);
        form.AddField("entry.746764486", avatar_type);




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

    public void Send(int moves, TimeSpan timeonlevel, int deaths, string likegame, string suggestions, string avatar_type, string likepuzzlegames)
    {
        //teststring = test.GetComponent<InputField>().text;
        /* moves = dataCollector.GetMoves();
         deaths = dataCollector.GetDeaths();
         timeonlevel = dataCollector.GetDeltaTime();
 */
        StartCoroutine(Post(moves, timeonlevel, deaths, likegame, suggestions, avatar_type, likepuzzlegames));
       // StartCoroutine(Post(uname, uage, ugender, ugameexp, moves, timeonlevel, deaths, likegame, suggestions, avatar_type, likepuzzlegames));
    }
}
