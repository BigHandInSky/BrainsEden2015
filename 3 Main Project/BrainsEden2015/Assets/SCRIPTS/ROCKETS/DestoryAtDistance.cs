using UnityEngine;
using System.Collections;

public class DestoryAtDistance : MonoBehaviour {

	public GameObject source;
	public float maxDistance;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float distance = Vector3.Distance (gameObject.transform.position, source.transform.position);

		if (distance >= maxDistance) 
		{
			Destroy(gameObject);
		}
	}
}
