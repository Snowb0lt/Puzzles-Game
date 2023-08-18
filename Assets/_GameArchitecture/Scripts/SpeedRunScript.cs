using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
public class SpeedRunScript : MonoBehaviour
{
    public static SpeedRunScript _instance {  get; private set; }


    

    [Header("Timer")]
    private float timerSeconds = 0;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameObject timeTextObj;
    private int timerMinutes;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                _instance = this;
            }
    }

    public static SpeedRunScript GetInstance()
    {
        return _instance;
    }

    private void Update()
    {
        timerSeconds += 1 * Time.deltaTime;
        UpdateTimer();
    }

    public void StartSpeedRun()
    {
        timerSeconds = 00;
        timeTextObj.SetActive(true);
    }



    private void UpdateTimer()
    {
        timeText.text = "TIME: " + timerMinutes + ":" + (int)timerSeconds;
        if (timerSeconds >= 60)
        {
            timerSeconds = 00;
            timerMinutes++;
        }
    }
    public void SpeedRunUpdate()
    {
        if (GameManager._instance.speedRunStarted == true)
        {
            timeTextObj.SetActive(true);
            timeText.text = "FINAL TIME: " + timerMinutes + ":" + (int)timerSeconds;
        }
    }
}
