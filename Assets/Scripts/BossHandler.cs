using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandler : MonoBehaviour
{

    //Boss Health
    public HealthSystem healthSystem;
    [SerializeField] private int maxHealth;

    //Getting player bullet damage
    //private Bullet_Settings bulletSettings;

    //Boss Death Event
    public static event Action onDeath;

    //public static bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HealthSystem(maxHealth);
        //bulletSettings = FindObjectOfType<Bullet_Settings>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSystem.CurrentHealth <= 0)
        {
            death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            healthSystem.damage(Bullet_Settings.damage);
        }
    }

    private void death()
    {
        Destroy(gameObject);
        Instantiate(Resources.Load("Explosion") as GameObject, transform.position, Quaternion.identity);
        //isDead = true;
        onDeath?.Invoke();
    }

}
