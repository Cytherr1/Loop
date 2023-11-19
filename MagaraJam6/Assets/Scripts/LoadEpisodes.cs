using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadEpisodes : MonoBehaviour
{
    public bool tp = false;
    public int level;
    public GameObject outro;
    private void Start()
    {
        tp = GameObject.FindWithTag("Teleporter");
    }
    public void LoadEpisodeOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Teleporter()
    {
        if(tp && level != 7) 
        {
            SceneManager.LoadScene(level);
        }
        if(level == 7)
        {
            outro.SetActive(true);
            //outro.GetComponentInChildren<Animator>().
        }
    }
}
