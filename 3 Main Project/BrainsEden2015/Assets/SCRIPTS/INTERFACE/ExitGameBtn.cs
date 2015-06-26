using UnityEngine;
using System.Collections;

//Made by Peter

public class ExitGameBtn : MonoBehaviour 
{
    public void Activate()
    {
        Manager_Game.Instance.ExitGame();
    }
}
