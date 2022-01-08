using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            targetMotion(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetMotion(Vector3.right);
        }

        if (Input.GetKey(KeyCode.A))
        {
            targetMotion(Vector3.back);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            targetMotion(Vector3.forward);
        }
    }

    void targetMotion(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
