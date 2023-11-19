using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] AudioClip respawn;
    [SerializeField] GameObject spawn;
    public LineRenderer lineRenderer;
    public Transform laserPosition;
    public Vector2 vec;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vec);
        lineRenderer.SetPosition(0, laserPosition.position);
        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        if (hit.transform.gameObject.CompareTag("Player"))
        {
            GameObject.FindWithTag("Player").transform.position = spawn.transform.position;
            GameObject.FindWithTag("Player").GetComponent<AudioSource>().PlayOneShot(respawn);
        }

    }
}
