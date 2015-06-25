using UnityEngine;
using System.Collections;

//use this script for any repeated generic functions, like the ones below
public class UtilScript : MonoBehaviour 
{
    public static float GetDistance(Vector3 _objA, Vector3 _objB)
    {
        return (_objA - _objB).magnitude;
    }
}
