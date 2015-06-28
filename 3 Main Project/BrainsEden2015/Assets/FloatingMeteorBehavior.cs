using UnityEngine;
using System.Collections;

public class FloatingMeteorBehavior : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0,0,0.5f), Space.World);
	}
}
