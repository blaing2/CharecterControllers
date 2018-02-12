using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputDebug : MonoBehaviour
{

  public Transform upBox, downBox, leftBox, rightBox;

  public float motionScale = 10F;




	// Use this for initialization
	void Start ()
  {
		
	} // end START
	
	// Update is called once per frame
	void Update ()
  {
    float mouseX = Input.GetAxis("Mouse X");
    float mouseY = Input.GetAxis("Mouse Y");

    upBox.localScale = new Vector3(1, 0.1F, 1);
    downBox.localScale = new Vector3(1, 0.1F, 1);
    leftBox.localScale = new Vector3(1, 0.1F, 1);
    rightBox.localScale = new Vector3(1, 0.1F, 1);


    if (mouseX > 0)
    {
      // scale right box
      rightBox.localScale = new Vector3(1, mouseX * motionScale, 1);

    } // end RIGHT BOX

    if (mouseX < 0)
    {
      // scale left box
      leftBox.localScale = new Vector3(1, mouseX * motionScale, 1);

    } // end LEFT BOX

    if (mouseY > 0)
    {
      // scale up box
      upBox.localScale = new Vector3(1, mouseY * motionScale, 1);

    } // end up BOX

    if (mouseY < 0)
    {
      // scale down box
      downBox.localScale = new Vector3(1, mouseY * motionScale, 1);

    } // end down BOX


  } // end UPDATE

} // end CLASS