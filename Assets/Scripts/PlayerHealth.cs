using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int currentHealth;
	public int maximumHealth = 100;

	public float hbLength;

	// Use this for initialization
	void Start () {
		currentHealth = maximumHealth;

		hbLength = Screen.width / 2;


	}

	// Update is called once per frame
	void Update () {
		ChangeHealth(0);
	}

	void OnGUI (){
		GUI.Box (new Rect(10, 10, hbLength, 25), currentHealth + " / " + maximumHealth);
	}

	public void ChangeHealth (int health) {
		currentHealth += health;
		hbLength = (Screen.width / 2) * (currentHealth / (float)maximumHealth);
		if (currentHealth <= 0) {
			Dead ();
		}
	}

	void Dead(){
		Destroy (this.gameObject);
		Debug.Log ("you died");
	}
}﻿