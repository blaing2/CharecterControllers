using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationAngle = 2f;
    public Transform playerCamera;
    public Transform playerModel;

	// Update is called once per frame
	void Update ()
    {

        float xAxis = Input.GetAxis("Mouse X");
        float yAxis = Input.GetAxis("Mouse Y");
        float eularAngleLimit = playerCamera.transform.eulerAngles.x;
        float minview = -90;
        float maxview = 90;

        if(eularAngleLimit > 180)
        {
            eularAngleLimit -= 360;
        }
        else if(eularAngleLimit < -180)
        {
            eularAngleLimit += 360;
        }

        float targetRotation = eularAngleLimit + yAxis * -rotationAngle * Time.deltaTime;

        if (xAxis > 0)
        {
            playerCamera.transform.Rotate(Vector3.up, rotationAngle, Space.World);
            //if(playerModel.transform.rotation != playerCamera.transform.rotation)
            //{
            //    playerCamera.transform.LookAt(playerModel);
            //}

        }
        else if (xAxis < 0)
        {
            playerCamera.transform.Rotate(Vector3.up, -rotationAngle, Space.World);
        }

        if(targetRotation<maxview && targetRotation> minview)
        {
            playerCamera.transform.eulerAngles += new Vector3(yAxis * -rotationAngle * Time.deltaTime, 0, 0);
        }
        

    }
}
