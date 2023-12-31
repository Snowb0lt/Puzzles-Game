using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _pickableLayer;
    public PushButton button;
    public TextMeshProUGUI buttonText;

    public UnityEvent onCubePlaced;
    public UnityEvent onCubeRemoved;
    private void OnCollisionEnter(Collision collision)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _checkRadius, _pickableLayer);
        Debug.Log(hitColliders.Length);

        foreach (var collider in hitColliders)
        {
            Debug.Log("Collided with" + collider.gameObject.name);

            if (collider.CompareTag("PickCube"))
            {   
                onCubePlaced?.Invoke();
                buttonText.text = "UNLOCKED";
                buttonText.color = Color.green;
                break;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PickCube"))
        {
            onCubeRemoved?.Invoke();
            buttonText.text = "LOCKED";
            buttonText.color = Color.yellow;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, _checkRadius);
    }
    
}
