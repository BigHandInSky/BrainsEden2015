using UnityEngine;
using System.Collections;

public class JunkBehaviour : MonoBehaviour 
{
    private Vector3 m_Rotation;
    private Transform m_Transform;
    private float m_Range = 10f;

	void Start () 
    {
        m_Transform = GetComponent<Transform>();
        m_Rotation = new Vector3(Random.Range(-m_Range, m_Range), Random.Range(-m_Range, m_Range), Random.Range(-m_Range, m_Range));
        StartCoroutine(RotateObj());
	}
    IEnumerator RotateObj()
    {
        while(true)
        {
            m_Transform.Rotate(m_Rotation * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
