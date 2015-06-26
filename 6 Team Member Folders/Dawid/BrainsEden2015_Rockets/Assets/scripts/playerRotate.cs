using UnityEngine;
using System.Collections;

public class playerRotate : MonoBehaviour {

	public float moveSpeed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate(0, 0 , 30 * Time.deltaTime * moveSpeed);
		}
		else if (Input.GetKey (KeyCode.D)) {
			transform.Rotate(0, 0 , -30 * Time.deltaTime * moveSpeed);
		}
	}
}
