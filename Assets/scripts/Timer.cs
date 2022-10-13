using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    //public float countUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Icrease count
        currentTime = currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("0.00"); //Convert timer to show seconds in 0.00 fromat
    }
}
