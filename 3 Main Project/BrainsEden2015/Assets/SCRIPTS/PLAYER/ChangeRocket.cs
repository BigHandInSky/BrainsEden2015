using UnityEngine;
using System.Collections;

public class ChangeRocket : MonoBehaviour 
{
    private PlayerTarget m_ShootComp;
    [SerializeField] private LastFiredMissileText m_TextComp;
		
    void Start()
    {
        m_ShootComp = GetComponent<PlayerTarget>();
    }

	// Update is called once per frame
	void Update () 
	{
        if (!m_ShootComp.enabled)
            return;

		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
            m_ShootComp.RocketType = 1;
            m_TextComp.Set(0);
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Naut);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2))
        {
            m_ShootComp.RocketType = 2;
            m_TextComp.Set(1);
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Junk);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3))
        {
            m_ShootComp.RocketType = 3;
            m_TextComp.Set(2);
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Sprd);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4))
        {
            m_ShootComp.RocketType = 4;
            m_TextComp.Set(3);
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Pull);
		}
	}
}