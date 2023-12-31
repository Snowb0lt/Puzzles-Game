using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkipCutscene : MonoBehaviour
{
    public UnityEvent StartLevel;
    [SerializeField] private bool isCutscenePlaying;


    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartLevel?.Invoke();
        }
    }

    public void NonSkipable()
    {
        Destroy(this);
    }
}
