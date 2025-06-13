using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bust : MonoBehaviour
{
    public float bounceMultiplier = 8.0f; 
    public Sprite bounceSprite; 
    private Sprite originalSprite; 

    private SpriteRenderer spriteRenderer;

    public AudioClip bounceSound;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.rigidbody.AddForce(Vector2.up * bounceMultiplier, ForceMode2D.Impulse);
            PlayBounceEffect();
        }
    }

    private void PlayBounceEffect()
    {
        AudioSource.PlayClipAtPoint(bounceSound, transform.position); 
        StartCoroutine(ChangeSpriteTemporarily());
    }

    private IEnumerator ChangeSpriteTemporarily()
    {
        spriteRenderer.sprite = bounceSprite; 
        yield return new WaitForSeconds(0.5f); 
        spriteRenderer.sprite = originalSprite; 
    }
  
}
