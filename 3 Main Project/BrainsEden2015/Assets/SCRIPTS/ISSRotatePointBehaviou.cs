using UnityEngine;
using System.Collections;

public class ISSRotatePointBehaviou : MonoBehaviour 
{
    [SerializeField] private bool m_Red;
    private Transform m_TransformComponent;
    private float m_Time = 0f;
    private float m_MoveMod;
    private float m_MoveSpeed = 10f;

    void Start()
    {
        m_TransformComponent = GetComponent<Transform>();
    }

    void Update()
    {
        m_Time += Time.deltaTime;
        m_MoveMod = Mathf.Sin(m_Time * 0.15f);
        float _speed = (m_MoveSpeed * Time.deltaTime) * m_MoveMod;
        m_TransformComponent.Rotate(Vector3.forward, Mathf.Clamp(_speed, -0.5f, 0.5f));
    }
}
