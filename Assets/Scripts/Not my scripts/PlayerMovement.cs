using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; //speed of objects in unity units per second
    public float constraints = 5f;
    public float rotationAngle = 2f;
    public Transform playerCamera;
    public Transform playerModel;
   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Mouse X");
        float yAxis = Input.GetAxis("Mouse Y");
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        //make it so the ball can only go in the 4 main directions
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position = transform.position + (new Vector3(0,0,1)) * Time.deltaTime * moveSpeed;
            if(playerModel.transform.forward != playerCamera.transform.forward)
            {
                Vector3 cameraForward = playerCamera.transform.forward;
                cameraForward.y = 0;
                playerModel.transform.forward = cameraForward;
                playerModel.transform.position = playerModel.transform.position + (cameraForward) * Time.deltaTime * moveSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //transform.position = transform.position + (new Vector3(0, 0, -1)) * Time.deltaTime * moveSpeed;
            if (playerModel.transform.forward != playerCamera.transform.forward)
            {
                Vector3 cameraForward = playerCamera.transform.forward;
                cameraForward.y = 0;
                playerModel.transform.forward = cameraForward;
                playerModel.transform.position = playerModel.transform.position + (-cameraForward) * Time.deltaTime * moveSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //transform.position = transform.position + (new Vector3(1, 0, 0)) * Time.deltaTime * moveSpeed;
            if (playerModel.transform.forward != playerCamera.transform.forward)
            {
                Vector3 cameraForward = playerCamera.transform.right;
                cameraForward.y = 0;
                playerModel.transform.forward = cameraForward;
                playerModel.transform.position = playerModel.transform.position + (cameraForward) * Time.deltaTime * moveSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //transform.position = transform.position + (new Vector3(-1, 0, 0)) * Time.deltaTime * moveSpeed;
            if (playerModel.transform.forward != playerCamera.transform.forward)
            {
                Vector3 cameraForward = playerCamera.transform.right;
                cameraForward.y = 0;
                playerModel.transform.forward = -cameraForward;
                playerModel.transform.position = playerModel.transform.position + (cameraForward) * Time.deltaTime * moveSpeed;
            }
        }

        //mouse scroll wheel
        if(scrollWheel > 0f)
        {
            Camera.main.fieldOfView -= 5f;
        }
        else if(scrollWheel < 0f)
        {
            Camera.main.fieldOfView += 5f;
        }

        //constrain to constrainDis units in x and z from the origin
        //bool theCleanWay = true;
        //if (theCleanWay)
        //{
        //    Vector3 clampedPos = new Vector3(Mathf.Clamp(transform.position.x, -constraints, constraints), transform.position.y, Mathf.Clamp(transform.position.z, -constraints, constraints));
        //    transform.position = clampedPos;
        //}

        //camera rotation
        float eulerAngleLimit = playerCamera.transform.eulerAngles.x;
        float minview = -15f;
        float maxview = 60f;

        if (eulerAngleLimit > 180)
        {
            eulerAngleLimit -= 360;
        }
        else if (eulerAngleLimit < -180)
        {
            eulerAngleLimit += 360;
        }

        float targetRotation = eulerAngleLimit + yAxis * -rotationAngle;

        if (xAxis > 0)
        {
            playerCamera.transform.Rotate(Vector3.up, rotationAngle, Space.World);
        }
        else if (xAxis < 0)
        {
            playerCamera.transform.Rotate(Vector3.up, -rotationAngle, Space.World);
        }

        if (targetRotation < maxview && targetRotation > minview)
        {
            playerCamera.transform.eulerAngles += new Vector3(yAxis * -rotationAngle, 0, 0);
        }

    }
}