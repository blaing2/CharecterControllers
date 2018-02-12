using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRotatScript : MonoBehaviour
{
  public float rotationSpeed = 360F;


	// Use this for initialization
	void Start ()
  {
		
	} // end START
	
	// Update is called once per frame
	void Update ()
  {
    transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);




	} // end UPDATE

} // end CLASS
