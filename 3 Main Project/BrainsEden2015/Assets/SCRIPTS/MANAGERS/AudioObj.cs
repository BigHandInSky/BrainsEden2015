using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioObj : MonoBehaviour
{
    public void Setup(AudioClip _clip, bool _music)
    {
        gameObject.GetComponent<AudioSource>().clip = _clip;

        if (_music)
            gameObject.GetComponent<AudioSource>().volume = Manager_Audio.MusicVol;
        else
            gameObject.GetComponent<AudioSource>().volume = Manager_Audio.EffectsVol;

        StartCoroutine(Delete(_clip.length));
    }

    IEnumerator Delete(float _length)
    {
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(_length);

        DeleteAudioObj();
    }

    public void DeleteAudioObj()
    {
        Destroy(this.gameObject);
    }
}
