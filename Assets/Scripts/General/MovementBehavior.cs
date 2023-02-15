using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// MOVEMENT IMPLEMENTATION
public class MovementBehavior : MonoBehaviour
{
    [SerializeField] protected float _MovementSpeed = 1.0f;

    protected Rigidbody _RigidBody;

    protected Vector3 _DesiredMovementDirection = Vector3.zero;

    // This is a property. Is the same of making two functions in one. 
    // The getDesiredMovement and SetDesiredMovement
    public Vector3 DesiredMovementDirection
    {
        get { return _DesiredMovementDirection; }
        set { _DesiredMovementDirection = value; }
    }

    protected Vector3 _DesiredLookAtPoint = Vector3.zero;
    public Vector3 DesiredLookatPoint
    {
        get { return _DesiredLookAtPoint; }
        set { _DesiredLookAtPoint = value; }
    }

    protected GameObject _Target;
    public GameObject Target
    {
        get { return _Target; }
        set { _Target = value; }
    }

    protected virtual void Awake()
    {
        _RigidBody = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        HandleRotation();
    }
    protected virtual void FixedUpdate()
    {
        // Handling physics
        HandleMovement();
    }

    protected virtual void HandleMovement()
    {
        Vector3 movement = _DesiredMovementDirection.normalized;
        movement *= _MovementSpeed;

        _RigidBody.velocity = movement;
    }

    protected virtual void HandleRotation()
    {
        transform.LookAt(_DesiredLookAtPoint, Vector3.up);
    }
}
