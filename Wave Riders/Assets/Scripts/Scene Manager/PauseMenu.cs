using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private PlayerController player;
    private void OnEnable()
    {
        InputManager.OnPauseInput += Pause;
    }

    private void OnDisable()
    {
        InputManager.OnPauseInput -= Pause;
    }

    private void Start()
    {
        pauseCanvas.SetActive(false);
    }

    public void Pause()
    {
        pauseCanvas.SetActive(!pauseCanvas.activeSelf);

        if (pauseCanvas.activeSelf)
        {
            UIManager.PauseGame();
            player.DeactivateMovement();
        }
        else
        {
            UIManager.ResumeGame();
            player.ActivateMovement();
        }
    }

    public void GoToScene(int sceneIndex)
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}