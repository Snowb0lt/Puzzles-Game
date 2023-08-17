using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInstance : MonoBehaviour
{
    [SerializeField] private GameObject commandInfoTxt;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            commandInfoTxt.SetActive (true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            commandInfoTxt.SetActive(false);
        }
    }
}
