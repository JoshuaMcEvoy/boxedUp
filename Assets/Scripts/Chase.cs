using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chase : MonoBehaviour {

	public Transform player;
	static Animator anim;

	public Slider healthbar;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (healthbar.value <= 0)
			return;

		//works out the direction from the player to the enemy
		Vector3 direction = player.position - this.transform.position;
		//creates an angle view in front of the enemy
		float angle = Vector3.Angle (direction, this.transform.forward);

		if (Vector3.Distance(player.position, this.transform.position) < 10 && angle < 90) {
			

			//stops the enemy from falling backwards when you get too close. 
			direction.y = 0;
			//slowly turn the enemy to face the player.
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.7f);

			//set animation booleans 
			anim.SetBool ("isIdle", false);
			if (direction.magnitude > 1) {  
				//this will make enemy slow once out of range
				this.transform.Translate(0, 0, 0.2f);
				Debug.Log ("Walking");
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);
			} else {
				
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isWalking", false);
			}
		} else {
//			Debug.Log ("Idle");
			anim.SetBool ("isIdle", true);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", false);
		}
		
	}
}
