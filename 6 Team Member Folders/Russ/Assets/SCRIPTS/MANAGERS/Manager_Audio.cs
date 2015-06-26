using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//use this as a single point of reference for audio clips and audio values

public class Manager_Audio : MonoBehaviour
{
    //so it can be accessed anywhere in scripting with Manager_Game.Instance.<public variables/funcs>
    private static Manager_Audio m_Instance;
    public static Manager_Audio Instance { get { return m_Instance; } }

    void Awake()
    {
        //delete this object if there is another valid instance
        if (m_Instance != null && m_Instance != this)
            DestroyObject(this.gameObject);
        else
            m_Instance = this;
    }

    public static float EffectsVol = 1f;
    public static float MusicVol = 1f;
    public static float AltEffVol { get { return EffectsVol * 100f; } set { EffectsVol = value * 0.01f; } }
    public static float AltMusVol { get { return MusicVol * 100f; } set { MusicVol = value * 0.01f; } }

    //[SerializeField] forces Unity to display the variable in the inspector
    //used more with private/protected
    [SerializeField] private List<AudioClip> Effects = new List<AudioClip>();
    [SerializeField] private List<AudioClip> Music = new List<AudioClip>();

    public enum EffectsType
    {
        Button,
        Example
    }

    public AudioClip GetEffect(EffectsType _clip)
    {
        AudioClip _temp = new AudioClip();

        switch(_clip)
        {
            case EffectsType.Button:
                _temp = Effects[0];
                break;
            case EffectsType.Example:
                _temp = Effects[1];
                break;
        }

        return _temp;
    }
    //the above but this allows for calling with inspector, e.g. linking a button
    public AudioClip GetEffect(int _clip)
    {
        AudioClip _temp = new AudioClip();

        switch ((EffectsType)_clip)
        {
            case EffectsType.Button:
                _temp = Effects[0];
                break;
            case EffectsType.Example:
                _temp = Effects[1];
                break;
        }

        return _temp;
    }
}
