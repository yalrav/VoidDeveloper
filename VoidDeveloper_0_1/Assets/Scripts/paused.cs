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
    private bool menuAvailable = true;
    [SerializeField]
    private Button continueButton, restartButton, exitButton;

    private void Start()
    {
        continueButton.onClick.AddListener(Continue);
        restartButton.onClick.AddListener(Restart);
        exitButton.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(menuAvailable);
            menuAvailable = !menuAvailable;
        }

        if (!menuAvailable)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void Continue()
    {
        pauseMenu.SetActive(menuAvailable);
        menuAvailable = !menuAvailable;
    }

    void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    void Exit()
    {
        Application.Quit();
    }
}