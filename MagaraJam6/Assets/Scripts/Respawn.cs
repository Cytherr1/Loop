using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] AudioClip respawn;
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject particle;
    [SerializeField] GameObject ucantdie;
    private float sec = 1.5f;
    private float timer = 0;

    private void Update()
    {
        if (ucantdie.activeSelf == true)
        {
            timer += Time.deltaTime;
            if (timer == sec) 
            {
                ucantdie.SetActive(false);
                timer = 0;
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.FindWithTag("Player").transform.position = spawn.transform.position;
        Instantiate(particle, spawn.transform.position, Quaternion.identity);
        GameObject.FindWithTag("Player").GetComponent<AudioSource>().PlayOneShot(respawn);
        ucantdie.SetActive(true);
    }
}
