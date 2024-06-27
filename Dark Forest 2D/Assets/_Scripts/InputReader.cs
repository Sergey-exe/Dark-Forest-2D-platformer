using System;
using UnityEngine;

public class InputReader : MonoBehaviour 
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private KeyCode _keyPlayerMoveRight;
    [SerializeField] private KeyCode _keyPlayerMoveLeft;
    [SerializeField] private KeyCode _keyPlayerJump;
    [SerializeField] private KeyCode _keyAbsorption;

    public float InputMoveAxis()
    {
        return InputAxis(Horizontal);
    }

    public bool DownButtonPlayerJump()
    {
        return DownButton(_keyPlayerJump);
    }

    public bool DownButtonAbsorption()
    {
        return DownButton(_keyAbsorption);
    }

    private bool DownButton(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
            return true;

        return false;
    }

    private float InputAxis(string axis)
    {
        return Input.GetAxis(axis);
    }
}
