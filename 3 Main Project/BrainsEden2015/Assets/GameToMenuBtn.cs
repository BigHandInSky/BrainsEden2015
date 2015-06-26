using UnityEngine;
using System.Collections;

public class GameToMenuBtn : MonoBehaviour 
{
    public void Activate()
    {
        Manager_Game.Instance.ChangeScene(1);
    }

}
