using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyLiftButton : MonoBehaviour
{
    [SerializeField] private Lift lift;
    [SerializeField] private GameObject targetLift;

    public void EmerLift()
    {
        lift.ActivateLift();
    }

    
}
