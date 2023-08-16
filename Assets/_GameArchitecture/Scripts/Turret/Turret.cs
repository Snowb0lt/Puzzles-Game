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

    [Header("Ray Casting")]
    [SerializeField] Transform RayOrigin;
    [SerializeField] GameObject RayEnd;

    [Header("Health Aspects")]
    [SerializeField] Health health;
    [SerializeField] float damage;

    [Header("Audio")]
    [SerializeField] private AudioSource laserAudio;


    // Start is called before the first frame update
    void Awake()
    {
        turretLine = GetComponent<LineRenderer>();
        
    }

    public void Update()
    {
        //for (int i = 0; i < points.Length; i++)
        //{
        //    turretLine.SetPosition(i, points[i].position);
        //}
        turretLine.SetPosition(0, RayOrigin.transform.position);
        CheckForPlayer();
    }

    public void CheckForPlayer()
    {
        Ray ray = new Ray(RayOrigin.transform.position, Vector3.forward);
        turretLine.SetPosition(1, RayEnd.transform.position);


        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            turretLine.SetPosition(1, hit.point);
            if (hit.collider.tag == "Player")
            {
                health.DeductHealth(damage);
                laserAudio.Play();
            }
            else
            {
                laserAudio.Stop();
                return;
            }
        }
    }
}
