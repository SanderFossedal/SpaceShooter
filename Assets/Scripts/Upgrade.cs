using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    private GameObject obj;
    [SerializeField] private float reducedSpawnTime;
    [SerializeField] private int destroyTime;
    [SerializeField] private int maxSpeed;

    public static event Action onUpgradeTaken;
    void Awake()
    {
        obj = GameObject.Find("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * maxSpeed;
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            obj.GetComponent<Spawn_Bullets>().spawnDelay -= reducedSpawnTime;
            Destroy(gameObject);
            onUpgradeTaken?.Invoke();
        }
    }
}
