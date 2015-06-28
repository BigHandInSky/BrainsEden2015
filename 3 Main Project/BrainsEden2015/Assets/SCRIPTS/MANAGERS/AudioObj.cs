using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioObj : MonoBehaviour
{
    bool music = false;

    public void Setup(AudioClip _clip, bool _music)
    {
        music = _music;
        gameObject.GetComponent<AudioSource>().clip = _clip;

        if (!_music)
            gameObject.GetComponent<AudioSource>().volume = Manager_Audio.EffectsVol;

        StartCoroutine(Delete(_clip.length));
    }

    IEnumerator Delete(float _length)
    {
        gameObject.GetComponent<AudioSource>().Play();

        float _time = _length;

        while(_time > 0f)
        {
            _time -= Time.deltaTime;
            if (music)
                gameObject.GetComponent<AudioSource>().volume = Manager_Audio.MusicVol;
            yield return new WaitForEndOfFrame();
        }

        DeleteAudioObj();
    }

    public void DeleteAudioObj()
    {
        Destroy(this.gameObject);
    }
}
