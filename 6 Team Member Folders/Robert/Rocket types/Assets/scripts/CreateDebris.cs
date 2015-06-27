using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateDebris : MonoBehaviour {

	public GameObject debris;
	public float minValue;
	public float maxValue;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			Vector3 position = new Vector3(Random.Range(minValue, maxValue), 1, Random.Range(minValue, maxValue));
			Instantiate(debris, position, Quaternion.identity);
			//Destroy(gameObject);
		}
	}
}
