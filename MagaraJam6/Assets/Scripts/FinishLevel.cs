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
            SceneManager.LoadScene(level + 1);
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
