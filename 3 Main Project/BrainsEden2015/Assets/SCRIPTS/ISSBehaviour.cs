using UnityEngine;
using System.Collections;

public class ISSBehaviour : MonoBehaviour 
{
    [SerializeField] private bool m_RedISS;

    [SerializeField] private string m_REDTagToDetect = "RocketRED";
    [SerializeField] private string m_BLUTagToDetect = "RocketBLU";

    void OnCollisionEnter(Collision _other)
    {
        if (_other.gameObject.tag == m_REDTagToDetect && !m_RedISS)
        {
            GameStateHandler.Instance.ISSHit(true);
            DestroyObject(_other.gameObject);
        }
        else if (_other.gameObject.tag == m_BLUTagToDetect && m_RedISS)
        {
            GameStateHandler.Instance.ISSHit(false);
            DestroyObject(_other.gameObject);
        }
    }
}
