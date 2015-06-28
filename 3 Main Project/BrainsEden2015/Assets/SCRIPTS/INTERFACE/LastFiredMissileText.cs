using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LastFiredMissileText : MonoBehaviour 
{
    [SerializeField] private Text Title;
    [SerializeField] private Text Base;

    [SerializeField] private List<string> Titles = new List<string>();
    [SerializeField] private List<string> Bases = new List<string>();

    [SerializeField] private bool IsRed = true;
    private int LastText = 0;

    public void SetVisible(bool _true)
    {
        if(!_true)
        {
            Title.color = new Color(0f, 0f, 0f, 0f);
            Base.color = new Color(0f, 0f, 0f, 0f);
        }
        else if (IsRed)
        {
            Set(LastText);
            Title.color = new Color(1f, 0f, 0f, 1f);
            Base.color = new Color(1f, 0f, 0f, 1f);
        }
        else if (!IsRed)
        {
            Set(LastText);
            Title.color = new Color(0f, 0f, 1f, 1f);
            Base.color = new Color(0f, 0f, 1f, 1f);
        }
    }

    public void Set(int _rocketType)
    {
        LastText = _rocketType;
        Title.text = Titles[_rocketType];
        Base.text = Bases[_rocketType];
    }
}
