using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    //[SerializeField] private GameObject obj;

    private void Start()
    {
        //obj = GameObject.Find("SpawnPoint");
    }

    private void Update()
    {
       
    }

    public void setHealth(int health)
    {
        slider.value = health;
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
