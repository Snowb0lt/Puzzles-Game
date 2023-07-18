using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTarget : MonoBehaviour /*,IDestroyable*/
{
    [SerializeField]private TargetDoorControls targetLights;
    private void OnCollisionEnter(Collision shot)
    {
        if (shot.gameObject.CompareTag("Rocket"))
        {
            targetLights.numberOfTargets--;
            Destroy(gameObject);
        }
    }
}
