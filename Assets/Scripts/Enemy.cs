using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform pointsContainer;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;

    public List<Transform> points;
    public int currentPoint;

    public float speed;
    public float damage;
    public float culdown;

    private Vector3 targetPosition;
    private Transform target;

    public float fromStartMaxDistance;
    private Vector3 startPosition;

    private bool isCanAttack = true;
    private bool isBackingOff = false;

    private void Start()
    {
        for (int i = 0; i < pointsContainer.childCount; i++) 
        {
            points.Add(pointsContainer.GetChild(i));
        }

        startPosition = transform.position;

        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (target)
        {
            if (target)
            {
                if (isBackingOff)
                {
                    targetPosition = target.position + Vector3.up * 2;
                }
                else
                {
                    targetPosition = target.position;
                }
            }
        }
        else
        {
            targetPosition = points[currentPoint].position;
        }

        if (transform.position.x < targetPosition.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }


        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);


        if (transform.position == points[currentPoint].position)
        {
            currentPoint++;

            if (currentPoint == points.Count)
            {
                currentPoint = 0;
            }
        }

        if (Vector3.Distance(transform.position, startPosition) > fromStartMaxDistance)
        {
            target = null;
        }

        rb2d.velocity = Vector2.zero;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isCanAttack) return; // Не бити, якщо кулдаун

            collision.gameObject.GetComponent<Player>().Damage(damage);

            // Починаємо Кулдаун Атаки
            isCanAttack = false;
            StartCoroutine(CuldownTimer());

            // Починаємо "Відліт"
            isBackingOff = true;
            StartCoroutine(BackOffTimer()); 
        }
    }

    private IEnumerator BackOffTimer()
    {
        yield return new WaitForSeconds(0.5f);
        isBackingOff = false; 
    }

    private IEnumerator CuldownTimer()
    {
        yield return new WaitForSeconds(culdown);
        isCanAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = null;
        }
    }

    public void ResetState()
    {
        // 1. Примусово зупиняємо всі корутини (BackOffTimer, CuldownTimer)
        StopAllCoroutines();

        // 2. Скидаємо ціль
        target = null;

        // 3. Скидаємо всі бойові стани до початкових
        isCanAttack = true;
        isBackingOff = false;

        // 4. Скидаємо швидкість, якщо вона могла змінитись
        rb2d.velocity = Vector2.zero;
    }

}
