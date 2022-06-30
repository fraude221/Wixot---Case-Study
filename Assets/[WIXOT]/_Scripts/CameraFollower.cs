using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] [Range(0, 0.3f)] private float _smoothTime;

    [SerializeField] private bool _isXPositionFixed;

    private Vector3 _offset;
    private Vector3 _velocity = Vector3.zero;
    private float _firstPositionX;
    private bool _isFollowing = false;

    private void Awake() => GameManager.OnGameStateChanged += SetIsFollowing;
    private void OnDestroy() => GameManager.OnGameStateChanged -= SetIsFollowing;

    private void Start()
    {
        _offset = transform.position - _target.position;
        _firstPositionX = transform.position.x;
    }
    private void LateUpdate()
    {
        if (_isFollowing)
        {
            Vector3 targetPosition = _target.position + _offset;

            if (_isXPositionFixed)
                targetPosition.x = _firstPositionX;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
        }
    }
    public void SetIsFollowing(GameState state) => _isFollowing = state == GameState.inGame;
}
