using UnityEngine;
using System.Collections;

public class ButtonGameControl : MonoBehaviour 
{
    [SerializeField] private PlayerTarget RedPlayerControl;
    [SerializeField] private ChangeRocket RedPlayerChange;
    [SerializeField] private PlayerTarget BluPlayerControl;
    [SerializeField] private ChangeRocket BluPlayerChange;

    private bool Rotate = false;
    private bool RotateLeft = false;

    public void StartRotate(bool _rotateLeft)
    {
        Rotate = true;
        RotateLeft = _rotateLeft;
    }
    public void StopRotate()
    {
        Rotate = false;
    }

    public void ChangeRocket()
    {
        if (GameStateHandler.Instance.CurrentState == GameStateHandler.GameState.Red)
        {
            RedPlayerChange.UIChangeRocket();
        }
        else if (GameStateHandler.Instance.CurrentState == GameStateHandler.GameState.Blue)
        {
            BluPlayerChange.UIChangeRocket();
        }
    }

    void Update()
    {
        if (GameStateHandler.Instance.CurrentState == GameStateHandler.GameState.End)
            gameObject.SetActive(false);

        if (Rotate)
        {
            if (GameStateHandler.Instance.CurrentState == GameStateHandler.GameState.Red)
            {
                RedPlayerControl.Rotate(RotateLeft);
            }
            else if (GameStateHandler.Instance.CurrentState == GameStateHandler.GameState.Blue)
            {
                BluPlayerControl.Rotate(RotateLeft);
            }
        }
    }
}
