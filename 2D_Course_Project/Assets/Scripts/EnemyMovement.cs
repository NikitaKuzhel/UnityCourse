using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float look;

    [SerializeField] private float duration;

    private void Start()
    {
        StartAnimation();
    }

    // Анимация патрулирования
    private void StartAnimation()
    {
        transform
            .DOPath(new Vector3[] { startPoint.position, endPoint.position }, duration, (PathType)PathMode.Sidescroller2D)
            // .SetLookAt(look)
            .SetEase(Ease.Linear) // делает скорость постоянной
            .SetLoops(-1, LoopType.Restart);
    }
}
