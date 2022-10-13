using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    public int currentlives;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentlives = DataCollector.Instance.GetLives();
        livesText.text = currentlives.ToString();
    }
}
