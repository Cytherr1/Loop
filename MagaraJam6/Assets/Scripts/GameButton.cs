using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    private bool isPressed = false;
    [SerializeField] Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isPressed)
        {
            isPressed = true;
            animator.SetBool("pressed", true);
            GameObject.FindWithTag("Teleporter").GetComponent<FinishLevel>().ButtonsPressed += 1;
        }
    }
}
