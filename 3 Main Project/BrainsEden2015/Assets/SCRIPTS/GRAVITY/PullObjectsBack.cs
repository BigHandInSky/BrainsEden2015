using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PullObjectsBack : MonoBehaviour {

	public float maxDistance;
	public float minDistance;

	public float pullForce;
	
	//public GameObject target;
	public GameObject[] targeted;

	// Use this for initialization
	void Start () 
	{
	

	}
	
	// Update is called once per frame
	void Update () {

		if (targeted == null) 
		{
			//Nothing
		}
		else 
		{
			targeted = GameObject.FindGameObjectsWithTag ("Junk");
			
			foreach (GameObject target in targeted) 
			{
				float distance = Vector3.Distance (gameObject.transform.position, target.transform.position);
				
				if (distance < maxDistance && distance > minDistance) 
				{
					Vector3 velocity = transform.position - target.transform.position;
					target.GetComponent<Rigidbody> ().AddForce (velocity * pullForce);
				}
			}
		}
	
	}
}
