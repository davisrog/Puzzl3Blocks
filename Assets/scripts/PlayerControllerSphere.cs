using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerSphere : MonoBehaviour
{
    public Rigidbody ps;
    private float pushForce = 10f;

    //used to reset player after death
    Vector3 playerstart;
    Quaternion playerstartrotation;
    

    //public DataCollector dataCollector = new DataCollector();//data collector
    float x = 0;
    float z = 0;
    //float keystroke = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        playerstart = ps.position;
        DataCollector.Instance.SetStartTime();
        DataCollector.Instance.SetStartMoveTime();

    }

    // Update is called once per frame good for receiving inputs
    void Update()
    {
        // Check for Game Won
        if (!DataCollector.Instance.GetLives().Equals(0) && SendToGoogleForm.Instance.GetUploadCompletedStatus().Equals(true)) { 
            GameOverController.SetLevelScene();
            SceneManager.LoadScene("GameWinScreen"); 
            SendToGoogleForm.Instance.SetUploadCompletedStatus(false);
        }
        //Check for Game Over
        if (DataCollector.Instance.GetLives().Equals(0)) { 
            GameOverController.SetLevelScene();
            DataCollector.Instance.SetLives();
            SceneManager.LoadScene("GameOverScreen");
        }
  
        ProcessKeys();   

    }



    void FixedUpdate() // used for physics to act right even if there's lag and so on that may affect Update
    {
        if (transform.position.y < -5f)  //death -- was counting twice when I had it in Update
        {

            ps.velocity = Vector3.zero;
            ps.angularVelocity = Vector3.zero;
            ps.position = playerstart;

            DataCollector.Instance.IncrementDeaths();

        }

        Move();
    }

    private void ProcessKeys()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // ps.velocity = Vector3.zero;
            // ps.angularVelocity = Vector3.zero;
            if (ps.drag < 20)
            {
                ps.drag += 5;
                DataCollector.Instance.IncrementBrakes();
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ps.drag = 0;
        }

        if (Input.GetKeyDown("right") || Input.GetKeyDown("left") || Input.GetKeyDown("down") || Input.GetKeyDown("up"))
        {
            //Debug.Log("moves before push: " + DataCollector.Instance.GetMoves());
            DataCollector.Instance.IncrementMoves();
           // Debug.Log("moves after push: " + DataCollector.Instance.GetMoves());
           // Debug.Log("max move time: " + DataCollector.Instance.GetMaxMoveTime());
           // if (dataCollector.GetMoves() < 1)
           // {
          //      dataCollector.SetStartTime();
           // }
        }

 
    }
    void Move()
    {
        ps.AddForce(new Vector3(x, 0, z) * pushForce);

 
    }
}
