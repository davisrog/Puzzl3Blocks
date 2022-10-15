using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Moves : MonoBehaviour
{

    public TextMeshProUGUI movesText;

    public int moves;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moves = DataCollector.Instance.GetMoves();
        movesText.text = moves.ToString();
    }
}
