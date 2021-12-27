using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            targetMotion(Vector3.back);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetMotion(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.A))
        {
            targetMotion(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            targetMotion(Vector3.left);
        }
    }

    void targetMotion (Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
