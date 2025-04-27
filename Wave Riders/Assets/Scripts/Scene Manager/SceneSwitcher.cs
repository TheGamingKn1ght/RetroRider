using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] GameObject MenuCanvas;
    [SerializeField] GameObject Backup;
    public static GameObject menu;
    public static GameObject backup;

    #region Singleton
    public static SceneSwitcher Singleton;
    public void Awake()
    {
        menu = MenuCanvas;
        backup = Backup;
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
    public void PlayGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        MenuCanvas.SetActive(false);
        Backup.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
