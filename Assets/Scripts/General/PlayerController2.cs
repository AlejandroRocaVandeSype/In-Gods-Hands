using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public Vector3 newPosition;
    public float _MovementSpeed;
    public float _MovementTime;

    private Vector2 movementInput;

    private void Awake()
    {

    }

    private void Start()
    {
        newPosition = transform.position;
    }

    private void Update()
    {
        HandleMovement();

        // transform.Translate(new Vector3(movementInput.x, 0, 0) * _MovementSpeed * Time.deltaTime);

    }


    //public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();


    private void HandleMovement()
    {

        newPosition += (new Vector3(Input.GetAxis("Horizontal2"), 0.0f, 0.0f) * _MovementSpeed);


        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * _MovementTime);
    }
}
