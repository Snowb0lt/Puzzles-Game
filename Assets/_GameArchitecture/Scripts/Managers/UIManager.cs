using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static GameManager;
using static System.Net.WebRequestMethods;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance { get; private set; }

    [SerializeField] private Health _playerHealth;
    [SerializeField] private GameManager _gameManager;

    [Header("PlayerInput")]
    public GameObject playerInput;

    [Header("UI Elements")]
    public TMP_Text _txtHealth;
    public GameObject _gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        _gameOverText.SetActive(false);

    }

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

    public static UIManager GetInstance()
    {
        return _instance;
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


    [Header("Fade To Black")]
    [SerializeField] GameObject FTB;
    [SerializeField] private int fadeDuration = 1;
    [SerializeField] private Image blackOutScreen;
    public void FadeToBlack()
    {
        FTB.SetActive(true);
        StartCoroutine(ColorFade(Color.clear, Color.black, fadeDuration));
        Invoke("DisplayEndMenu",fadeDuration);
        Cursor.visible = true;
        playerInput.SetActive(false);

    }

    [Header("Ending UI Elements")]
    [SerializeField] private GameObject endingText;
    [SerializeField] private Button menuButton;
    private void DisplayEndMenu()
    {
        endingText.SetActive(true);
        SpeedRunScript._instance.SpeedRunUpdate();
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


