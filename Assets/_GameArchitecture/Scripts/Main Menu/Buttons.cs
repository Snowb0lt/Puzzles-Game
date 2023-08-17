using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject creditScreen;
    [SerializeField] private GameObject TitleText;

    //[Header("Buttons")
    //    ]
    //[SerializeField] private GameObject StartButton;
    //[SerializeField] private GameObject creditButton;
    //[SerializeField] private GameObject quitButton;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetStage()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
