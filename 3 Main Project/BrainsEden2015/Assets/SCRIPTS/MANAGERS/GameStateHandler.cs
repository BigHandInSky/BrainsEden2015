using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Made by Peter
//Controls stuff in the game scene

public class GameStateHandler : MonoBehaviour
{
    //so it can be accessed anywhere in scripting with Manager_Game.Instance.<public variables/funcs>
    private static GameStateHandler m_Instance;
    public static GameStateHandler Instance { get { return m_Instance; } }

    void Awake()
    {
        if (m_Instance != null && m_Instance != this)
            DestroyObject(this.gameObject);
        else
            m_Instance = this;

        //setup game
        LastMissile(MissileTypes.None);
        SetNautsUI();

        //random pick who starts
        if (Random.Range(0, 1f) > 0.49f)
            CurrentState = GameState.Red;
        else
            CurrentState = GameState.Blue;

        SwitchState();

    }

    public bool nauts_ui_debug = false;
    public bool switch_debug = false;
    public bool win_debug = false;
    void Update()
    {
        if (nauts_ui_debug)
        {
            nauts_ui_debug = false;
            SetNautsUI();
        }

        if (switch_debug)
        {
            switch_debug = false;
            SwitchState();
        }

        if (win_debug)
        {
            win_debug = false;
            EndGame();
        }
    }

    public enum GameState
    {
        Start,
        Red,
        Blue,
        End
    }
    public GameState CurrentState = GameState.Start;
    private int m_StatesRan = 0;

    public int NautsBalance = 0;

    [SerializeField] private Image m_RedUIRoot;
    [SerializeField] private GameObject m_RedVictoryRoot;
    [SerializeField] private List<Image> m_RedNautIndicators;
    [SerializeField] private Image m_RedMissileInd;

    [SerializeField] private Image m_BluUIRoot;
    [SerializeField] private GameObject m_BluVictoryRoot;
    [SerializeField] private List<Image> m_BluNautIndicators;
    [SerializeField] private Image m_BluMissileInd;

    [SerializeField] private Sprite m_MissileNone;
    [SerializeField] private Sprite m_MissileNaut;
    [SerializeField] private Sprite m_MissileJunk;
    [SerializeField] private Sprite m_MissileSprd;
    [SerializeField] private Sprite m_MissilePull;
    [SerializeField] private Sprite m_MissileVictory;
    [SerializeField] private Sprite m_MissileFail;
    
    public void SwitchState()
    {
        if (Mathf.Abs(NautsBalance) == 3)
        {
            EndGame();
            return;
        }

        m_StatesRan++;

        if (m_StatesRan % 3 == 0)
            Asteroid();

        if (CurrentState == GameState.Red)
        {
            CurrentState = GameState.Blue;
            m_RedUIRoot.color = new Color(1f, 0f, 0f, 0f);
            m_BluUIRoot.color = new Color(0f, 0f, 1f, 0.5f);
        }
        else if (CurrentState == GameState.Blue)
        {
            CurrentState = GameState.Red;
            m_RedUIRoot.color = new Color(1f, 0f, 0f, 0.5f);
            m_BluUIRoot.color = new Color(0f, 0f, 1f, 0f);
        }
    }
    private void EndGame()
    {
        CurrentState = GameState.End;

        if (NautsBalance > 0)
        {
            Debug.Log("Red Victory");
            m_RedMissileInd.sprite = m_MissileVictory;
            m_BluMissileInd.sprite = m_MissileFail;

            m_RedVictoryRoot.SetActive(true);
        }
        else if (NautsBalance < 0)
        {
            Debug.Log("Blu Victory");
            m_RedMissileInd.sprite = m_MissileFail;
            m_BluMissileInd.sprite = m_MissileVictory;

            m_BluVictoryRoot.SetActive(true);
        }
    }

    public void ISSHit(bool _redColl)
    {
        if (_redColl)
            NautsBalance++;
        else
            NautsBalance--;

        SetNautsUI();

        if (Mathf.Abs(NautsBalance) == 3)
            EndGame();
    }

    private void SetNautsUI()
    {
        foreach (Image _obj in m_RedNautIndicators)
            _obj.color = new Color(1f, 1f, 1f, 0f);
        foreach (Image _obj in m_BluNautIndicators)
            _obj.color = new Color(1f, 1f, 1f, 0f);

        if(NautsBalance > 0)
        {
            for (int _r = 0; _r < NautsBalance; _r++)
                m_RedNautIndicators[_r].color = new Color(1f, 1f, 1f, 1f);
        }
        else if(NautsBalance < 0)
        {
            for (int _b = 0; _b < Mathf.Abs(NautsBalance); _b++)
                m_BluNautIndicators[_b].color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public enum MissileTypes
    {
        None,
        Naut,
        Junk,
        Sprd,
        Pull
    }
    public void LastMissile(MissileTypes _type)
    {
        if(CurrentState == GameState.Start)
        {
            Debug.Log("lastmissile start");
            m_RedMissileInd.sprite = m_MissileNone;
            m_BluMissileInd.sprite = m_MissileNone;
            return;
        }
        
        if(CurrentState == GameState.Red)
        {
            switch (_type)
            {
                case MissileTypes.Naut:
                    m_RedMissileInd.sprite = m_MissileNaut;
                    break;
                case MissileTypes.Junk:
                    m_RedMissileInd.sprite = m_MissileJunk;
                    break;
                case MissileTypes.Sprd:
                    m_RedMissileInd.sprite = m_MissileSprd;
                    break;
                case MissileTypes.Pull:
                    m_RedMissileInd.sprite = m_MissilePull;
                    break;
            }
        }
        else if (CurrentState == GameState.Blue)
        {
            switch (_type)
            {
                case MissileTypes.Naut:
                    m_BluMissileInd.sprite = m_MissileNaut;
                    break;
                case MissileTypes.Junk:
                    m_BluMissileInd.sprite = m_MissileJunk;
                    break;
                case MissileTypes.Sprd:
                    m_BluMissileInd.sprite = m_MissileSprd;
                    break;
                case MissileTypes.Pull:
                    m_BluMissileInd.sprite = m_MissilePull;
                    break;
            }
        }
        
    }

    private void Asteroid()
    {
        Debug.Log("Asteroid");
    }
}
