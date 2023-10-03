using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreSystemV2 : MonoBehaviour
{

    [SerializeField] private Text gameOverText;
    private GameObject obj;
    //[SerializeField] private GameObject bossPrefab;
    void Start()
    {
        gameOverText.text = "";
        obj = GameObject.Find("Player1-1");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (obj == null)
        {
            gameOverText.text = "Game Over!";
        }

    }

    

    IEnumerator waiter()
    {
        //Wait for 1 seconds
        yield return new WaitForSeconds(1);

        gameOverText.text = "Stage Complete!";
    }
}
