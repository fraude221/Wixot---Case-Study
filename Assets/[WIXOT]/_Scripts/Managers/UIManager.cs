using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _panelStart;
    [SerializeField] private GameObject _panelInGame;
    private void Awake() => GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    private void OnDestroy() => GameManager.OnGameStateChanged -= GameManager_OnGameStateChanged;

    private void GameManager_OnGameStateChanged(GameState state)
    {
        ChangePanel(state);
    }

    private void ChangePanel(GameState state)
    {
        _panelStart.SetActive(state == GameState.start);
        _panelInGame.SetActive(state == GameState.inGame);
    }
}
