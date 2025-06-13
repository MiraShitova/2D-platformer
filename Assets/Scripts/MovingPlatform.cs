using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;

    private int currentPointIndex = 0;
    private Transform playerOnPlatform;

    private void Update()
    {
        MoveToNextPoint();
    }

    private void MoveToNextPoint()
    {
        if (waypoints.Length == 0) return;

        Vector2 currentPos = transform.position;
        Vector2 targetPos = waypoints[currentPointIndex].position;

        transform.position = Vector2.MoveTowards(currentPos, targetPos, speed * Time.deltaTime);

        if (Vector2.Distance(currentPos, targetPos) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % waypoints.Length;
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
        if (collision.CompareTag("Player") && playerOnPlatform == collision.transform)
        {
            playerOnPlatform.SetParent(null);
            playerOnPlatform = null;
        }
    }
}
