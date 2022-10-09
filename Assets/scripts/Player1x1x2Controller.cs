using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player1x1x2Controller : MonoBehaviour
{
    //private float buttonSensitivity = 0.2f;  //for controller input
    private float rollDuration = .25f;
    private bool isRotating = false;
    // private bool isMoving = false;
    private Rigidbody box;
    Vector3 playerdimenions;
    Vector3 playerstart;
    Quaternion playerstartrotation;
    float dirX = 0;
    float dirZ = 0;
    float rollTime = 0;
    public DataCollector dataCollector = new DataCollector(); //not monobehavior
    

    float center = 1; //I guess it's the radius
    float startAngleRad = 0;
    Vector3 startPosition;          //start position, position is a vector
    Quaternion startRotation;           //angles...nasty quaternion
    Quaternion toRotation;          //nasty nasty quaternion
    // Start is called before the first frame update
    void Start()
    {
       // dataCollector dataCollector;
        playerdimenions = transform.lossyScale;   //get the dimensions
        playerstart = transform.position;
        playerstartrotation = transform.rotation;
        //DataCollector dataCollector = new DataCollector();
        box = GetComponent<Rigidbody>();
        
   
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5f)
        {
            dataCollector.IncrementDeaths();
            transform.position = playerstart;
            transform.rotation = playerstartrotation;
            Debug.Log("deaths: " + dataCollector.GetDeaths());
        }
        float x = 0;
        float y = 0;
            if (Input.GetKeyDown("right"))
            {
            x = -1;
            }
            if (Input.GetKeyDown("left"))
            {
            x = 1;
            }
            if (Input.GetKeyDown("up"))
            {
            y = 1;
            }
            if (Input.GetKeyDown("down"))
            {
            y = -1;
            }
        if ( !IsMoving() && (x != 0 || y != 0))
        {
            Debug.Log("moves before push: " + dataCollector.GetMoves());
            dataCollector.IncrementMoves();
            Debug.Log("moves after push: " + dataCollector.GetMoves());
            if (dataCollector.GetMoves() < 1)
            {
                dataCollector.SetStartTime();
            }
            dirX = x;    //x direction
            dirZ = y;   //z direction
            startPosition = transform.position;         //starting position
            startRotation = transform.rotation;         //starting rotation
            transform.Rotate(dirZ * 90, 0, dirX * 90, Space.World);     //90 degree rotate
            toRotation = transform.rotation;                    //get that rotation point
            transform.rotation = startRotation;             //set the player's rotation back where it started
            setCenterAndAngle();
           // Debug.Log(dataCollector.GetMoves());
            rollTime = 0;
            isRotating = true;
        }
    }

    void FixedUpdate() // used for physics to act right even if there's lag and so on that affects Update
    {
        if (isRotating)
        {
            rollTime += Time.fixedDeltaTime;                //increase rotation time by deltatime (inceases at fixedupdate interval)
            float rotationRatio = Mathf.Lerp(0, 1, rollTime / rollDuration);   //lerp makes things look smooth moves the ratio from 0 to 1 at a linear rate of the time/duration ratio
            float radRotation = Mathf.Lerp(0, Mathf.PI / 2f, rotationRatio);  //go from 0 to 90 degrees as the rotationration changes
            float disX = -dirX * center * (Mathf.Cos(startAngleRad) - Mathf.Cos(startAngleRad + radRotation));  //new position x component
            float disY = center * (Mathf.Sin(startAngleRad + radRotation) - Mathf.Sin(startAngleRad));          //new position y component  (should be .5 or 1 depending on orientation)
            float disZ = dirZ * center * (Mathf.Cos(startAngleRad) - Mathf.Cos(startAngleRad + radRotation));   // new position z component
            transform.position = new Vector3(startPosition.x + disX, startPosition.y + disY, startPosition.z + disZ);  //new position
            transform.rotation = Quaternion.Lerp(startRotation, toRotation, rotationRatio);   //move it smoothly to the end rotation

            //reset once we complete the move
            if (rotationRatio == 1)
            {
                //new WaitForSeconds(20);  //wait to reset flags so the block can fall
                isRotating = false;
                dirX = 0;
                dirZ = 0;
                rollTime = 0;

            }
        }
    }

    bool IsMoving()
    {
        return (isRotating || !box.IsSleeping());
    }

    //this finds the mid point of the 3d rectangle...and the angle it's pointed...
    void setCenterAndAngle()
    {
        Vector3 dirVec = new Vector3(0, 0, 0);    //direction vector set based on our direction
        Vector3 upVector = new Vector3(0, 1, 0);              //up vector

        if (dirX != 0)
        {
            dirVec = new Vector3(1, 0, 0);   //direction right
        }
        if (dirZ != 0)
        {
            dirVec = new Vector3(0, 0, 1);  //direction "forward"
        }

        //this gives us our orientation and calculates our angle and length for the center point. dot product should equal 1 but using > .98 to allow for some inaccuracies in calculations
        if (Mathf.Abs(Vector3.Dot(transform.right, dirVec)) > 0.98) //  is direction right/lef?
        {                        
            if (Mathf.Abs(Vector3.Dot(transform.up, upVector)) > 0.98)   
            {                   
                center = Mathf.Sqrt(Mathf.Pow(playerdimenions.x / 2f, 2f) + Mathf.Pow(playerdimenions.y / 2f, 2f)); // square root of ((x/2)sqrd + ((y/2)sqrd)
                startAngleRad = Mathf.Atan(playerdimenions.y / playerdimenions.x);// arctan 
   
               
            }
            else if (Mathf.Abs(Vector3.Dot(transform.forward, upVector)) > 0.98)
            {       
                    
                center = Mathf.Sqrt(Mathf.Pow(playerdimenions.x / 2f, 2f) + Mathf.Pow(playerdimenions.z / 2f, 2f));

                startAngleRad = Mathf.Atan(playerdimenions.z / playerdimenions.x);
               
            }

        }
        else if (Mathf.Abs(Vector3.Dot(transform.up, dirVec)) > 0.98)
        {                   // 
            if (Mathf.Abs(Vector3.Dot(transform.right, upVector)) > 0.98)
            {                   // 
                center = Mathf.Sqrt(Mathf.Pow(playerdimenions.y / 2f, 2f) + Mathf.Pow(playerdimenions.x / 2f, 2f));

                startAngleRad = Mathf.Atan(playerdimenions.x / playerdimenions.y);
            }
            else if (Mathf.Abs(Vector3.Dot(transform.forward, upVector)) > 0.98)
            {       
                center = Mathf.Sqrt(Mathf.Pow(playerdimenions.y / 2f, 2f) + Mathf.Pow(playerdimenions.z / 2f, 2f));
       
                startAngleRad = Mathf.Atan(playerdimenions.z / playerdimenions.y);
            }
        }
        else if (Mathf.Abs(Vector3.Dot(transform.forward, dirVec)) > 0.98)
        {           //

            if (Mathf.Abs(Vector3.Dot(transform.right, upVector)) > 0.98)
            {                   
                center = Mathf.Sqrt(Mathf.Pow(playerdimenions.z / 2f, 2f) + Mathf.Pow(playerdimenions.x / 2f, 2f));
            
                startAngleRad = Mathf.Atan(playerdimenions.x / playerdimenions.z);
            }
            else if (Mathf.Abs(Vector3.Dot(transform.up, upVector)) > 0.98)
            {               
                center = Mathf.Sqrt(Mathf.Pow(playerdimenions.z / 2f, 2f) + Mathf.Pow(playerdimenions.y / 2f, 2f));
             
                startAngleRad = Mathf.Atan(playerdimenions.y / playerdimenions.z);
            }
        }
        

    }
    

    






    
}
