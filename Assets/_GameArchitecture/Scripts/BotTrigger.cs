using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotTrigger : MonoBehaviour
{
    Animator botAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            botAnim.SetBool("Open_Anim", true);
        }
    }
}
