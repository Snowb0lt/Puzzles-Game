using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EndingScript : MonoBehaviour
{
    
    UIManager uIManager;
    GameManager gameManager;

    [SerializeField] private UnityEvent GameEnd;
    [SerializeField] private UnityEvent VictoryCutscene;

    [SerializeField] private int cutsceneDuration;

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
            Invoke("EndingCutscene", cutsceneDuration);
            GameEnd.Invoke();
            VictoryCutscene.Invoke();

        }
    }

    void EndingCutscene()
    {
        gameManager.FreezeGame();
        Cursor.visible = true;
    }
}
