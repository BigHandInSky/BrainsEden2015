using UnityEngine;
using System.Collections;

public class ChangeRocket : MonoBehaviour 
{
    private PlayerTarget m_ShootComp;
    [SerializeField] private bool m_IsRed;
    [SerializeField] private LastFiredMissileText m_TextComp;
    private int LastRocket = 1;
    private bool Changed = false;

    void Start()
    {
        m_ShootComp = GetComponent<PlayerTarget>();
    }

    public void UIChangeRocket()
    {
        if (Changed)
            return;

        if (!m_ShootComp.enabled)
            return;

        LastRocket++;

        if (LastRocket == 4)
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
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Junk);
        }
        else if (_val == 2)
        {
            m_ShootComp.RocketType = 2;
            LastRocket = 2;
            m_TextComp.Set(1);
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Sprd);
        }
        else if (_val == 3)
        {
            m_ShootComp.RocketType = 3;
            LastRocket = 3;
            m_TextComp.Set(2);
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Pull);
        }
    }

	// Update is called once per frame
	void Update () 
	{
        if (!m_ShootComp.enabled)
            return;

        if (m_IsRed && Input.GetAxis("Red Player Change Rocket") > 0f)
        {
            UIChangeRocket();
            Changed = true;
		}
        else if (!m_IsRed && Input.GetAxis("Blue Player Change Rocket") > 0f)
        {
            UIChangeRocket();
            Changed = true;
        }
        else if (Changed)
            Changed = false;
	}
}