using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{
    //Player Movment
    float horizontal, vertical;
    Rigidbody2D rb2d;
    public float speed = 10;

    //Player Health
    HealthSystem healthSystem;
    [SerializeField] private int damgeTaken;

    //Player HealthBar
    [SerializeField] private HealthBar healthBar;

    //Player shield
    private GameObject shieldSprite;

    //Moving forward on Boss death
    MoveForward moveForward;

    //Player Death event
    public static event Action onDeath;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        moveForward = GetComponent<MoveForward>();
        moveForward.enabled = false;

        healthSystem = new HealthSystem(100);

        healthBar.setMaxHealth(healthSystem.MaxHealth);

        shieldSprite = GameObject.Find("Shield_Sprite");
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

       if(Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Player1-0").GetComponent<SpriteRenderer>().sprite;
        }
       else if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Player1-2").GetComponent<SpriteRenderer>().sprite;
        }
        if(!Input.anyKey)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Player1-1 (1)").GetComponent<SpriteRenderer>().sprite;
        }
        
        if(healthSystem.CurrentHealth <= 0)
        {
            death();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("Menu");
        }

    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontal * speed, vertical * speed);
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            healthSystem.damage(damgeTaken);
            healthBar.setHealth(healthSystem.CurrentHealth);
        }

        if(collision.gameObject.tag == "Shield")
        {
            shieldSprite.GetComponent<Shield>().turnOn();
            Destroy(collision.gameObject);
        }
    }

    private void death()
    {
        Destroy(gameObject);
        Instantiate(Resources.Load("Explosion") as GameObject, transform.position, Quaternion.identity);
        onDeath?.Invoke();
    }

    private void OnEnable()
    {
        BossHandler.onDeath += turnOnScript;
    }

    private void OnDisable()
    {
        BossHandler.onDeath -= turnOnScript;
    }

    private void turnOnScript()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        moveForward.enabled = true;
    }

}
