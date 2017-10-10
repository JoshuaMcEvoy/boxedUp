using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectHit : MonoBehaviour {

	public Slider healthbar;
	Animator anim;

	public string opponent;


	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag != opponent)
			return;

		//listen for left mouse click
		if (Input.GetMouseButtonDown(0)){
			//set time out
			//reset timeout
			healthbar.value -= 20;
	//		Debug.Log ("hit");
		}

		if (healthbar.value <= 0) {
			anim.SetBool ("isDead", true);
		}
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
