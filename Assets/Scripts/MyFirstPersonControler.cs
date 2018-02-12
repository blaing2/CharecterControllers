using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstPersonControler : MonoBehaviour
{
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
	// Update is called once per frame
	void Update ()
  {
  // Get WASD movement working
    Vector3 moveDirection = Vector3.zero;

    if (Input.GetKey(KeyCode.W))
    {
      moveDirection += transform.forward;

    } // end KEY W

    if (Input.GetKey(KeyCode.S))
    {
      moveDirection += -transform.forward;

    } // end KEY S

    if (Input.GetKey(KeyCode.A))
    {
      moveDirection += -transform.right;

    } // end KEY A

    if (Input.GetKey(KeyCode.D))
    {
      moveDirection += transform.right;

    } // end KEY D

    transform.position += moveDirection.normalized * speed * Time.deltaTime;

    // rotate camera left and right
    mouseX = Input.GetAxis("Mouse X");

    transform.Rotate(Vector3.up, mouseX * xAxisRotationSpeed * Time.deltaTime);

    // rotate the camera up and down
    mouseY = Input.GetAxis("Mouse Y") ;
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

  } // end UPDATE

} // end CLASS
