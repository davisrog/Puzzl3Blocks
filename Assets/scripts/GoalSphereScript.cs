using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GoalSphereScript : MonoBehaviour
{
    
    private int endmoves = 0;
    private int enddeaths = 0;
    private TimeSpan deltaTime;
    private string deltaTimeToSend;
    //SendToGoogleForm sendtoGoogleForm;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        PlayerControllerSphere component = other.gameObject.GetComponent<PlayerControllerSphere>();

        if (component != null)
        {
            Debug.Log("this hit?");
            Debug.Log(component);
            component.dataCollector.SetEndTime();
            Debug.Log("starttime: " + component.dataCollector.GetStartTime());
            Debug.Log("endtime: " + component.dataCollector.GetEndTime());
            endmoves = component.dataCollector.GetMoves();
            deltaTime = component.dataCollector.GetDeltaTime();
            deltaTimeToSend = deltaTime.ToString("G");
            Debug.Log("deltatime: " + deltaTimeToSend);
            Debug.Log("timespan: " + deltaTime);
            //deltaTime = deltaTime.ToString();
            enddeaths = component.dataCollector.GetDeaths();
            Debug.Log(endmoves);

            SendToGoogleForm.Instance.Send(endmoves, deltaTimeToSend, enddeaths, "hate it", "no suggestions, you suck", "sphere", "i hate puzzle games");

        }


    }
}
