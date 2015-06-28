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
		{
			CurrentState = GameState.Red;
		}
		else
		{
			CurrentState = GameState.Blue;
		}
		
		SwitchState();
		
	}
	
	public PlayerTarget redPlayerMove;
	public PlayerTarget bluPlayerMove;
	[SerializeField] private ISSTargeterBehaviour m_RedTargeter;
	[SerializeField] private ISSTargeterBehaviour m_BluTargeter;
	
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
	public int RedNauts = 0;
	public int BluNauts = 0;
	
	[SerializeField] private Image m_RedUIRoot;
	[SerializeField] private GameObject m_RedVictoryRoot;
	[SerializeField] private List<Image> m_RedNautIndicators;
    [SerializeField] private Image m_RedMissileInd;
    [SerializeField] private LastFiredMissileText m_GuideTextRed;
	
	[SerializeField] private Image m_BluUIRoot;
	[SerializeField] private GameObject m_BluVictoryRoot;
	[SerializeField] private List<Image> m_BluNautIndicators;
	[SerializeField] private Image m_BluMissileInd;
    [SerializeField] private LastFiredMissileText m_GuideTextBlu;
	
	[SerializeField] private Sprite m_MissileNone;
	[SerializeField] private Sprite m_MissileNaut;
	[SerializeField] private Sprite m_MissileJunk;
	[SerializeField] private Sprite m_MissileSprd;
	[SerializeField] private Sprite m_MissilePull;
	[SerializeField] private Sprite m_MissileVictory;
	[SerializeField] private Sprite m_MissileFail;
	
	[SerializeField] private Text m_ControlsText;
	[SerializeField] private Text m_TimerText;
	private float m_CountdownLength = 5f;
	
	public bool nauts_ui_debug = false;
	public bool switch_debug = false;
	public bool win_debug = false;
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Manager_Game.Instance.ChangeScene(1);
		
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
	
	public void SwitchState()
	{
		StopAllCoroutines();
		
		if (Mathf.Abs(NautsBalance) == 3)
		{
			EndGame();
			return;
		}
		
		m_StatesRan++;
		m_ControlsText.color = new Color(1f, 1f, 1f, (10 - m_StatesRan) * 0.1f);
		
		StartCoroutine(SwitchDo());
	}
	IEnumerator SwitchDo()
	{
		redPlayerMove.enabled = false;
		bluPlayerMove.enabled = false;
		redPlayerMove.GetGuide.SetActive(false);
		bluPlayerMove.GetGuide.SetActive(false);
		m_RedUIRoot.color = new Color(1f, 0f, 0f, 0f);
		m_BluUIRoot.color = new Color(0f, 0f, 1f, 0f);
        m_GuideTextRed.SetVisible(false);
        m_GuideTextBlu.SetVisible(false);
		
		m_TimerText.color = new Color(1f, 1f, 1f, 1f);
		float _time = 2.5f;
		while (_time > 0f)
		{
			_time -= Time.deltaTime;
			m_TimerText.text = _time.ToString("0.0") + "s";
			yield return new WaitForEndOfFrame();
		}
		
		
		if (CurrentState == GameState.Red) //Switch to Blu Player
		{
			CurrentState = GameState.Blue;
			
			m_TimerText.color = new Color(0.5f, 0.5f, 1f, 1f);
			
			m_RedUIRoot.color = new Color(1f, 0f, 0f, 0f);
			m_BluUIRoot.color = new Color(0f, 0f, 1f, 0.5f);
            m_RedTargeter.TriggerFades();

            m_GuideTextRed.SetVisible(false);
            m_GuideTextBlu.SetVisible(true);
			
			redPlayerMove.GetGuide.SetActive(false);
			bluPlayerMove.GetGuide.SetActive(true);
			
			redPlayerMove.enabled = false;
			bluPlayerMove.enabled = true;
		}
		else if (CurrentState == GameState.Blue) //Switch to Red Player
		{
			CurrentState = GameState.Red;
			
			m_TimerText.color = new Color(1f, 0.5f, 0.5f, 1f);
			
			m_RedUIRoot.color = new Color(1f, 0f, 0f, 0.5f);
			m_BluUIRoot.color = new Color(0f, 0f, 1f, 0f);
            m_BluTargeter.TriggerFades();

            m_GuideTextRed.SetVisible(true);
            m_GuideTextBlu.SetVisible(false);
			
			redPlayerMove.GetGuide.SetActive(true);
			bluPlayerMove.GetGuide.SetActive(false);
			
			redPlayerMove.enabled = true;
			bluPlayerMove.enabled = false;
		}
		
		StartCoroutine(TurnCountdown());
	}
	IEnumerator TurnCountdown()
	{
		float _time = m_CountdownLength;
		while(_time > 0f)
		{
			_time -= Time.deltaTime;
			m_TimerText.text = _time.ToString("0.0") + "s";
			yield return new WaitForEndOfFrame();
		}
		
		SwitchState();
	}
	
	private void EndGame()
	{
		StopAllCoroutines();
		m_TimerText.text = "";
		CurrentState = GameState.End;
		
		if (RedNauts == 3)
		{
			Debug.Log("Red Victory");
			m_RedMissileInd.sprite = m_MissileVictory;
			m_BluMissileInd.sprite = m_MissileFail;
			
			m_RedVictoryRoot.SetActive(true);
		}
		else if (BluNauts == 3)
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
			RedNauts++;
		else
			BluNauts++;
		
		SetNautsUI();
		
		if (RedNauts == 3 || BluNauts == 3)
			EndGame();
	}
	
	private void SetNautsUI()
	{
		foreach (Image _obj in m_RedNautIndicators)
			_obj.color = new Color(1f, 0f, 0f, 0.5f);
		foreach (Image _obj in m_BluNautIndicators)
			_obj.color = new Color(0f, 0f, 1f, 0.5f);
		
		if (RedNauts > 0)
		{
			for (int _r = 0; _r < RedNauts; _r++)
				m_RedNautIndicators[_r].color = new Color(1f, 0f, 0f, 1f);
		}
		
		if (BluNauts > 0)
		{
			for (int _b = 0; _b < Mathf.Abs(BluNauts); _b++)
				m_BluNautIndicators[_b].color = new Color(0f, 0f, 1f, 1f);
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
			m_RedMissileInd.sprite = m_MissileNaut;
			m_BluMissileInd.sprite = m_MissileNaut;
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