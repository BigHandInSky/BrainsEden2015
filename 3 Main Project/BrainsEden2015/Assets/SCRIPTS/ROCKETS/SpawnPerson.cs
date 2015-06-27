using UnityEngine;
using System.Collections;

public class SpawnPerson : MonoBehaviour 
{
	public GameObject spawn;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			Vector3 move = new Vector3(transform.position.x,transform.position.y,transform.position.z + 0.1f);
			transform.position = move;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Sphere") 
		{
			Vector3 position = new Vector3(1.0f, 1.0f, 1.0f);
			Instantiate(spawn, position, Quaternion.identity);
		}
	}
}
