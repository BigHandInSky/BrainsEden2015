using UnityEngine;
using System.Collections;

public class PlayerTarget : MonoBehaviour {

    [SerializeField] private GameObject m_RocketNaut;
    [SerializeField] private GameObject m_RocketJunk;
    [SerializeField] private GameObject m_RocketSprd;
    [SerializeField] private GameObject m_RocketPull;	

	public GameObject bulletPrefab;
	public GameObject muzzle;
	
	public float moveSpeed = 5;
	public float rocketSpeed = 10;

	public float delayTimer = 0;

    public int RocketType = 1;
	
	void Update() 
    {
        if (GameStateHandler.Instance.CurrentState == GameStateHandler.GameState.End)
            return;
		
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate(0, 0 , 30 * Time.deltaTime * moveSpeed, Space.World);
		}
		else if (Input.GetKey (KeyCode.D)) {
			transform.Rotate(0, 0 , -30 * Time.deltaTime * moveSpeed, Space.World);
		}


        if (Input.GetKeyDown(KeyCode.Space) && delayTimer <= 0)
        {
            GameStateHandler.Instance.SwitchState();
            SpawnRocket();
			delayTimer = 0.5f;
		}
		delayTimer -= Time.deltaTime;
	}

    private void SpawnRocket()
    {
        GameObject _Rocket;
        //RocketType
        if (RocketType == 1) {
			_Rocket = (GameObject)Instantiate (m_RocketNaut, muzzle.transform.position, Quaternion.identity);

			Vector3 velocity = muzzle.transform.up * rocketSpeed;
			_Rocket.GetComponent<Rigidbody> ().velocity = velocity;
			_Rocket.transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);
		} else if (RocketType == 2)
		{
			_Rocket = (GameObject)Instantiate (m_RocketJunk, muzzle.transform.position, Quaternion.identity);

			Vector3 velocity = muzzle.transform.up * rocketSpeed;
			_Rocket.GetComponent<Rigidbody> ().velocity = velocity;
			_Rocket.transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);
		} else if (RocketType == 3)
		{
			_Rocket = (GameObject)Instantiate (m_RocketSprd, muzzle.transform.position, Quaternion.identity);

			Vector3 velocity = muzzle.transform.up * rocketSpeed;
			_Rocket.GetComponent<Rigidbody> ().velocity = velocity;
			_Rocket.transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);
		} else if (RocketType == 4) 
		{
			_Rocket = (GameObject)Instantiate (m_RocketPull, muzzle.transform.position, Quaternion.identity);

			Vector3 velocity = muzzle.transform.up * rocketSpeed;
			_Rocket.GetComponent<Rigidbody> ().velocity = velocity;
			_Rocket.transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);
		}
    }
	
}
