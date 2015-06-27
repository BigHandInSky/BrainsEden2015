using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PushingScript : MonoBehaviour {

	public float maxDistance;

	public GameObject junkPrefab;
	public GameObject[] junk;
		
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (junk == null) 
		{
			//Nothing
		}
		else 
		{
			junk = GameObject.FindGameObjectsWithTag ("Junk");

			foreach (GameObject junkPrefab in junk) 
			{
				float distance = Vector3.Distance (gameObject.transform.position, junkPrefab.transform.position);

				if (distance < maxDistance) 
				{
					Vector3 velocity = transform.position + junkPrefab.transform.position;
					junkPrefab.GetComponent<Rigidbody> ().AddForce (velocity * 5f);
				}
			}
		}
	}
}
