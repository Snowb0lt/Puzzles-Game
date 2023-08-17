using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    
    [SerializeField] UIManager uIManager;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uIManager.FadeToBlack();
        }
    }

}
