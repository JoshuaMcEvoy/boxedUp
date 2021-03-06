﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

	private const float Y_ANGLE_MIN = 5.0f;
	private const float Y_ANGLE_MAX = 50.0f;

	public Transform lookAt; 
	public Transform camTransform;

	private Camera cam;

	public float distance = 5.0f;
	private float currentX = 0.0f;
	private float currentY = 0.0f;
	private float sensivityX = 4.0f;
	private float sensivityY = 1.0f;



	private void Start(){
		camTransform = transform;
		cam = Camera.main;
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update(){
		currentY = Mathf.Clamp (currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
		currentX += Input.GetAxis ("Mouse X");
		currentY += Input.GetAxis ("Mouse Y");

		if(Input.GetKeyDown("escape")){
			Cursor.lockState = CursorLockMode.None;
		}

		if (Input.GetAxis ("Mouse ScrollWheel") < 0 && distance < 10) {
			distance += 0.5f;
		} else if (Input.GetAxis ("Mouse ScrollWheel") > 0 && distance > 0) {
			distance -= 0.5f;
		}
	}

	private void LateUpdate(){
		Vector3 dir = new Vector3(0, 0, distance);
		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
		//put camera on the player, apply the rotation then times by the direction
		camTransform.position = lookAt.position - rotation * dir;
		camTransform.LookAt (lookAt.position);
	}
}
