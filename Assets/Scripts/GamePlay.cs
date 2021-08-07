using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    # region Singleton

    private static GamePlay _instance;

    public static GamePlay Instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject("GamePlay");
                _instance = go.AddComponent<GamePlay>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null) return;

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    public int lives = 3;
    public int bricks = 4;

    private bool _gameOver = false;
    private int _score;
    private int _lives;

    [Header("Events")] public UnityEvent onGameStart;
    public UnityEvent onGameReset;

    public UnityEvent<int> onScoreUpdate;
    public UnityEvent<int> onLivesUpdate;

    private void Start()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        _score = 0;
        _lives = lives;

        ResetBallPosition();
    }

    private void ResetBallPosition()
    {
        try
        {
            onGameReset.Invoke();

            onScoreUpdate.Invoke(_score);
            onLivesUpdate.Invoke(_lives);

            StartCoroutine(StartGame());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3f);

        try
        {
            _gameOver = false;
            onGameStart.Invoke();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeathZone()
    {
        _lives--;

        ResetBallPosition();
        onLivesUpdate.Invoke(lives);
        DetectLose();
    }

    public void BrickDestroyed()
    {
        _score++;
        onScoreUpdate.Invoke(_score);
        DetectWin();
    }

    private void DetectWin()
    {
        if (_score != bricks) return;
        SceneManager.LoadScene("Win");
        _gameOver = true;
    }

    private void DetectLose()
    {
        if (_lives > 0) return;
        SceneManager.LoadScene("Lose");
        _gameOver = true;
    }

    public int GetScore()
    {
        return _score;
    }
    
    private void Update()
    {
#if UNITY_EDITOR //debug commands
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lives = 0;
            DetectLose();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _score = bricks;
            DetectWin();
        }
#endif
    }
}