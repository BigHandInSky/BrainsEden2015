using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingTowards : MonoBehaviour {

	public float moveTowards = 1.0f;

	public GameObject a;
	public GameObject b;
	public GameObject c;
	public GameObject d;

	List<GameObject> fragments;

	// Use this for initialization
	void Start () {
		fragments = new List<GameObject> ();
		fragments.Add (a);
		fragments.Add (b);
		fragments.Add (c);
		fragments.Add (d);
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.Space)) {


			for(int i=0; i < fragments.Capacity; i++){

				Vector3 velocity = transform.position - fragments[i].transform.position;
				fragments[i].GetComponent<Rigidbody>().AddForce(velocity* 1500);

				//Vector3 move = new Vector3 (transform.position.x + moveTowards, transform.position.y, transform.position.z);
				//transform.position = move;

			}
		}
	}
}
