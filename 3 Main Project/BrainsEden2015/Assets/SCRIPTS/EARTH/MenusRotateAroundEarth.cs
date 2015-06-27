using UnityEngine;
using System.Collections;

public class MenusRotateAroundEarth : MonoBehaviour
{
    private Transform m_RotatePoint;

    [SerializeField] private bool m_RotateX = false;
    [SerializeField] private bool m_RotateY = false;
    [SerializeField] private bool m_RotateZ = false;

    [SerializeField] private Vector3 m_RotateSpeeds = new Vector3(1f, 1f, 1f);
    private Vector3 m_Rotate;

    void Start()
    {
        m_RotatePoint = GetComponent<Transform>();
    }

    void Update()
    {
        m_Rotate = Vector3.zero;

        if (m_RotateX)
            m_Rotate.x += m_RotateSpeeds.x * Time.deltaTime;

        if (m_RotateY)
            m_Rotate.y += m_RotateSpeeds.y * Time.deltaTime;

        if (m_RotateZ)
            m_Rotate.z += m_RotateSpeeds.z * Time.deltaTime;

        m_RotatePoint.Rotate(m_Rotate);
    }
}
