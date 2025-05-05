using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Player player;

    public bool isActive = true; // Чи чекпоінт доступний для активації
    private bool isActivated = false; // Чи вже активували

    public Sprite idleSprite;
    public Sprite glowSprite;
    public float switchDelay = 0.5f;

    private SpriteRenderer spriteRenderer;
    private bool isAnimating = false; // Прапор для перевірки, чи йде анімація
    private bool useGlow = false; // Прапор для перемикання між спрайтами

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleSprite; // початковий спрайт
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isActive && !isActivated) // Якщо гравець заходить в область чекпоінту і він ще не був активований
        {
            player.SpawnPosition = transform.position; // Встановлюємо нову точку спавну для гравця
            isActivated = true;
            ActivateCheckpoint(); // Активуємо чекпоінт (запускаємо анімацію)
        }
    }

    public void ActivateCheckpoint()
    {
        isAnimating = true; // Вмикаємо анімацію
        Animate();
    }

    private void Animate()  // Метод для циклічної зміни спрайтів для анімації
    {
        if (!isAnimating) return; // Якщо анімація не активна, припиняємо виконання методу

        spriteRenderer.sprite = useGlow ? glowSprite : idleSprite; // Перемикаємо між спрайтами: idleSprite або glowSprite
        useGlow = !useGlow; // Перемикаємо значення useGlow, щоб змінити спрайт на наступний

        Invoke(nameof(Animate), switchDelay); // рекурсія з затримкою.  // Викликаємо метод Animate через switchDelay для створення циклічної анімації
    }
}
