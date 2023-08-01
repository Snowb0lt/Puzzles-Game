using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMaker : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private Turret turretline;

    private void Start()
    {
        turretline.LineSetup(points);
    }
}
