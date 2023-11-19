using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {   
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameObject.FindWithTag("Player").GetComponent<Controller>().enabled = false;
        GameObject.FindWithTag("Machine").GetComponent<Machine>().enabled = false;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameObject.FindWithTag("Player").GetComponent<Controller>().enabled = true;
        GameObject.FindWithTag("Machine").GetComponent<Machine>().enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }
}
