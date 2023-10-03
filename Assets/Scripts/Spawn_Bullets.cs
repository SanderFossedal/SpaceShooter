using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Bullets : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    public float spawnTime;
    public float spawnDelay;
    
    
    

    private void Start()
    {
        //InvokeRepeating("spawnObject", spawnTime, spawnDelay);
        Invoke("spawnObject", spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnDelay <= 0.2)
        {
            spawnDelay = (float)0.2;
        }

    }

    private void spawnObject()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        Invoke("spawnObject", spawnDelay);
    }
}
