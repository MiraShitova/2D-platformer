using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bust : MonoBehaviour
{
    public float bounceMultiplier = 8.0f; // Множник підсилення стрибка
    public Sprite bounceSprite; // Спрайт, який буде показуватись при торканні
    private Sprite originalSprite; // Початковий спрайт

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite; // Запам'ятовуємо початковий спрайт
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Перевіряємо, чи гравець зіткнувся з батутом
        {
            collision.rigidbody.AddForce(Vector2.up * bounceMultiplier, ForceMode2D.Impulse); // Додаємо підсилений імпульс вгору
            StartCoroutine(ChangeSpriteTemporarily()); // Змінюємо спрайт на короткий час
        }
    }

    private IEnumerator ChangeSpriteTemporarily()
    {
        spriteRenderer.sprite = bounceSprite; // Змінюємо спрайт на новий
        yield return new WaitForSeconds(0.5f); // Чекаємо 0.5 секунди
        spriteRenderer.sprite = originalSprite; // Повертаємо початковий спрайт
    }
  
}
