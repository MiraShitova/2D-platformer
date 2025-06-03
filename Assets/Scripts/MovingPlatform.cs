using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    public float speed = 2f;
    private int currentPointIndex = 0;
    private Transform playerOnPlatform;

    private void Update()
    {
        if (points.Length == 0) return;

        Transform targetPoint = points[currentPointIndex];

        Vector3 targetPos = new Vector3(targetPoint.position.x, targetPoint.position.y, 0f);
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, 0f);

        transform.position = Vector3.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnPlatform = collision.transform;
            playerOnPlatform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnPlatform.SetParent(null);
            playerOnPlatform = null;
        }
    }
}
