using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    #region Exposed
    private NavMeshAgent agent;
    #endregion

    #region Unity LifeCycle
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    #endregion

    #region Methods

    public void MoveToPoint (Vector3 point)
    {
        agent.SetDestination(point);
    }

    #endregion

    #region Private & Protected

    #endregion
}
