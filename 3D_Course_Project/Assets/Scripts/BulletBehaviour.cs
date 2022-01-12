using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _autoDestroyTime;

    public void SetupDirection(Transform startPoint)
    {
        transform.position = startPoint.position;
        transform.rotation = startPoint.rotation;
    }

    void Start()
    {
        StartAutoDestroy();
    }

    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void StartAutoDestroy()
    {
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(_autoDestroyTime);
        DestroyBullet();
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyBullet();
    }
}
