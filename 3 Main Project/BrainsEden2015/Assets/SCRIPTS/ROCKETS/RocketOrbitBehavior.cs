using UnityEngine;
using System.Collections;

public class RocketOrbitBehavior : MonoBehaviour {
	
	public float maxSpeed = 15;

	float GravIntensity = 1.8f;
	float timer = 0;

	// Update is called once per frame
	void FixedUpdate () {

		timer += Time.deltaTime;
		if(GravIntensity > 1)
			GravIntensity *= 0.995f;

		Vector3 velocity = GetComponent<Rigidbody> ().velocity;
		float dist = Vector3.Distance (Vector3.zero, gameObject.transform.position);
		velocity += ((Vector3.zero - gameObject.transform.position) / dist / dist * GravIntensity);
		GetComponent<Rigidbody> ().velocity = velocity.normalized * maxSpeed; 
		transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);

		
	}

	void OnTriggerEnter(Collider other) {
		if(other.name == "World")
			Destroy(gameObject);
	}
	void OnCollisionEnter(Collision other) {
		maxSpeed -= 2f;
		if (maxSpeed <= 0)
			maxSpeed = 0;
	}

}
