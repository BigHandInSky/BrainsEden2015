using UnityEngine;
using System.Collections;

public class HelpTextSetControls : MonoBehaviour {

    [SerializeField] private GameObject AndroidText;
    [SerializeField] private GameObject DesktopText;

	void Start () 
    {
        if (Application.isMobilePlatform)
            AndroidText.SetActive(true);
        else
            DesktopText.SetActive(true);
	}

}
