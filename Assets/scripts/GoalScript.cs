using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Player1x1x2Controller component = other.gameObject.GetComponent<Player1x1x2Controller>();
        if (component != null)
        {
            Debug.Log("this hit?");
        }
    }
    }

