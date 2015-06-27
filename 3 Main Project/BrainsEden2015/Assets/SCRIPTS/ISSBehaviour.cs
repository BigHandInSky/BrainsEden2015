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
        if (_other.gameObject.tag == m_REDTagToDetect && !m_RedISS)
        {
            m_hits++;
            StartCoroutine("Hit" + m_hits.ToString());

            GameStateHandler.Instance.ISSHit(true);
            DestroyObject(_other.gameObject);

            if (GameStateHandler.Instance.RedNauts == 1)
                StartCoroutine(Hit1());
            else if (GameStateHandler.Instance.RedNauts == 2)
                StartCoroutine(Hit2());
            else if (GameStateHandler.Instance.RedNauts == 3)
                StartCoroutine(Hit3());
        }
        else if (_other.gameObject.tag == m_BLUTagToDetect && m_RedISS)
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

        m_Hit1Effect.SetActive(true);
        yield return new WaitForSeconds(1.8f);
        DestroyObject(m_Hit1Effect);

    }
    IEnumerator Hit2()
    {
        Debug.Log("hit2");

        m_Hit2Effect.SetActive(true);
        yield return new WaitForSeconds(1.9f);
        DestroyObject(m_Hit2Effect);
    }
    IEnumerator Hit3()
    {
        Debug.Log("hit3");

        m_Hit3Effect.SetActive(true);
        yield return new WaitForSeconds(1.9f);
        DestroyObject(m_Hit3Effect);
        DestroyObject(this.gameObject);
    }
}
