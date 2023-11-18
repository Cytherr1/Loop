using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public Animator anim;
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        menu.SetActive(false);
        anim.SetTrigger("intro");       
    }
    
}
