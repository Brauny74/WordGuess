using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    public GameObject LoseWindow;
    public GameObject NoWordsWindow;
    public GameObject LoadingOverlay;
    public WordToGuess GuessWord;
    public LettersPool Letters;
    public WordsPool Words;

    public UIController UIC;

    public bool GameActive;

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            UIC.UpdateScore(_score);
        }
    }
    private int _score;

    public int Tries
    {
        get => _tries;
        set
        {
            _tries = value;
            UIC.UpdateTries(_tries);
            if (_tries < 0)
                Lose();
        }
    }
    private int _tries;   

    [Header("Settings")]
    public int StartScore;
    public int StartTries;
    public string AllPossibleLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public int WordMinLength = 3;
    public int WordMaxLength = 20;
    public int PoolSize = 30;

    public void Start()
    {
        GameActive = false;        
        LoadingOverlay.SetActive(true);
        LoseWindow.SetActive(false);
        NoWordsWindow.SetActive(false);
        Score = StartScore;
        Tries = StartTries;
        Words.Init();
    }

    public void Init()
    {
        GameActive = true;        
        LoadingOverlay.SetActive(false);
        GuessWord.Init(Words.GetRandomWord());
        Debug.Log(GuessWord.Word);
        Letters.Init(GuessWord.Word);
    }

    public void CheckWin()
    {
        if (GuessWord.Word == "")
            Win();
    }

    public void Win()
    {
        Score += Tries;
        Tries = StartTries;
        GameActive = false;
        if (Words.Pool.Count <= 0)
        {
            NoWordsWindow.SetActive(true);
        }
        else
        {
            Init();
        }
    }

    public void Lose()
    {
        GameActive = false;
        LoseWindow.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}