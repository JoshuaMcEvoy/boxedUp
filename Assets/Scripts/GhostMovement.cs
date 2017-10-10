using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour {

	public int rotateSpeed = 50;
	public int movementSpeed = 30;
	public float maxDistance;

	private Transform myTransform;
	public Transform target;



	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;
		maxDistance = 5;
		myTransform = transform;

	}
	
	// Update is called once per frame
	void Update () {
		TargetPlayer (); 
	}

	void TargetPlayer () {
		Debug.DrawLine(myTransform.position, target.position, Color.red);
		float distance = Vector3.Distance (target.position, myTransform.position);
		if(distance < maxDistance) {
			//rotate position
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotateSpeed * Time.deltaTime);
			//move towards player
			myTransform.position += myTransform.forward * movementSpeed * Time.deltaTime;
		}

	}
}
