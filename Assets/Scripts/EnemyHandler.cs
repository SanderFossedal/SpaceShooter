using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    
    //Enemy Speed
    public int speed;

    //Death Event
    public static event Action onDeath;
    
    //ScoreSystem
    //private ScoreSystemV2 scoreSystem;
    //public int scoreAmount;

    //Enemy Health
    HealthSystem healthSystem;
    [SerializeField] private int maxHealth;
    
    //private Bullet_Settings bulletSettings;

    //Enemy Death animation
    //public GameObject deathAnimation;

    //Loot Drop
   // public GameObject upgrade;
    public int dropChance;

    //Enemy spawn counter
    private Enemy_Spawn enemySpawn;
    void Start()
    {
        
        //bulletSettings = FindObjectOfType<Bullet_Settings>();
        healthSystem = new HealthSystem(maxHealth);
        //scoreSystem = GameObject.Find("GameManager").gameObject.GetComponent<ScoreSystemV2>();
        //enemySpawn = FindObjectOfType<Enemy_Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthSystem.CurrentHealth == 0)
        {
           dead();
        }

        transform.position += Vector3.down * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy (gameObject);
        }

        if(collision.gameObject.tag == "Bullet")
        {
            healthSystem.damage(Bullet_Settings.damage);
            Debug.Log(healthSystem.CurrentHealth);
        }
    }

    private void drop()
    {
        if (UnityEngine.Random.Range(1, 101) <= dropChance)
        {
            //Instantiate(upgrade, transform.position, transform.rotation);
            Instantiate(Resources.Load("Upgrade") as GameObject, transform.position, Quaternion.identity);
        }
    }

    private void dead()
    {
        Destroy(gameObject);
        //Instantiate(deathAnimation, transform.position, transform.rotation);
        Instantiate(Resources.Load("Enemy_Explosion") as GameObject, transform.position, Quaternion.identity);
        //enemySpawn.addCount();
        drop();
        onDeath?.Invoke();
    }
}
