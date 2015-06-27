using UnityEngine;
using System.Collections;

public class ChangeRocket : MonoBehaviour 
{
    private PlayerTarget m_ShootComp;
		
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
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Naut);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2))
        {
            m_ShootComp.RocketType = 2;
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Junk);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3))
        {
            m_ShootComp.RocketType = 3;
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Sprd);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4))
        {
            m_ShootComp.RocketType = 4;
            GameStateHandler.Instance.LastMissile(GameStateHandler.MissileTypes.Pull);
		}
	}
}