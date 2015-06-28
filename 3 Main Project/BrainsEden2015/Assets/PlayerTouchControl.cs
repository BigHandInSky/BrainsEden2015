using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerTouchControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

	private float fX;
	private float fY;
	private float fAngle = 0;

	public GameObject redPlayer;
	public GameObject bluePlayer;
	public GameObject world;
	
	public void OnPointerDown(PointerEventData data){
		Debug.Log("pointer down");
		setAngle (data);
		if(redPlayer.GetComponent<PlayerTarget>().isActiveAndEnabled)
			redPlayer.GetComponent<PlayerTarget> ().touchDown = true;
		if(bluePlayer.GetComponent<PlayerTarget>().isActiveAndEnabled)
			bluePlayer.GetComponent<PlayerTarget> ().touchDown = true;
	}
	
	public void OnPointerUp(PointerEventData data){
		Debug.Log("pointer up");
		setAngle (data);
		if(redPlayer.GetComponent<PlayerTarget>().isActiveAndEnabled)
			redPlayer.GetComponent<PlayerTarget> ().touchUp = true;
		if(bluePlayer.GetComponent<PlayerTarget>().isActiveAndEnabled)
			bluePlayer.GetComponent<PlayerTarget> ().touchUp = true;
	}

	void IDragHandler.OnDrag(PointerEventData data) {
		setAngle (data);
	}

	void setAngle(PointerEventData data){

		float currectionAngle = world.transform.eulerAngles.z;

		fX = data.position.x - Screen.width / 2;
		fY = data.position.y - Screen.height / 2;
		
		fAngle = Mathf.Atan2 (fY, fX);

		if(redPlayer.GetComponent<PlayerTarget>().isActiveAndEnabled)
			redPlayer.transform.eulerAngles = new Vector3(0,0,fAngle * 180 / 3.14f - 90 + currectionAngle);

		if(bluePlayer.GetComponent<PlayerTarget>().isActiveAndEnabled)
			bluePlayer.transform.eulerAngles = new Vector3(0,0,fAngle * 180 / 3.14f - 90 + currectionAngle);
	}

}
