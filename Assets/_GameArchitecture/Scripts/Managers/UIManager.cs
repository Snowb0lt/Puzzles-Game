using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static GameManager;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    [Header("UI Elements")]
    public TMP_Text _txtHealth;
    public GameObject _gameOverText;

    [Header("Timer")]
    private float timerSeconds = 0;
    public TMP_Text _timerText;
    public GameObject _timerObj;
    private int timerMinutes;
    // Start is called before the first frame update
    void Start()
    {
        _gameOverText.SetActive(false);
    }

    private void OnEnable()
    {
        _playerHealth.OnHealthUpdated += OnHealthUpdate;
        _playerHealth.OnDeath += OnDeath;
    }

    private void OnDestroy()
    {
        _playerHealth.OnHealthUpdated -= OnHealthUpdate;
    }

    void OnHealthUpdate(float health)
    {
        _txtHealth.text = "Health: " + Mathf.Floor(health).ToString();
    }

    void OnDeath()
    {
        _gameOverText.SetActive(true);
        //GameManager._instance.ChangeState(GameState.GameOver, LevelManager._currentLevel);
    }

    public void StartSpeedRun()
    {
        timerSeconds = 00;
        _timerObj.SetActive(true);       
    }

    private void Update()
    {
        timerSeconds += 1 * Time.deltaTime;
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        _timerText.text = "TIME: " + timerMinutes + ":" + (int)timerSeconds;
        if (timerSeconds >= 60)
        {
            timerSeconds = 00;
            timerMinutes++;
        }
    }
}
