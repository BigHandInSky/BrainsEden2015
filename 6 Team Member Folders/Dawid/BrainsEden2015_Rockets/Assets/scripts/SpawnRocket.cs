using UnityEngine;
using System.Collections;

public class SpawnRocket : MonoBehaviour {

	public int rocketType = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Keypad1)) 
		{
			rocketType = 1;
		}
		else if (Input.GetKeyDown (KeyCode.Keypad1)) 
		{
			rocketType = 2;
		}
		else if (Input.GetKeyDown (KeyCode.Keypad1)) 
		{
			rocketType = 3;
		}
		else if (Input.GetKeyDown (KeyCode.Keypad1)) 
		{
			rocketType = 4;
		}
	}
}
