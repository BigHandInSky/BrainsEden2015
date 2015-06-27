using UnityEngine;
using System.Collections;

public class RocketOrbitBehavior : MonoBehaviour {
	
	
	float GravIntensity = 2.5f;
	float maxSpeed = 10;
	float timer = 2;
	
	// Update is called once per frame
	void Update () {

		Debug.Log (maxSpeed);

		if (maxSpeed >= 0) 
		{
			GravIntensity *= 0.999f;
			Vector3 velocity = GetComponent<Rigidbody> ().velocity;
			float dist = Vector3.Distance (Vector3.zero, gameObject.transform.position);
			velocity += ((Vector3.zero - gameObject.transform.position) / dist / dist * GravIntensity);
			GetComponent<Rigidbody> ().velocity = velocity.normalized * maxSpeed; 
			transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);
			
			maxSpeed -= 10 * 0.001f;
		}
		else{
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.name == "World")
			Destroy(gameObject);
	}
}
