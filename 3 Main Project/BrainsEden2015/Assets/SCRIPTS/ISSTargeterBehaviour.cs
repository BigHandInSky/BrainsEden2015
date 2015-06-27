using UnityEngine;
using System.Collections;

public class ISSTargeterBehaviour : MonoBehaviour 
{
    private MeshRenderer m_Renderer;
    [SerializeField] private bool m_Red;

    void Start()
    {
        TriggerFades();
    }

    public void TriggerFades()
    {
        StopAllCoroutines();
        StartCoroutine(StartFades());
    }

    IEnumerator StartFades()
    {
        if (!m_Renderer)
            m_Renderer = GetComponent<MeshRenderer>();

        for(int _l = 0; _l < 2; _l++)
        {
            yield return StartCoroutine(FadeIn());
            yield return StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeIn()
    {
        Color _col;
        if (m_Red)
            _col = new Color(1f, 0f, 0f, 0f);
        else
            _col = new Color(0f, 0f, 1f, 0f);

        float _lerp = 0f;
        while (_lerp < 1f)
        {
            _lerp += Time.deltaTime;
            m_Renderer.material.color = new Color(_col.r, _col.g, _col.b, Mathf.Lerp(0f, 1f, _lerp));
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator FadeOut()
    {
        Color _col;
        if (m_Red)
            _col = new Color(1f, 0f, 0f, 0f);
        else
            _col = new Color(0f, 0f, 1f, 0f);

        float _lerp = 0f;
        while (_lerp < 1f)
        {
            _lerp += Time.deltaTime;
            m_Renderer.material.color = new Color(_col.r, _col.g, _col.b, Mathf.Lerp(1f, 0f, _lerp));
            yield return new WaitForEndOfFrame();
        }
    }
}
