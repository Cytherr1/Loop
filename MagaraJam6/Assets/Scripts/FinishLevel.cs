using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] int requiredButtons;
    [SerializeField] Animator animator;
    public int ButtonsPressed = 0;
    private bool isTpReady = false;
    private int level;
    private void Awake()
    {
        level = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (ButtonsPressed == requiredButtons)
        {
            isTpReady = true;
            animator.SetBool("ready", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isTpReady)
        {
            UnlockNewLevel();

            collision.GetComponentInChildren<Animator>().SetBool("run", false);
            collision.GetComponentInChildren<Animator>().SetBool("jump", false);
            collision.GetComponentInChildren<Animator>().SetBool("fall", false);
            collision.GetComponent<Controller>().enabled = false;
            collision.GetComponentInChildren<Animator>().SetTrigger("teleport");          
            collision.GetComponentInChildren<LoadEpisodes>().tp = true;
            collision.GetComponentInChildren<LoadEpisodes>().level = level + 1;
            
            
        }
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
