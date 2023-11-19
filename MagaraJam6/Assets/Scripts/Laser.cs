using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform laserPosition;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up);
        lineRenderer.SetPosition(0, laserPosition.position);
        if (hit && !hit.collider.gameObject.CompareTag("Area"))
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Player"))
        {
            lineRenderer.SetPosition(1, hit.point);
        }

    }
}
