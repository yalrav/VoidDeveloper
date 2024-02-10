using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class paused : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject gameCamera;
    [SerializeField]
    private bool isPaused = false;
    [SerializeField]
    private Button continueButton, restartButton, exitButton;

    private void Start()
    {
        continueButton.onClick.AddListener(Continue);
        restartButton.onClick.AddListener(Restart);
        exitButton.onClick.AddListener(Exit);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            gameCamera.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            gameCamera.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Continue()
    {
        TogglePause();
    }

    private void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void Exit()
    {
        // Добавьте здесь подтверждение выхода перед выходом из игры
        Application.Quit();
    }
}