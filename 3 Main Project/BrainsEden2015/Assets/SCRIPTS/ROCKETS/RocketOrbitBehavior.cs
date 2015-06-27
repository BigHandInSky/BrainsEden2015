using UnityEngine;
using System.Collections;

public class RocketOrbitBehavior : MonoBehaviour {
	
	
	float GravIntensity = 2.5f;
	float maxSpeed = 10;
	float timer = 0;

	bool stage1 = false;
	bool stage2 = false;
	bool stage3 = false;

	float angleSpeed = 1;

	// Update is called once per frame
	void FixedUpdate () {

		if (maxSpeed >= 0) 
		{
			timer += Time.deltaTime;
			if(GravIntensity > 1.3)
				GravIntensity *= 0.99f;

			Vector3 velocity = GetComponent<Rigidbody> ().velocity;
			float dist = Vector3.Distance (Vector3.zero, gameObject.transform.position);
			velocity += ((Vector3.zero - gameObject.transform.position) / dist / dist * GravIntensity);
			GetComponent<Rigidbody> ().velocity = velocity.normalized * maxSpeed; 
			
			//maxSpeed -= 10 * 0.001f;
			//maxSpeed *= 0.993f;

			if(timer > 1.5f && !stage1)
			{
				//maxSpeed -= 2;
				//stage1 = true;
				//GravIntensity = 1;
			}
			if(timer > 2.5f && !stage2)
			{
				//maxSpeed -= 2;
				//stage2 = true;
			}
			if(maxSpeed < 2f)
			{
				maxSpeed -= 0.1f;
				if (maxSpeed <= 0)
					maxSpeed = 0;
			}else
				transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);

		}
		else{
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
		
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
