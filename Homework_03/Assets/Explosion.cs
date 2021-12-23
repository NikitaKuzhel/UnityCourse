using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _force = 120f;
    [SerializeField] private float _radius = 150f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Bang()
    {

        var colliders = Physics.SphereCastAll(_target.position, _radius, _target.up);

        foreach (var raycastHit in colliders)
        {
            if (raycastHit.collider.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_force, _target.position, _radius);
            }
        }
    }
}
