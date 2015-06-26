using UnityEngine;
using System.Collections;

//Made by Peter

public class PlayGameBtn : MonoBehaviour 
{
    public void Activate()
    {
        Manager_Game.Instance.ChangeScene(2);
    }
}
