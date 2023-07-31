using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Turret : MonoBehaviour
{
    [Header("Turret Line")]
    [SerializeField]private LineRenderer turretLine;
    [SerializeField]private Transform[] points;

    [Header("Ray Casting")]
    [SerializeField] Vector3 RayOrigin;


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
        Ray ray = new Ray(points[0].position, points[1].position);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit.collider.gameObject.name + " was Hit");
        }
    }
}
