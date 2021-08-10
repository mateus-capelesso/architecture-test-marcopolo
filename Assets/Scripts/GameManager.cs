using System;
using Gameplay;
using States;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    # region Singleton

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
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

    private StateMachine _stateMachine;

    public GamePlay brickGameplay;
    public UnityEvent onLevelOver;
    public Action<int> onTotalPointsAvailable;

    private void Start()
    {
        _stateMachine = new StateMachine();
        _stateMachine.CallMainMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _stateMachine.CallStateEnd();
    }

    public void StartBrickGameplay()
    {
        brickGameplay.CallGameplay();
    }

    public void GamePlayOver(bool win, int points)
    {
        _stateMachine.SetGameOverState(win);
        brickGameplay.CloseGameplay();
        onLevelOver.Invoke();
        onTotalPointsAvailable.Invoke(points);
    }
}