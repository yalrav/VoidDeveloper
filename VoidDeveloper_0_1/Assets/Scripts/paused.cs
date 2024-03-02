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
    private GameObject[] gameCamera;
    [SerializeField]
    private GameObject Pause_text;
    [SerializeField]
    //private GameObject pause_button;
    //[SerializeField]
    private bool isPaused = false;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void Set()
    {
        TogglePause();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            Pause_text.SetActive(true);
            //pause_button.SetActive(true);
            foreach (var objk in gameCamera)
            {
                objk.SetActive(false);
            }
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            Pause_text.SetActive(false);
            //pause_button.SetActive(false);
            foreach (var objk in gameCamera)
            {
                objk.SetActive(true);
            }
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}