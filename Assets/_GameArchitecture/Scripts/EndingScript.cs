using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    
    UIManager uIManager;
    GameManager gameManager;

    private void Awake()
    {
        //Singleton setup
        uIManager = UIManager.GetInstance();
        gameManager = GameManager.GetInstance();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uIManager.FadeToBlack();
            Invoke("FreezeTheGame", 3);
            
        }
    }

    void FreezeTheGame()
    {
        gameManager.FreezeGame();
        Cursor.visible = true;
    }
}
