using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSphere : MonoBehaviour
{
    public Rigidbody ps;
    private float pushForce = 10f;

    float x = 0;
    float z = 0;
    //float keystroke = 0;
   
    // Start is called before the first frame update
    void Start()
    {
      //  playerdimenions = transform.lossyScale;   //get the dimensions

    }

    // Update is called once per frame good for receiving inputs
    void Update()
    {
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
