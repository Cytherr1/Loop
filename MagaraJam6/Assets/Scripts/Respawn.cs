using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] AudioClip respawn;
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject particle;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.FindWithTag("Player").transform.position = spawn.transform.position;
        Instantiate(particle, spawn.transform.position, Quaternion.identity);
        GameObject.FindWithTag("Player").GetComponent<AudioSource>().PlayOneShot(respawn);
    }
}
