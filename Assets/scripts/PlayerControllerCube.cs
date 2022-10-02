using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCube : MonoBehaviour
{
    //private float buttonSensitivity = 0.2f;  //for controller input
    private float rollTime = .25f;
    private bool isMoving = false;
    //public Transform pivot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown("right"))
            {
                //  transform.Translate(transform.right);
                StartCoroutine(Roll(Vector3.right));
                return;
            }
            if (Input.GetKeyDown("left"))
            {
                // transform.Translate(-transform.right);
                StartCoroutine(Roll(Vector3.left));
                return;
            }
            if (Input.GetKeyDown("up"))
            {
                // transform.Translate(transform.forward);
                StartCoroutine(Roll(Vector3.forward));
                return;
            }
            if (Input.GetKeyDown("down"))
            {
                // transform.Translate(-transform.forward);
                StartCoroutine(Roll(Vector3.back));
                return;
            }
        }
    }
        
    

  

    private IEnumerator Roll(Vector3 direction)
    {
        isMoving = true;
        float rollRate = 0;
        float pivotAngle = 90;
        float midPtWidth = transform.localScale.x / 2;  //midpoint of the width
        Vector3 pointAround = transform.position + (Vector3.down * midPtWidth) + (direction * midPtWidth);  //point we're rotating around
        //Debug.Log("pointAroundCube: " + pointAround);
        Vector3 pivotAxis = Vector3.Cross(Vector3.up, direction);
        //Debug.Log("pivotAxisCube: " + pivotAxis);

        Quaternion rotation = transform.rotation;
        Quaternion endRotation = rotation * Quaternion.Euler(pivotAxis * pivotAngle);
        Vector3 endPosition = transform.position + direction;

        float originalAngle = 0;

        while (rollRate < rollTime)
        {
            yield return new WaitForEndOfFrame();
            rollRate += Time.deltaTime;
            float newAngle = (rollRate / rollTime) * pivotAngle;
            float rotateThrough = newAngle - originalAngle;
            originalAngle = newAngle;
            transform.RotateAround(pointAround, pivotAxis, rotateThrough);
        }

        transform.position = endPosition;
        transform.rotation = endRotation;
        isMoving = false;

    }


}
