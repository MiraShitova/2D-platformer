using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public AudioSource audioSource; // -----------

    public float Speed;
    public Vector3 SpawnPosition;
    public float JumpForce = 4.5f;
    public bool isGrounded;
    public int items;
    public Text itemsTextLegacy;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    private Animator animator;

    
    private float elapsedTime = 0f;
    public TextMeshProUGUI timerText;


    public AudioClip pickupSound; //-------------------
    public AudioClip trapSound;
    public AudioClip checkpointSound;
    public AudioClip bounceSound;





    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // -----------

        transform.position = SpawnPosition; 
    }

    private void FixedUpdate() 
    {
        if (Input.GetKey(KeyCode.D)) 
        {
            transform.position += transform.right * Speed; 
            spriteRenderer.flipX = true; 
        }

        if (Input.GetKey(KeyCode.A)) 
        {
            transform.position -= transform.right * Speed; 
            spriteRenderer.flipX = false; 
        }
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0); 
        }


        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (isGrounded == true)
            {
                rb2d.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);  
            }
        }

        
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

        elapsedTime += Time.deltaTime;
        UpdateTimerUI();

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

    
    public void AddItem(int count)
    {
        items += count; 

        itemsTextLegacy.text = $"Items collected: {items}/7"; 
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Traps")) 
        {
            if (trapSound != null) audioSource.PlayOneShot(trapSound); //  звук пастки
            transform.position = SpawnPosition; 
        }
    }

    

}
