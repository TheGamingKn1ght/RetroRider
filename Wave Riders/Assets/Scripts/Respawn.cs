using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseCanvas;
    public void RestartGame(int sceneIndex)
    {
        Time.timeScale = 1f;
        pauseCanvas.ActivatePausing();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        if (sceneIndex == 1) { UIManager.RestartGame(); }
        this.gameObject.SetActive(false);
    }
}
