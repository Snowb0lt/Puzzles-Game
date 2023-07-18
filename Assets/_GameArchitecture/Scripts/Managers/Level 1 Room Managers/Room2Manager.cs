using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room2Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;
    [SerializeField] private UnityEvent UnlockDoor;
    [SerializeField] private bool areTargetsDestroyed;
    [SerializeField] private int numberOfTargets;
    [SerializeField]private PushButton doorSwitch;
    [SerializeField] private TargetDoorControls targetLights;
    // Start is called before the first frame update

    private void Update()
    {
        
    }

    private void DoorUnlock()
    {

    }

    private void TargetDestroyed()
    {

    }
}
