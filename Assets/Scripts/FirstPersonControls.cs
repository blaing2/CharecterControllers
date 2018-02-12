using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonControls : MonoBehaviour {

  public float speed = 4.0F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
  {
    Vector3 moveDirection = Vector3.zero;

    if (Input.GetKey(KeyCode.W))
    {
      //transform.position += new Vector3(0, 0, 1);

      moveDirection += transform.forward;

    } // end KEY W

    if (Input.GetKey(KeyCode.S))
    {
      //transform.position += new Vector3(0, 0, -1);
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


  }
}
