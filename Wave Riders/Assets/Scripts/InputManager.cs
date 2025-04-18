using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    #region Singleton
    public static InputManager Singleton;
    /*
    private void Start()
    {
        AudioManager.Singleton.PlaySoundEffect("Background Music");
    }*/
    public void Awake()
    {
        controls = new PlayerControls();
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
    public static PlayerControls controls;

    public static event System.Action OnLeftInput;
    public static event System.Action OnRightInput;
    public static event System.Action OnPauseInput;
    public static event System.Action OnJumpInput;
    public static event System.Action OnShieldInput;

    void OnEnable()
    {
        //Add individual A and D inputs
        controls.Player.Left.performed += ctx => OnLeftInput?.Invoke();
        controls.Player.Right.performed += ctx => OnRightInput?.Invoke();
        controls.Player.Pause.performed += ctx => OnPauseInput?.Invoke();
        controls.Player.Jump.performed += ctx => OnJumpInput?.Invoke();
        controls.Player.Shield.performed += ctx => OnShieldInput?.Invoke();

        controls.Player.Enable();
    }


}

