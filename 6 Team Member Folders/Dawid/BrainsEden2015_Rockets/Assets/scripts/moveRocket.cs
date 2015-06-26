using UnityEngine;
using System.Collections;

public class moveRocket : MonoBehaviour {

	public Rigidbody rocket1;
	public Rigidbody rocket2;
	public Rigidbody rocket3;
	public Rigidbody rocket4;

	public float rocketSpeed = 10.0f;
	public float rocketPower = 10.0f;
	public bool rocketMoving = false;
	public int rocketType = 1;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			rocketType = 1;
			rocketSpeed = 1;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			rocketType = 2;
			rocketSpeed = 5;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			rocketType = 3;
				rocketSpeed = 10;
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4)) 
		{
			rocketType = 4;
			rocketSpeed = 20;
		}

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			/*
			if(!rocketMoving)
			{
				rocketMoving = true;
			}
		}
		if (rocketMoving) 
		{
		*/
			//transform.Translate (Vector3.right * Time.deltaTime * rocketSpeed);
			Rigidbody clone;
			clone = (Rigidbody)Instantiate(rocket1, transform.position, transform.rotation);
			clone.velocity = transform.TransformDirection(-Vector3.left * rocketSpeed);
		}
	}
}
