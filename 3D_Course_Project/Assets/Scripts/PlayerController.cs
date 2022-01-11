using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Animator animator;

    void FixedUpdate()
    {
        // Движение персонажа
        var movement = Input.GetAxis("Vertical");
        transform.position += new Vector3(-movement, 0, 0) * Time.deltaTime * speed;

        // Анимация бега
        animator.SetFloat("Speed", Mathf.Abs(movement));
    }
}