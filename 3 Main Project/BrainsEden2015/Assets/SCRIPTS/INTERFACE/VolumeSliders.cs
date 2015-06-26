using UnityEngine;
using System.Collections;

public class VolumeSliders : MonoBehaviour 
{
    [SerializeField] private bool m_SetsMusic;
    private UnityEngine.UI.Slider m_SliderComponent;
    [SerializeField] private UnityEngine.UI.Text m_TextToSet;
    
    void OnEnable()
    {
        if (!m_SliderComponent)
            m_SliderComponent = GetComponent<UnityEngine.UI.Slider>();

        SetText();
    }

    public void SetValue()
    {
        if (!m_SetsMusic)
        {
            Manager_Audio.AltEffVol = m_SliderComponent.value;
        }
        else
        {
            Manager_Audio.AltMusVol = m_SliderComponent.value;
        }

        SetText();
    }

    private void SetText()
    {
        if (!m_SetsMusic)
        {
            m_TextToSet.text = "Effects Volume: " + m_SliderComponent.value.ToString();
        }
        else
        {
            m_TextToSet.text = "Music Volume: " + m_SliderComponent.value.ToString();
        }
    }
}
