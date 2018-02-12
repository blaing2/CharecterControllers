using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyThirdPersonControler : MonoBehaviour
{

  /*
   * TODO: move direction is based on camera not the player
   * character moves direction their trying to move
   * camera orbs player
   * 
   * player uses mouse scroll wheel to adjust zoom 
   */
  // player move speed
  public float speed = 4.0F;

  // player camera speed
  public float xAxisRotationSpeed = 4.0F;
  public float yAxisRotationSpeed = 4.0F;

  public float mouseY;
  public float mouseX;

  public float maxView = 90.0F;
  public float minView = -90.0F;

  // get cameras info
  public Transform playerCamera;
  public Transform playerCharecter;
  public Transform actuallCamera;

  public float mouseScroolWheel;

  // Update is called once per frame
  void Update()
  {
    // make new move direction
    Vector3 moveDirection = Vector3.zero;

    // move forward on W key
    if (Input.GetKey(KeyCode.W))
    {
      moveDirection += playerCamera.transform.forward;
      //if (playerCharecter.transform.rotation != playerCamera.transform.rotation)
     // {
      //  playerCharecter.transform.rotation = playerCamera.transform.rotation;
      //
     // }

    } // end KEY W

    // move back on S key
    if (Input.GetKey(KeyCode.S))
    {
      moveDirection += -playerCamera.transform.forward;

      //if (playerCharecter.transform.rotation != playerCamera.transform.rotation)
     // {
       // playerCharecter.transform.rotation = playerCamera.transform.rotation;
      //}
    } // end KEY S

    // move left on A key
    if (Input.GetKey(KeyCode.A))
    {
      moveDirection += -playerCamera.transform.right;

    } // end KEY A

    // move right on D key
    if (Input.GetKey(KeyCode.D))
    {
      moveDirection += playerCamera.transform.right;

    } // end KEY D

    // move object
    moveDirection.y = 0;

    if (moveDirection != Vector3.zero)
    {
      playerCamera.transform.forward = moveDirection;
    }

    transform.position += moveDirection.normalized * speed * Time.deltaTime;

    // rotate camera left and right
    mouseX = Input.GetAxis("Mouse X");

    playerCamera.transform.Rotate(Vector3.up, mouseX * xAxisRotationSpeed * Time.deltaTime, Space.World);

    // rotate the camera up and down
    mouseY = Input.GetAxis("Mouse Y");
    float angleEulerLimit = playerCamera.transform.eulerAngles.x;

    if (angleEulerLimit > 180)
    {
      angleEulerLimit -= 360;
    }

    if (angleEulerLimit < -180)
    {
      angleEulerLimit += 360;
    }

    float targetRotation = angleEulerLimit + mouseY * -yAxisRotationSpeed * Time.deltaTime;

    if (targetRotation < maxView && targetRotation > minView)
    {
      playerCamera.transform.eulerAngles += new Vector3(mouseY * -yAxisRotationSpeed * Time.deltaTime, 0, 0);

    } // end TARGET ROTATION

    //mouseScroolWheel += Input.GetAxis("Mouse ScrollWheel");

    
    

  } // end UPDATE

} // end CLASS
