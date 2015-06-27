﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateDebris : MonoBehaviour {

	public GameObject debris;
	public float minValue;
	public float maxValue;


	private float delayTimer = 1f;
	private float junkTimer = 0;


	void Update () 
	{
		delayTimer -= Time.deltaTime;

		if(delayTimer <= 0 && GetComponent<Rigidbody> ().velocity.magnitude > 3){
			//Vector3 position = new Vector3(Random.Range(minValue, maxValue), Random.Range(minValue, maxValue), 0);
			if(junkTimer <= 0){
				Instantiate(debris, transform.position - transform.up, Quaternion.identity);
				junkTimer = 1;
			}
			junkTimer -= Time.deltaTime * 2.5f;
		}
	}
}
