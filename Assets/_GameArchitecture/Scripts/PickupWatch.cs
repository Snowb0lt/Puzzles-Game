using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWatch : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 1;
    [SerializeField] UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateObject();
    }

    private void RotateObject()
    {
        Vector3 spin = new Vector3(0, spinSpeed, 0);
        gameObject.transform.Rotate(spin, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager._instance.speedRunStarted = true;
            uIManager.StartSpeedRun();
            Debug.Log("Speedrun Start");
            Destroy(gameObject);
        }
    }
}
