using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector] public GameState state;
    public static event Action<GameState> OnGameStateChanged;

    void Start() => ChangeGameState(GameState.start);

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && state == GameState.start)
        {
            ChangeGameState(GameState.inGame);
        }
    }

    public void ChangeGameState(GameState newState)
    {
        state = newState;

        OnGameStateChanged?.Invoke(newState);
    }
}

public enum GameState
{
    start,
    inGame,
    endGame
}