using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    //Event to loosely couple targets to controller
    [SerializeField] private UnityEvent onTargetDestroyed;
    private void OnCollisionEnter(Collision shot)
    {
        if (shot.gameObject.CompareTag("Bullet"))
        {
            onTargetDestroyed.Invoke();
            Destroy(gameObject);
        }
    }

}
