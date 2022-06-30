using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletProperties _properties;

    private float _speed;
    private void OnEnable()
    {
        _speed = _properties.speed;
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * _speed;
    }
}
