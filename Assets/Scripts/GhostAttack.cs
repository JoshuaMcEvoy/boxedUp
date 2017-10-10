using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttack : MonoBehaviour {

	public float maxDistance;
	public float coolDownTimer;
	public PlayerHealth ph;
	public int damage;

	private Transform myTransform;
	private Transform target;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;
		myTransform = transform;
		//how close the emeny will get to the player.
		maxDistance = 1;
		coolDownTimer = 0;
		//how much hp the player will lose with each attack.
		damage = -2;

		ph = (PlayerHealth)go.GetComponent (typeof(PlayerHealth));
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (target.position, myTransform.position);
		if(distance < maxDistance) {
			Attack();
		}

		if (coolDownTimer > 0) {
			coolDownTimer = coolDownTimer * Time.deltaTime;
		}
	}

	void Attack (){

		//check to see if the ghost is looking forward.
		Vector3 dir = Vector3.Normalize (target.position - myTransform.position);
		float direction = Vector3.Dot (dir, transform.forward);
		if(direction > 0){
			if (coolDownTimer == 0 && ph.currentHealth > 0 ) {
				ph.ChangeHealth (damage);
				coolDownTimer = 2;
			}
		}
	}
}
