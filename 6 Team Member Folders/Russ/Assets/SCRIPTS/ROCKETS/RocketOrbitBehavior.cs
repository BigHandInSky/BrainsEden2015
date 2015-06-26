using UnityEngine;
using System.Collections;

public class RocketOrbitBehavior : MonoBehaviour {


	float GravIntensity = 1;
	float maxSpeed = 10;

	// Update is called once per frame
	void Update () {

		Vector3 velocity = GetComponent<Rigidbody> ().velocity;
		float dist = Vector3.Distance(Vector3.zero, gameObject.transform.position );
		velocity += ( (Vector3.zero - gameObject.transform.position)/dist/dist*GravIntensity);
		GetComponent<Rigidbody> ().velocity = velocity.normalized * maxSpeed; 
		transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);

		maxSpeed *= 0.999f;
		if (maxSpeed <= 0)
			maxSpeed = 0;

	}
}
