using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateDebris : MonoBehaviour {

	public GameObject debris1;
	public GameObject debris2;
	public GameObject debris3;
	public GameObject debris4;
	
	List<GameObject> debrisList;

	public GameObject debris;
	public float minValue;
	public float maxValue;


	private float delayTimer = 0.5f;
	private float junkTimer = 0;

	// Use this for initialization
	void Start () 
	{
		debrisList = new List<GameObject> ();
		debrisList.Add (debris1);
		debrisList.Add (debris2);
		debrisList.Add (debris3);
		debrisList.Add (debris4);

	}
	
	// Update is called once per frame
	void Update () 
	{
		delayTimer -= Time.deltaTime;

		if(delayTimer <= 0 && GetComponent<Rigidbody> ().velocity.magnitude > 3){
			//Vector3 position = new Vector3(Random.Range(minValue, maxValue), Random.Range(minValue, maxValue), 0);
			if(junkTimer <= 0){
				Instantiate(debrisList[Random.Range(0,3)], transform.position - transform.up, Quaternion.identity);
				junkTimer = 1;
			}
			junkTimer -= Time.deltaTime * 2f;
		}
	}
}
