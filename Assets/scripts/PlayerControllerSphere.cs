using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSphere : MonoBehaviour
{
    public Rigidbody ps;
    private float pushForce = 10f;

    //used to reset player after death
    Vector3 playerstart;
    Quaternion playerstartrotation;
    

    public DataCollector dataCollector = new DataCollector();//data collector
    float x = 0;
    float z = 0;
    //float keystroke = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        playerstart = ps.position;
        dataCollector.SetStartTime();

    }

    // Update is called once per frame good for receiving inputs
    void Update()
    {
        if (transform.position.y < -5f)  //death
        {
            dataCollector.IncrementDeaths();
            ps.velocity = Vector3.zero;
            ps.angularVelocity = Vector3.zero;
           // Debug.Log(ps.angularVelocity);
           // Debug.Log(ps.velocity);

            ps.position = playerstart;
           // Debug.Log("playerstart: " + playerstart);
           // Debug.Log("position: " + ps.position);
            //ps.rotation = playerstartrotation;
            Debug.Log("deaths: " + dataCollector.GetDeaths());
           // ps.velocity = Vector3.zero;
           // ps.angularVelocity = Vector3.zero;
        }

        ProcessKeys();   

    }

    void FixedUpdate() // used for physics to act right even if there's lag and so on that may affect Update
    {
        Move();
    }

    private void ProcessKeys()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("right") || Input.GetKeyDown("left") || Input.GetKeyDown("down") || Input.GetKeyDown("up"))
        {
            Debug.Log("moves before push: " + dataCollector.GetMoves());
            dataCollector.IncrementMoves();
            Debug.Log("moves after push: " + dataCollector.GetMoves());
            if (dataCollector.GetMoves() < 1)
            {
                dataCollector.SetStartTime();
            }
        }

       /* if (Input.GetKeyDown("right"))
        {
            keystroke += 1;
        }
        if (Input.GetKeyDown("left"))
        {
            keystroke += 1;
        }
        if (Input.GetKeyDown("up"))
        {
            keystroke += 1;
        }
        if (Input.GetKeyDown("down"))
        {
            keystroke += 1;
        }
/*
        if (x != 0 || z != 0)
        {
            keystroke += 1;
        }*/
       // Debug.Log(keystroke);
    }
    void Move()
    {
        ps.AddForce(new Vector3(x, 0, z) * pushForce);

 
    }
}
