using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public delegate void GameStateChangeHandler(GameState newState);
    public event GameStateChangeHandler OnGameStateChanged;
    public GameObject gameOverPanel;
    public enum GameState
    {
        MainMenu,
        Playing,
        GameOver
    }

    [HideInInspector]
    public GameState currentState;

    
    private int stars = 0;

    public int Stars
    {
        get { return stars; }
        set
        {
            stars = value;
            OnStarsChanged?.Invoke(stars);
        }
    }

    public delegate void StarsChangeHandler(int newStarCount);
    public event StarsChangeHandler OnStarsChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
       
        ChangeState(GameState.Playing);
    }

    public void StartGame()
    {
        Stars = 0;
        gameOverPanel.SetActive(false);
        ChangeState(GameState.Playing);

    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        ChangeState(GameState.GameOver);
    }

    

    public void GameRestart()
    {
        SceneManager.LoadScene(0);
    }
    private void ChangeState(GameState newState)
    {
        currentState = newState;
        OnGameStateChanged?.Invoke(currentState);
    }
}