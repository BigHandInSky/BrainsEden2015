using UnityEngine;
using System.Collections;

public class ClearDebrisRocket : MonoBehaviour 
{
    void OnCollisionEnter(Collision _other)
    {
        if (_other.gameObject.tag == "Junk")
            DestroyObject(_other.gameObject);
    }
}
