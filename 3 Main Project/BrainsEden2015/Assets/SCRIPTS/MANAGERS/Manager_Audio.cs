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

        ObjToSpawnUnder = Camera.main.gameObject;
        StartCoroutine(MusicRoutine());
    }

    [SerializeField] private GameObject ObjToSpawn;
    private GameObject ObjToSpawnUnder;

    //if value is at 0 it is effectively off, so no bools
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

    public void PlayEffect(EffectsType _type)
    {
        SelectClip(_type);
    }
    public void PlayEffect(int _type)
    {
        SelectClip((EffectsType)_type);
    }
    private void SelectClip(EffectsType _clipType)
    {
        int _selected = 0;

        switch (_clipType)
        {
            case EffectsType.Button:
                _selected = 0;
                break;
        }

        CreateObj(Effects[_selected]);
    }

    IEnumerator MusicRoutine()
    {
        GameObject _lastClone = new GameObject("MusicRoutineTemp");
        int _lastTrack = 0;

        while(true)
        {
            if (Music.Count < 1)
                break;

            if (_lastClone == null)
            {
                _lastClone = (GameObject)Instantiate(ObjToSpawn);
                _lastClone.transform.parent = ObjToSpawnUnder.transform;
                _lastClone.transform.localPosition = Vector3.zero;
                _lastClone.GetComponent<AudioObj>().Setup(Music[_lastTrack], true);

                _lastTrack++;
                if (_lastTrack == Music.Count)
                    _lastTrack = 0;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private void CreateObj(AudioClip _clipToPlay)
    {
        GameObject _clone = Instantiate(ObjToSpawn);
        _clone.transform.parent = ObjToSpawnUnder.transform;
        _clone.transform.localPosition = Vector3.zero;
        _clone.GetComponent<AudioObj>().Setup(_clipToPlay, false);
    }
}
