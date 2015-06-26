using UnityEngine;
using System.Collections;

//use this to have a single point of Input control, rather than define across scripts

public class Manager_Input : MonoBehaviour
{
    //so it can be accessed anywhere in scripting with Manager_Game.Instance.<public variables/funcs>
    private static Manager_Input m_Instance;
    public static Manager_Input Instance { get { return m_Instance; } }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        //delete this object if there is another valid instance
        if (m_Instance != null && m_Instance != this)
            DestroyObject(this.gameObject);
        else
            m_Instance = this;
    }

    //Manager_Input.Instance.InputExample
    public static KeyCode InputExample = KeyCode.A;
}
