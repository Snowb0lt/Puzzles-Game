using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static GameManager;
using static System.Net.WebRequestMethods;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private GameManager _gameManager;

    [Header("PlayerInput")]
    public GameObject playerInput;

    [Header("UI Elements")]
    public TMP_Text _txtHealth;
    public GameObject _gameOverText;

    [Header("Timer")]
    private float timerSeconds = 0;
    public TMP_Text _timerText;
    public GameObject _timerObj;
    private int timerMinutes;

    [Header("Fade To Black")]
    [SerializeField] GameObject FTB;
    [SerializeField] private int fadeDuration = 1;
    [SerializeField] private Image blackOutScreen;

    [Header("Ending UI Elements")]
    [SerializeField] private GameObject endingText;
    [SerializeField] private GameObject timeTextObj;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private Button menuButton;
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
        _gameManager.FreezeGame();
        Cursor.visible = true;
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
    public void FadeToBlack()
    {
        FTB.SetActive(true);
        StartCoroutine(ColorFade(Color.clear, Color.black, fadeDuration));
        Invoke("DisplayEndMenu",fadeDuration);

    }

    private void DisplayEndMenu()
    {
        endingText.SetActive(true);
        if (GameManager._instance.speedRunStarted == true)
        {
            timeTextObj.SetActive(true);
            timeText.text = "FINAL TIME: " + timerMinutes + ":" + (int)timerSeconds;
        }
        menuButton.gameObject.SetActive(true);
    }

    IEnumerator ColorFade(Color start, Color end, float duration)
    {
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;

            blackOutScreen.color = Color.Lerp(start, end, normalizedTime);
            yield return null;
        }
    }
}
