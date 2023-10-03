using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float maxSpeed = 5;
    [SerializeField] private float destroyTime = 3;

    

    // Update is called once per frame
    void Update()
    {
        
        transform.position += Vector3.up * Time.deltaTime * maxSpeed;
        Destroy(gameObject, destroyTime);
        
    }
}
