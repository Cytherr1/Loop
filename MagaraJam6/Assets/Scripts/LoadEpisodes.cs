using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadEpisodes : MonoBehaviour
{
    public void LoadEpisodeOne()
    {
        SceneManager.LoadScene("Level 1");
    }
}
