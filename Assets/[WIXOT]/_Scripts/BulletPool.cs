using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private int _amountToPool;
    [SerializeField] private GameObject _bulletPrefab;

    private List<GameObject> _bulletList;
    private int _counter = 0;

    void Start()
    {
        _bulletList = new List<GameObject>();

        GameObject newBullet;
        for (int i = 0; i < _amountToPool; i++)
        {
            newBullet = Instantiate(_bulletPrefab, transform);
            newBullet.transform.position = Vector3.zero;
            newBullet.SetActive(false);
            _bulletList.Add(newBullet);
        }
    }

    public GameObject GetBullet()
    {
        if (_bulletList.Count == 0)
            return null;

        _counter++;
        if (_counter >= _bulletList.Count)
            _counter = 0;

        _bulletList[_counter].SetActive(false);

        return _bulletList[_counter];
    }
    public void ClearBullets()
    {
        foreach (var bullet in _bulletList)
        {
            bullet.transform.position = Vector3.zero;
            bullet.SetActive(false);
        }
    }
}
