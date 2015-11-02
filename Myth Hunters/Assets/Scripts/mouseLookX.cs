﻿using UnityEngine;
using System.Collections;

public class mouseLookX : MonoBehaviour {
	
public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
public RotationAxes axes = RotationAxes.MouseXAndY;
public float sensitivityX = 15;
public float sensitivityY = 15;

public float minimumX = -360;
public float maximumX = 360;

public float minimumY = -60;
public float maximumY = 60;

float rotationY = 0;

void Update ()
{
	if (axes == RotationAxes.MouseXAndY)
	{
		float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
		
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
		
		transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
	}
	else if (axes == RotationAxes.MouseX)
	{
		transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
	}
	else
	{
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
		
		transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
	}
}

void Start ()
{
	//Hide cursor
	Cursor.visible = false;
	// Make the rigid body not change rotation
	if (GetComponent<Rigidbody>())
		GetComponent<Rigidbody>().freezeRotation = true;
}

}