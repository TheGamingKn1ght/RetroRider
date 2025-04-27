using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void PauseGame()
    {
        Time.timeScale = 0f;
        HUD.Singleton.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioManager.instance.PauseMusic(true);
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1f;
        HUD.Singleton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioManager.instance.PauseMusic(false);
    }
}
