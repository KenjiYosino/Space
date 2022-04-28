using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    private ControllerPlayerMove player;

    private void Start()
    {
        PlayerPrefs.SetFloat("Health", 50.0F);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControllerPlayerMove>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (player != null)
        {
            player.examination = true;
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            gamePaused = false;
        }
    }

    public void Pause()
    {
        if (player != null)
        {
            player.examination = false;
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
            gamePaused = true;
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GamePlay");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }    
}
