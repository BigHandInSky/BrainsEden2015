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
        Explosion,
		Shoot,
		Button,
		MakeDebris
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
			case EffectsType.Explosion:
				_selected = Random.Range(0,2);
				break;
			case EffectsType.Shoot:
				_selected = 3;
				break;
			case EffectsType.Button:
				_selected = 4;
				break;
			case EffectsType.MakeDebris:
				_selected = 5;
				break;
        }

        CreateObj(Effects[_selected]);
    }

    IEnumerator MusicRoutine()
    {
        float _time = 0f;
        int _lastTrack = 0;

        while(true)
        {
            if (Music.Count < 1)
                break;

            _time -= Time.deltaTime;

            if (_time < 0f)
            {
                GameObject _lastClone = (GameObject)Instantiate(ObjToSpawn);
                _lastClone.transform.parent = ObjToSpawnUnder.transform;
                _lastClone.transform.localPosition = Vector3.zero;
                _lastClone.GetComponent<AudioObj>().Setup(Music[_lastTrack], true);

                _time = Music[_lastTrack].length;

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
