using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce = 4.5f;
    public float sprintSpeed = 8f;
    public Vector3 SpawnPosition;

    public float health;
    public float healthMax;
    public float damageForce;
    public Image healthImage;


    private float currentMoveSpeed;

    public bool isGrounded;

    private float elapsedTime = 0f;


    public TextMeshProUGUI timerText;

    
    public AudioClip pickupSound; 
    public AudioClip trapSound;
    public AudioClip checkpointSound;
    public AudioClip bounceSound;

    public AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    private Animator animator;


    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); 

        transform.position = SpawnPosition;

        currentMoveSpeed = Speed;
        health = healthMax;
        healthImage.fillAmount = health / healthMax;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void Update() 
    {
        HandleSprint();
        PlayerJump();
        PlayerAnimations();
        UpdateTimerUI();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        elapsedTime += Time.deltaTime;

    }

    public void Damage(float damgeCount)
    {
        health -= damgeCount;
        healthImage.fillAmount = health / healthMax;

        rb2d.AddForce(transform.up * damageForce, ForceMode2D.Impulse);
        
        if (health <= 0)
        {
            transform.position = SpawnPosition;
            health = healthMax;
            healthImage.fillAmount = health / healthMax;
        }
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * horizontal * currentMoveSpeed * Time.fixedDeltaTime;

        if (horizontal != 0)
            spriteRenderer.flipX = horizontal > 0;
    }

    private void HandleSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift)) // Перевіряємо, чи затиснута клавіша Left Shift
        {
            currentMoveSpeed = sprintSpeed; // Встановлюємо швидкість спрінту
        }
        else
        {
            currentMoveSpeed = Speed; // Повертаємо звичайну швидкість
        }
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                rb2d.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void PlayerAnimations()
    {
        if (isGrounded == true)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                animator.Play("Run");
            }
            else
            {
                animator.Play("Idle");
            }
        }

        else
        {
            animator.Play("Jump");
        }
    }


    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = $"Час проходження: {minutes:00}:{seconds:00}";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Traps")) 
        {
            if (trapSound != null) audioSource.PlayOneShot(trapSound); //  звук пастки
            transform.position = SpawnPosition;
            health = healthMax;
            healthImage.fillAmount = health / healthMax;
        }
    }

}
