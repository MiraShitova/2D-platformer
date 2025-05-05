using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    //-----------------------Змінні--------------------------------------------------
   
    public float Speed;
    public Vector3 SpawnPosition;
    public float JumpForce = 4.5f;
    public bool isGrounded;
    public int items;
    public Text itemsTextLegacy;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    private Animator animator;

    // Таймер проходження гри
    private float elapsedTime = 0f;
    public TextMeshProUGUI timerText; // Посилання на UI-текст для таймера

    public void Start()
    {// беремо доступ до компонентів один раз і потім постійно використовуємо, а не постійно звертаємось щоб взяти доступ
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        transform.position = SpawnPosition; // задаємо місце спавну гравця
    }

    private void FixedUpdate() //------------------Пересування по карті------------------------------
    {
        if (Input.GetKey(KeyCode.D)) //якщо затиснути D
        {
            transform.position += transform.right * Speed; //то позиція гравця змінюється на правіше 
            spriteRenderer.flipX = true; //розвертає модельку гравця, щоб він дивився у ту сторону у яку йде
        }

        if (Input.GetKey(KeyCode.A)) //якщо натискаємо на А
        {
            transform.position -= transform.right * Speed; //то позиція гравця змінюється на лівіше
            spriteRenderer.flipX = false; //розвертає модельку гравця, щоб він дивився у ту сторону у яку йде
        }
    }

    private void Update() // ----------------------Стрибок-----------------------------------------
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0); 
        }


        if (Input.GetKeyDown(KeyCode.Space)) //при натисканні на пробіл
        {
            if (isGrounded == true)
            {
                rb2d.AddForce(transform.up * JumpForce, ForceMode2D.Impulse); //надає імпульс вгору 
            }
        }

        //--------------------------Анімація-----------------------
        if (isGrounded == true) //якщо ми стоїмо на землі, то 
        {
            if (Input.GetAxis("Horizontal") != 0) //перевіряємо якщо рухаємось (координати по горизонталі не= 0 )
            {
                animator.Play("Run"); //то вмикається анімація бігу
            }
            else //інакше
            {
                animator.Play("Idle"); //вмикається анімація спокою
            }
        }

        else //інакше (тобто якщо ми не стоїмо на землі), то
        {
            animator.Play("Jump"); //вмикається анімація "стрибок"
        }

        // Оновлення таймера
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

    //----------------- Текст --------------------------------
    public void AddItem(int count)
    {
        items += count; //задаєм значеня скільки є один предмет

        itemsTextLegacy.text = $"Items collected: {items}/7"; //виводимо текст 
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Traps")) //коли ми доторкаємось до пастки
        {
            transform.position = SpawnPosition; // позиція гравця міняється на позицію спавну
        }
    }

    

}
