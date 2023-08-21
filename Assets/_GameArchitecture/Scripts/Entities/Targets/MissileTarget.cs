using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissileTarget : MonoBehaviour /*,IDestroyable*/
{
    //Event to loosely couple targets to controller
    [SerializeField] private UnityEvent onTargetDestroyed;
    private void OnCollisionEnter(Collision shot)
    {
        if (shot.gameObject.CompareTag("Rocket"))
        {
            onTargetDestroyed.Invoke();
            Destroy(gameObject);
        }
    }
}
