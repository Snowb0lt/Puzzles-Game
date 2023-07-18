using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    [SerializeField]private TargetDoorControls targetLights;
    private void OnCollisionEnter(Collision shot)
    {
        if (shot.gameObject.CompareTag("Bullet"))
        {
            targetLights.numberOfTargets--;
            Destroy(gameObject);
        }
    }

}
