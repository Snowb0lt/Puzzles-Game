using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    [Header("Turret Line")]
    [SerializeField]private LineRenderer turretLine;
    [SerializeField]private Transform[] points;

    [Header("Ray Casting")]
    [SerializeField] GameObject RayOrigin;
    [SerializeField] GameObject RayEnd;

    [Header("Health Aspects")]
    [SerializeField] Health health;
    [SerializeField] float damage;


    // Start is called before the first frame update
    void Awake()
    {
        turretLine = GetComponent<LineRenderer>();
    }

    public void LineSetup(Transform[] points)
    {
        turretLine.positionCount = points.Length;
        this.points = points;
    }

    public void Update()
    { for (int i = 0; i < points.Length; i++)
        {
            turretLine.SetPosition(i, points[i].position);
        }

    CheckForPlayer();
    }

    public void CheckForPlayer()
    {
        Ray ray = new Ray(RayOrigin.transform.position, Vector3.forward);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.tag == "Player")
            {
                health.DeductHealth(damage);
            }
            else
            {
                return;
            }
        }
    }
}
