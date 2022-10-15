using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GoalSphereScript : MonoBehaviour
{

    private int endmoves = 0;
    private int enddeaths = 0;
    private int hints = 0;
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
        PlayerControllerSphere component = other.gameObject.GetComponent<PlayerControllerSphere>();

        if (component != null)
        {
            //Debug.Log("this hit?");
            Debug.Log(component);
            DataCollector.Instance.SetEndTime();
            //Debug.Log("starttime: " + DataCollector.Instance.GetStartTime());
            //Debug.Log("endtime: " + DataCollector.Instance.GetEndTime());
            endmoves = DataCollector.Instance.GetMoves();
            movetooklongest = DataCollector.Instance.GetMoveTookLongest();
            deltaTime = DataCollector.Instance.GetDeltaTime();
            deltaTimeToSend = deltaTime.ToString("G");
            longesttimemove = DataCollector.Instance.GetMaxMoveTime();
            longesttimemoveToSend = longesttimemove.ToString("G");
            //Debug.Log("deltatime: " + deltaTimeToSend);
            //Debug.Log("timespan: " + deltaTime);
            currentScene = SceneManager.GetActiveScene().name;
            //deltaTime = deltaTime.ToString();
            enddeaths = DataCollector.Instance.GetDeaths();
            hints = DataCollector.Instance.GetHints();
            DataCollector.Instance.ResetHints();
            DataCollector.Instance.ResetMoves();
            //Debug.Log(endmoves);

            SendToGoogleForm.Instance.Send(endmoves, movetooklongest, deltaTimeToSend, longesttimemoveToSend, enddeaths, hints, "n/a", "n/a", "non-cube", currentScene, "n/a", "n/a");

        }


    }
}
