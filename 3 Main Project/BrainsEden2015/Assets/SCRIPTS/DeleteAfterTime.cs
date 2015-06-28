using UnityEngine;
using System.Collections;

public class DeleteAfterTime : MonoBehaviour {

    [SerializeField]
    private float DeleteTime = 1f;

	void Update () 
    {
        DeleteTime -= Time.deltaTime;
        if (DeleteTime < 0f)
            DestroyObject(this.gameObject);
	}
}
