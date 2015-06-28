using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.Events;

public class PlayerTarget : MonoBehaviour{

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

	public bool touchDown = false;
	public bool touchUp = false;

	float anglePlayer;


	private GameObject touchPointer;

    private EventSystem eventsystem;
    
    void Start()
    {
        eventsystem = GameObject.FindObjectOfType<EventSystem>();
    }
	
    public void Rotate(bool _rotLeft)
    {
        if(_rotLeft)
        {
            if (anglePlayer + (30 * Time.deltaTime * moveSpeed) < 0 && transform.tag == "LauncherBLUE")
                transform.Rotate(0, 0, 30 * Time.deltaTime * moveSpeed, Space.World);
            else if (anglePlayer + (30 * Time.deltaTime * moveSpeed) < 180 && transform.tag == "LauncherRED")
            {
                transform.Rotate(0, 0, 30 * Time.deltaTime * moveSpeed, Space.World);
            }
        }
        else
        {
            if (anglePlayer - (30 * Time.deltaTime * moveSpeed) > -180 && transform.tag == "LauncherBLUE")
                transform.Rotate(0, 0, -30 * Time.deltaTime * moveSpeed, Space.World);
            else if (anglePlayer - (30 * Time.deltaTime * moveSpeed) > 0 && transform.tag == "LauncherRED")
            {
                transform.Rotate(0, 0, -30 * Time.deltaTime * moveSpeed, Space.World);
            }
        }
    }

	void Update() 
    {
		anglePlayer = Mathf.Atan2(transform.up.y, transform.up.x) * 180 / 3.14f;

        if (GameStateHandler.Instance.CurrentState == GameStateHandler.GameState.End)
            return;
		
		if (Input.GetKey (KeyCode.A)) {
            Rotate(true);
		}
		else if (Input.GetKey (KeyCode.D)) {
            Rotate(false);
		}


        if (Input.GetKeyDown (KeyCode.Space) && delayTimer <= 0) {
			spaceKeyDown = true;
		}
        else if (Input.GetKeyDown(KeyCode.Mouse0) && delayTimer <= 0 && !eventsystem.IsPointerOverGameObject())
        {
            spaceKeyDown = true;
        }
		else if (touchDown && delayTimer <= 0)
		{
			spaceKeyDown = true;
		}

		if (spaceKeyDown) {
			rocketPower += Time.deltaTime;
			if (rocketPower <= 2)
				transform.Find ("Cannon/AimGuide").transform.localPosition = new Vector3 (0, transform.Find ("Cannon/AimGuide").transform.localPosition.y + Time.deltaTime * 2, 0);

		} else {
			transform.Find ("Cannon/AimGuide").transform.localPosition = new Vector3 (0, 0, 0);
			rocketPower = 0;
			spaceKeyDown = false;
		}

		if (Input.GetKeyUp (KeyCode.Space) && rocketPower > 0.01f) {
			SpawnRocket ();
			spaceKeyDown = false;
			delayTimer = 0.5f;
            transform.Find("Cannon/AimGuide").transform.localPosition = new Vector3(0, 0, 0);
			Manager_Audio.Instance.PlayEffect (Manager_Audio.EffectsType.Shoot);
            GameStateHandler.Instance.SwitchState();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && rocketPower > 0.01f && !eventsystem.IsPointerOverGameObject())
        {
            SpawnRocket();
            spaceKeyDown = false;
            delayTimer = 0.5f;
            transform.Find("Cannon/AimGuide").transform.localPosition = new Vector3(0, 0, 0);
            GameStateHandler.Instance.SwitchState();
        }
		if (touchUp && rocketPower > 0.01f) {
			SpawnRocket ();
			spaceKeyDown = false;
			touchDown = false;
			touchUp = false;

			delayTimer = 0.5f;
			transform.Find("Cannon/AimGuide").transform.localPosition = new Vector3(0, 0, 0);
			GameStateHandler.Instance.SwitchState();
		}
		delayTimer -= Time.deltaTime;
	}

    void OnDisable()
    {
		if (spaceKeyDown)
        {
            SpawnRocket();
            spaceKeyDown = false;
            delayTimer = 0.5f;
            transform.Find("Cannon/AimGuide").transform.localPosition = new Vector3(0, 0, 0);
        }
    }
    private void SpawnRocket()
    {
		//Hold for 2 second for max power

		if (rocketPower > 2)
			rocketPower = 2;

		rocketPower = 1.1f + rocketPower / 2  * 0.25f;

		rocketPower /= 2;

        GameObject _Rocket;
        //RocketType
        if (RocketType == 1) {
			_Rocket = (GameObject)Instantiate (m_RocketJunk, muzzle.transform.position, Quaternion.identity);

			Vector3 velocity = muzzle.transform.up * rocketSpeed;
			_Rocket.GetComponent<Rigidbody> ().velocity = velocity;
			_Rocket.transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);
			_Rocket.GetComponent<RocketOrbitBehavior> ().maxSpeed *= rocketPower;

			anglePlayer = Mathf.Abs(anglePlayer);
			if(anglePlayer > 90){
				anglePlayer -= 90;
				anglePlayer = 90 - anglePlayer;
				_Rocket.GetComponent<RocketOrbitBehavior> ().GravIntensity += anglePlayer / 90 * 2.2f;
			}else
			{
				_Rocket.GetComponent<RocketOrbitBehavior> ().GravIntensity += anglePlayer / 90 * 2.2f;
			}
		} else if (RocketType == 2)
		{
			_Rocket = (GameObject)Instantiate (m_RocketSprd, muzzle.transform.position, Quaternion.identity);

			Vector3 velocity = muzzle.transform.up * rocketSpeed;
			_Rocket.GetComponent<Rigidbody> ().velocity = velocity;
			_Rocket.transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);
			_Rocket.GetComponent<RocketOrbitBehavior> ().maxSpeed *= rocketPower;

			anglePlayer = Mathf.Abs(anglePlayer);
			if(anglePlayer > 90){
				anglePlayer -= 90;
				anglePlayer = 90 - anglePlayer;
				_Rocket.GetComponent<RocketOrbitBehavior> ().GravIntensity += anglePlayer / 90 * 2.2f;
			}else
			{
				_Rocket.GetComponent<RocketOrbitBehavior> ().GravIntensity += anglePlayer / 90 * 2.2f;
			}
		} else if (RocketType == 3) 
		{
			_Rocket = (GameObject)Instantiate (m_RocketPull, muzzle.transform.position, Quaternion.identity);

			Vector3 velocity = muzzle.transform.up * rocketSpeed;
			_Rocket.GetComponent<Rigidbody> ().velocity = velocity;
			_Rocket.transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);
			_Rocket.GetComponent<RocketOrbitBehavior> ().maxSpeed *= rocketPower;

			anglePlayer = Mathf.Abs(anglePlayer);
			if(anglePlayer > 90){
				anglePlayer -= 90;
				anglePlayer = 90 - anglePlayer;
				_Rocket.GetComponent<RocketOrbitBehavior> ().GravIntensity += anglePlayer / 90 * 2.2f;
			}else
			{
				_Rocket.GetComponent<RocketOrbitBehavior> ().GravIntensity += anglePlayer / 90 * 2.2f;
			}
		}

		if (transform.tag == "LauncherBLUE")
			transform.eulerAngles = new Vector3 (0, 0, 180);
		if (transform.tag == "LauncherRED")
			transform.eulerAngles = new Vector3 (0, 0, 0);

		rocketPower = 0;
    }
}
