using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    private static GameObject uiHUD;

    private void Start()
    {
        uiHUD = hud;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
        AudioManager.instance.RestartMusic("Main");
    }

    public static void PauseGame()
    {
        Time.timeScale = 0f;
        uiHUD.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioManager.instance.PauseMusic(true);
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1f;
        uiHUD.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioManager.instance.PauseMusic(false);
    }

    public static void RestartGame()
    {
        Time.timeScale = 1f;
        uiHUD.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //AudioManager.instance.RestartMusic("Main");
    }
}
