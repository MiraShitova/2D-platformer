using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Player player;

    public bool isActive = true; 
    private bool isActivated = false; 

    public Sprite idleSprite;
    public Sprite glowSprite;
    public float switchDelay = 0.5f;

    private SpriteRenderer spriteRenderer;
    private bool isAnimating = false; 
    private bool useGlow = false;

    public AudioClip checkpointSound;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleSprite; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isActive && !isActivated) 
        {
            if (checkpointSound != null) AudioSource.PlayClipAtPoint(checkpointSound, transform.position); // звук чекпоінту
            player.SpawnPosition = transform.position; 
            isActivated = true;
            ActivateCheckpoint(); 
        }
    }

    public void ActivateCheckpoint()
    {
        isAnimating = true; 
        Animate();
    }

    private void Animate()  
    {
        if (!isAnimating) return; 

        spriteRenderer.sprite = useGlow ? glowSprite : idleSprite; 
        useGlow = !useGlow; 

        Invoke(nameof(Animate), switchDelay); 
    }
}
