using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadEpisodes : MonoBehaviour
{
    public bool tp = false;
    public int level;
    private void Start()
    {
        tp = GameObject.FindWithTag("Teleporter");
    }
    public void LoadEpisodeOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Teleporter()
    {
        if(tp) 
        {
            SceneManager.LoadScene(level);
        }
    }
}
