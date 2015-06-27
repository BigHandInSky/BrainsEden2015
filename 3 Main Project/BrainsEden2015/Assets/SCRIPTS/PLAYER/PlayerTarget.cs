using UnityEngine;
using System.Collections;

public class PlayerTarget : MonoBehaviour {

    [SerializeField] private GameObject m_RocketNaut;
    [SerializeField] private GameObject m_RocketJunk;
    [SerializeField] private GameObject m_RocketSprd;
    [SerializeField] private GameObject m_RocketPull;

    [SerializeField] private GameObject m_AimGuide;
    public GameObject GetGuide { get { return m_AimGuide; } }

	public GameObject bulletPrefab;
	public GameObject muzzle;
	
	public float moveSpeed = 5;
	public float rocketSpeed = 15;

	public float delayTimer = 0;

    public int RocketType = 1;
	public float rocketPower;

	public bool spaceKeyDown = false;
	
	void Update() 
    {
		float anglePlayer = Mathf.Atan2(transform.up.y, transform.up.x) * 180 / 3.14f;

        if (GameStateHandler.Instance.CurrentState == GameStateHandler.GameState.End)
            return;
		
		if (Input.GetKey (KeyCode.A)) {
			if(transform.eulerAngles.z <= 270 && transform.tag == "LauncherBLUE")
				transform.Rotate(0, 0 , 30 * Time.deltaTime * moveSpeed, Space.World);
			else if(anglePlayer <= 180 && anglePlayer > 0 && transform.tag == "LauncherRED")
			{
					transform.Rotate(0, 0 , 30 * Time.deltaTime * moveSpeed, Space.World);
			}
		}
		else if (Input.GetKey (KeyCode.D)) {
			if(transform.eulerAngles.z >= 90 && transform.tag == "LauncherBLUE")
				transform.Rotate(0, 0 , -30 * Time.deltaTime * moveSpeed, Space.World);
			else if(anglePlayer >= 0 && transform.tag == "LauncherRED")
			{
				transform.Rotate(0, 0 , -30 * Time.deltaTime * moveSpeed, Space.World);
			}
		}


        if (Input.GetKeyDown (KeyCode.Space) && delayTimer <= 0) {
			spaceKeyDown = true;
		}
		if(spaceKeyDown){
			rocketPower += Time.deltaTime;
		}

		if (Input.GetKeyUp (KeyCode.Space) && rocketPower > 0.01f) {
			GameStateHandler.Instance.SwitchState ();
			SpawnRocket ();
			spaceKeyDown = false;
			delayTimer = 0.5f;
		}
		delayTimer -= Time.deltaTime;
	}

    private void SpawnRocket()
    {
		//Hold for 2 second for max power
		if (rocketPower > 2)
			rocketPower = 2;
		if (rocketPower < 1f)
			rocketPower = 1.5f;
		rocketPower /= 2;

        GameObject _Rocket;
        //RocketType
        if (RocketType == 1) {
			_Rocket = (GameObject)Instantiate (m_RocketNaut, muzzle.transform.position, Quaternion.identity);

			Vector3 velocity = muzzle.transform.up * rocketSpeed;
			_Rocket.GetComponent<Rigidbody> ().velocity = velocity;
			_Rocket.transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);
			_Rocket.GetComponent<RocketOrbitBehavior> ().maxSpeed *= rocketPower;
		} else if (RocketType == 2)
		{
			_Rocket = (GameObject)Instantiate (m_RocketJunk, muzzle.transform.position, Quaternion.identity);

			Vector3 velocity = muzzle.transform.up * rocketSpeed;
			_Rocket.GetComponent<Rigidbody> ().velocity = velocity;
			_Rocket.transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);
			_Rocket.GetComponent<RocketOrbitBehavior> ().maxSpeed *= rocketPower;
		} else if (RocketType == 3)
		{
			_Rocket = (GameObject)Instantiate (m_RocketSprd, muzzle.transform.position, Quaternion.identity);

			Vector3 velocity = muzzle.transform.up * rocketSpeed;
			_Rocket.GetComponent<Rigidbody> ().velocity = velocity;
			_Rocket.transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);
			_Rocket.GetComponent<RocketOrbitBehavior> ().maxSpeed *= rocketPower;
		} else if (RocketType == 4) 
		{
			_Rocket = (GameObject)Instantiate (m_RocketPull, muzzle.transform.position, Quaternion.identity);

			Vector3 velocity = muzzle.transform.up * rocketSpeed;
			_Rocket.GetComponent<Rigidbody> ().velocity = velocity;
			_Rocket.transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);
			_Rocket.GetComponent<RocketOrbitBehavior> ().maxSpeed *= rocketPower;
		}

		rocketPower = 0;
    }
}
