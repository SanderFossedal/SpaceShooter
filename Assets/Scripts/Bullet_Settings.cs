using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Settings : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float destroyTime = 3;
    public static int damage = 2;
    private Boundaries bounds;
    

    private void Start()
    {
        bounds = GetComponent<Boundaries>();
    }


    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.up * Time.deltaTime * maxSpeed;
        Destroy(gameObject, destroyTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(Resources.Load("Bullet_Explosion_1") as GameObject, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        


        
    }
    
}
