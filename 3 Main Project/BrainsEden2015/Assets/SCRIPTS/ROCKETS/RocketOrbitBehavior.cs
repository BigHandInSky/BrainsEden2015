using UnityEngine;
using System.Collections;

public class RocketOrbitBehavior : MonoBehaviour {
	
	public float maxSpeed = 20;

	public float GravIntensity = 2.0f;
	float timer = 0;

    [SerializeField] private GameObject m_SmokeEffect;
    [SerializeField] private GameObject m_EarthCollideEffect;

    void Start()
    {
        m_SmokeEffect = Instantiate(m_SmokeEffect);
        m_SmokeEffect.transform.parent = GetComponent<Transform>();
        m_SmokeEffect.transform.localPosition = Vector3.zero;
    }

	// Update is called once per frame
	void FixedUpdate () {

        if (timer < 4f)
            timer += Time.deltaTime;
        else if (m_SmokeEffect)
            DestroyObject(m_SmokeEffect);

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
        {
            Instantiate(m_EarthCollideEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
        }
	}
	void OnCollisionEnter(Collision other) {
		maxSpeed -= 2f;
		if (maxSpeed <= 0)
			maxSpeed = 0;
	}

}
