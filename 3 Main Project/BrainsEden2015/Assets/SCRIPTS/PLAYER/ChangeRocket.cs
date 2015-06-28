using UnityEngine;
using System.Collections;

public class ChangeRocket : MonoBehaviour 
{
    private PlayerTarget m_ShootComp;
    [SerializeField] private LastFiredMissileText m_TextComp;
    private int LastRocket = 0;	


    void Start()
    {
        m_ShootComp = GetComponent<PlayerTarget>();
    }

    public void UIChangeRocket()
    {
        LastRocket++;

        if (LastRocket == 5)
            LastRocket = 1;

        SetRocket(LastRocket);
    }

    private void SetRocket (int _val)
    {
        if (_val == 1)
        {
            m_ShootComp.RocketType = 1;
            LastRocket = 1;
            m_TextComp.Set(0);
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Naut);
        }
        else if (_val == 2)
        {
            m_ShootComp.RocketType = 2;
            LastRocket = 2;
            m_TextComp.Set(1);
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Junk);
        }
        else if (_val == 3)
        {
            m_ShootComp.RocketType = 3;
            LastRocket = 3;
            m_TextComp.Set(2);
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Sprd);
        }
        else if (_val == 4)
        {
            m_ShootComp.RocketType = 4;
            LastRocket = 4;
            m_TextComp.Set(3);
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Pull);
        }
    }

	// Update is called once per frame
	void Update () 
	{
        if (!m_ShootComp.enabled)
            return;

		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
            SetRocket(1);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2))
        {
            SetRocket(2);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3))
        {
            SetRocket(3);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4))
        {
            SetRocket(4);
		}
	}
}