using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("SHOOTING")]
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Transform _firePoint;

    [Header("SKILLS")]
    [SerializeField] private SkillDiagonalShooting _skillDiagonalShooting;
    [SerializeField] private SkillDoubleShooting _skillDoubleShooting;
    [SerializeField] private SkillFireRate _skillFireRate;

    [Header("SETTINGS")]
    [SerializeField] private float fireInterval = 2f;
    [SerializeField] private float fasterFireInterval = 1f;
    [SerializeField] private float doubleShootingInterval = 0.1f;

    private IEnumerator _coroutineWaitAndShoot;
    private void Awake()
    {
        _coroutineWaitAndShoot = WaitAndShoot();
        GameManager.OnGameStateChanged += SetShooting;
    }
    private void OnDestroy() => GameManager.OnGameStateChanged -= SetShooting;

    private void SetShooting(GameState state)
    {
        if (state == GameState.inGame)
        {
            StartCoroutine(_coroutineWaitAndShoot);
        }
        else
        {
            StopCoroutine(_coroutineWaitAndShoot);
        }
    }
    IEnumerator WaitAndShoot()
    {
        while(true)
        {
            if (_skillDoubleShooting.isActive)
            {
                Shoot();
                yield return new WaitForSeconds(doubleShootingInterval);
            }

            Shoot();

            yield return new WaitForSeconds(GetFireInterval());
        }
    }

    
    private void Shoot()
    {
        Vector3 directionForward = _firePoint.transform.forward;
        CreateBullet(directionForward);

        if (_skillDiagonalShooting.isActive)
        {
            ShootDiagonally();
        }
    }
    private void ShootDiagonally()
    {
        Vector3 directionRightDiagonal = (_firePoint.transform.forward + _firePoint.transform.right).normalized;
        Vector3 directionLeftDiagonal = (_firePoint.transform.forward - _firePoint.transform.right).normalized;

        CreateBullet(directionRightDiagonal);
        CreateBullet(directionLeftDiagonal);
    }
    private void CreateBullet(Vector3 direction)
    {
        GameObject bullet = _bulletPool.GetBullet();
        if (bullet)
        {
            bullet.transform.position = _firePoint.transform.position;
            bullet.transform.forward = direction;
            bullet.SetActive(true);
        }
    }

    private float GetFireInterval()
    {
        if (_skillFireRate.isActive)
        {
            return fasterFireInterval;
        }

        return fireInterval;
    }
}