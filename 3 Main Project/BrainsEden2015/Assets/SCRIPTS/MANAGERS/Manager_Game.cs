using UnityEngine;
using System.Collections;

//use this to control across-scene game values, such as scores if we need it

public class Manager_Game : MonoBehaviour 
{
    //so it can be accessed anywhere in scripting with Manager_Game.Instance.<public variables/funcs>
    private static Manager_Game m_Instance;
    public static Manager_Game Instance { get { return m_Instance; } }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        //delete this object if there is another valid instance
        if (m_Instance != null && m_Instance != this)
            DestroyObject(this.gameObject);
        else
            m_Instance = this;

        //if on first scene load into next one
        if(Application.loadedLevelName.Contains("First"))
        {
            ChangeScene(3);
        }
    }

    public void ChangeScene(int _sceneNum)
    {
        if (Application.levelCount < _sceneNum
            || _sceneNum < 0)
        {
            Debug.LogError("ChangeScene called with invalid number: " + _sceneNum);
            return;
        }

        Debug.Log(Application.loadedLevelName);
        Application.LoadLevel(_sceneNum);
    }
    //Basic exit, can be used for saving data if we want it later
    public void ExitGame() { Application.Quit(); }
}
