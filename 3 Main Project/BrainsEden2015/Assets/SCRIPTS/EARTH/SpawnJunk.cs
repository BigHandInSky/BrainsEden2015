using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnJunk : MonoBehaviour 
{

	public GameObject debris;
	public GameObject debris1;
	public GameObject debris2;
	public GameObject debris3;

	List<GameObject> debrisList;

	// Use this for initialization
	void Start () {
	
		debrisList = new List<GameObject> ();
		debrisList.Add (debris);
		debrisList.Add (debris1);
		debrisList.Add (debris2);
		debrisList.Add (debris3);
		//Vector3 position = new Vector3 (Random.Range (500, 1000), Random.Range (500, 1000), 0);

		for (int i = 0; i<3; i++) 
		{
			//Vector3 position = new Vector3 (Random.Range (500, 1000), Random.Range (500, 1000), 0);
			Instantiate(debrisList[i], new Vector3 (Random.Range (-10, -6), Random.Range (-10, 10), 0), Quaternion.identity);
		}

		for (int i = 0; i<3; i++) 
		{
			//Vector3 position = new Vector3 (Random.Range (500, 1000), Random.Range (500, 1000), 0);
			Instantiate(debrisList[i], new Vector3 (Random.Range (-10, 10), Random.Range (6, 10), 0), Quaternion.identity);
		}
		for (int i = 0; i<3; i++) 
		{
			//Vector3 position = new Vector3 (Random.Range (500, 1000), Random.Range (500, 1000), 0);
			Instantiate(debrisList[i], new Vector3 (Random.Range (6, 10), Random.Range (-10, 10), 0), Quaternion.identity);
		}
		
		for (int i = 0; i<3; i++) 
		{
			//Vector3 position = new Vector3 (Random.Range (500, 1000), Random.Range (500, 1000), 0);
			Instantiate(debrisList[i], new Vector3 (Random.Range (-10, 10), Random.Range (-6, -10), 0), Quaternion.identity);
		}


	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
