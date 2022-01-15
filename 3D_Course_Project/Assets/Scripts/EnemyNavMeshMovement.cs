using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Camera _cam;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _agent.SetDestination(hit.point);
            }
        }
    }
}
