using UnityEngine;
using System.Collections;

public class PlayerTarget : MonoBehaviour {

	public GameObject bulletPrefab;

	public float moveSpeed = 5;
	public float rocketSpeed = 10;

	void Update() {

		if (Input.GetButtonDown ("Fire1")) {

			Vector3 mousePos = Input.mousePosition;
			mousePos.z = -Camera.main.transform.position.z;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);

			GameObject bullet = (GameObject)Instantiate(bulletPrefab,transform.position, Quaternion.identity);

			Vector3 dir = (mousePos - transform.position).normalized;
			bullet.transform.eulerAngles = new Vector3(0, 0,90 + Mathf.Atan2(-dir.y, -dir.x) * 180/3.14f);
			bullet.GetComponent<Rigidbody>().velocity = dir * rocketSpeed;
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate(0, 0 , 30 * Time.deltaTime * moveSpeed, Space.World);
		}
		else if (Input.GetKey (KeyCode.D)) {
			transform.Rotate(0, 0 , -30 * Time.deltaTime * moveSpeed, Space.World);
		}


		if (Input.GetKey (KeyCode.Space)) {

			GameObject bullet = (GameObject)Instantiate(bulletPrefab,transform.position + transform.up, Quaternion.identity);
			Vector3 velocity = transform.TransformDirection(transform.up * rocketSpeed);
			bullet.GetComponent<Rigidbody>().velocity = velocity;
			bullet.transform.eulerAngles = new Vector3 (0, 0, 90 + Mathf.Atan2 (-velocity.y, -velocity.x) * 180 / 3.14f);
		}
	}

}
