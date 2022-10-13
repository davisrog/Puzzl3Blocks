using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GoalScript : MonoBehaviour
{
    private int endmoves = 0;
    private int enddeaths = 0;
    private int movetooklongest = 0;
    private TimeSpan longesttimemove;
    private string longesttimemoveToSend;
    private TimeSpan deltaTime;
    private string deltaTimeToSend;
    string currentScene;
    //SendToGoogleForm sendtoGoogleForm;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Player1x1x2Controller component = other.gameObject.GetComponent<Player1x1x2Controller>();
        
        if (component != null)
        {
            Debug.Log("this hit?");
            Debug.Log(component);
            DataCollector.Instance.SetEndTime();
            Debug.Log("starttime: " + DataCollector.Instance.GetStartTime());
            Debug.Log("endtime: " + DataCollector.Instance.GetEndTime());
            endmoves = DataCollector.Instance.GetMoves();
            movetooklongest = DataCollector.Instance.GetMoveTookLongest();
            deltaTime = DataCollector.Instance.GetDeltaTime();
            deltaTimeToSend = deltaTime.ToString("G");
            longesttimemove = DataCollector.Instance.GetMaxMoveTime();
            longesttimemoveToSend = longesttimemove.ToString("G");
            Debug.Log("deltatime: " + longesttimemoveToSend);
            Debug.Log("timespan: " + longesttimemove);
            currentScene = SceneManager.GetActiveScene().name;
            //deltaTime = deltaTime.ToString();
            enddeaths = DataCollector.Instance.GetDeaths();
            Debug.Log(endmoves);

            SendToGoogleForm.Instance.Send(endmoves, movetooklongest, deltaTimeToSend, longesttimemoveToSend, enddeaths, "tell you later", "tesll you later", "non-cube", currentScene);

        }


    }
    }

