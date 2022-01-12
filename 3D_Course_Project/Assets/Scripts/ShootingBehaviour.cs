using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    [SerializeField] private BulletBehaviour _bulletPrefab;

    [SerializeField] private Transform _startPoint;

    [SerializeField] private Transform _parentForBullet;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab, _parentForBullet);
        bullet.SetupDirection(_startPoint);
    }
}
