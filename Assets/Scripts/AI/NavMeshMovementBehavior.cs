using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


[RequireComponent(typeof(NavMeshAgent))]  // Tool that allows to automatically add the component that you need 
public class NavMeshMovementBehavior : MovementBehavior
{
    // Include the namespace UnityEngine.AI
    private NavMeshAgent _NavMeshAgent;  // It will handle the movement for us

    private Vector3 _PreviousTargetPosition = Vector3.zero;


    protected override void Awake()
    {
        base.Awake();

        _NavMeshAgent = GetComponent<NavMeshAgent>();
        _NavMeshAgent.speed = _MovementSpeed;

        _PreviousTargetPosition = transform.position;

    }

    const float MOVEMENT_EPSILON = .25f;
    protected override void HandleMovement()
    {
        // We dont call the base one because we want a different movement behavior
        if (_Target == null)
        {
            // There is no target to move to
            _NavMeshAgent.isStopped = true;
            return;
        }

        // Should the target move we should recalculate our path
        if ((_Target.transform.position - _PreviousTargetPosition).sqrMagnitude > MOVEMENT_EPSILON)
        {
            // We only want to calculate the path it the target actually moved cus is an expensive operation
            _NavMeshAgent.SetDestination(_Target.transform.position);
            _NavMeshAgent.isStopped = false;
            _PreviousTargetPosition = _Target.transform.position;

        }
    }

    public bool isStopped()
    {
        return _NavMeshAgent.isStopped;
    }

    public void StopMovement()
    {
        _NavMeshAgent.isStopped = true;
        _Target = null;
    }

}
