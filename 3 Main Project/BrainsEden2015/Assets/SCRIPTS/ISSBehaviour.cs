using UnityEngine;
using System.Collections;

public class ISSBehaviour : MonoBehaviour 
{
    [SerializeField] private bool m_RedISS;

    [SerializeField] private string m_REDTagToDetect = "RocketRED";
    [SerializeField] private string m_BLUTagToDetect = "RocketBLU";

    [SerializeField] private GameObject m_Hit1Effect;
    [SerializeField] private GameObject m_Hit2Effect;
    [SerializeField] private GameObject m_Hit3Effect;

    private int m_hits = 0;

    void OnCollisionEnter(Collision _other)
    {
        if (_other.gameObject.name.Contains("Rocket") && !m_RedISS)
        {
            m_hits++;
            StartCoroutine("Hit" + m_hits.ToString());

            GameStateHandler.Instance.ISSHit(true);
            DestroyObject(_other.gameObject);
        }
        else if (_other.gameObject.name.Contains("Rocket") && m_RedISS)
        {
            m_hits++;
            StartCoroutine("Hit" + m_hits.ToString());

            GameStateHandler.Instance.ISSHit(false);
            DestroyObject(_other.gameObject);
        }
    }

    IEnumerator Hit1()
    {
        Debug.Log("hit1");

		Manager_Audio.Instance.PlayEffect (Manager_Audio.EffectsType.Explosion);
		
        m_Hit1Effect.SetActive(true);
        yield return new WaitForSeconds(1.8f);
        DestroyObject(m_Hit1Effect);

    }
    IEnumerator Hit2()
    {
        Debug.Log("hit2");

		Manager_Audio.Instance.PlayEffect (Manager_Audio.EffectsType.Explosion);
		
        m_Hit2Effect.SetActive(true);
        yield return new WaitForSeconds(1.9f);
        DestroyObject(m_Hit2Effect);
    }
    IEnumerator Hit3()
    {
        Debug.Log("hit3");

		Manager_Audio.Instance.PlayEffect (Manager_Audio.EffectsType.Explosion);
		
        m_Hit3Effect.SetActive(true);
        yield return new WaitForSeconds(1.9f);
        DestroyObject(m_Hit3Effect);
        DestroyObject(this.gameObject);
    }
}
