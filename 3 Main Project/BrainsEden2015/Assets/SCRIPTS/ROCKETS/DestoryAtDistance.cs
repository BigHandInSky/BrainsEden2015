using UnityEngine;
using System.Collections;

public class DestoryAtDistance : MonoBehaviour {
	
	public float maxDistance;

	// Update is called once per frame
	void Update () 
	{
		float distance = Vector3.Distance (gameObject.transform.position, Vector3.zero);

		if (distance >= maxDistance) 
		{
			Destroy(gameObject);
		}
	}
}
