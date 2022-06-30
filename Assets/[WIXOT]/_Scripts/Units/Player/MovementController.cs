using UnityEngine;
using UnityEngine.EventSystems;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Animator _playerAnim;
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _speed;

    private static int _runHash = Animator.StringToHash("RunCondition");
    private static int _stopHash = Animator.StringToHash("StopCondition");

    private bool _isControllable;
    private bool _isRunning;

    private void Awake() => GameManager.OnGameStateChanged += SetControllable;
    private void OnDestroy() => GameManager.OnGameStateChanged -= SetControllable;
    void Update()
    {
        if (_isControllable)
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Move();

            if (!_isRunning)
            {
                _isRunning = true;
                StartRunAnimation();
            }
        }
        else
        {
            if (_isRunning)
            {
                _isRunning = false;
                StartIdleAnimation();
            }
        }
    }

    private void Move()
    {
        transform.position += Vector3.forward * Time.deltaTime * _speed;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + (Input.GetAxis("Mouse X") * _sensitivity * Time.fixedDeltaTime), GlobalData.LeftBorder, GlobalData.RightBorder),
            transform.position.y,
            transform.position.z
            );
    }

    public void SpeedUp(float speedFactor)
    {
        _speed *= speedFactor;
    }
    public void SpeedDown(float speedFactor)
    {
        _speed /= speedFactor;
    }

    private void StartRunAnimation()
    {
        _playerAnim.SetBool(_runHash, true);
        _playerAnim.SetBool(_stopHash, false);
    }

    private void StartIdleAnimation()
    {
        _playerAnim.SetBool(_runHash, false);
        _playerAnim.SetBool(_stopHash, true);
    }
    private void SetControllable(GameState state) => _isControllable = state == GameState.inGame;
}
