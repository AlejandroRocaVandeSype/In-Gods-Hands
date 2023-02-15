using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BASE CLASS for characters
public class BasicCharacter : MonoBehaviour
{
    protected MovementBehavior _MovementBehavior;

    protected virtual void Awake()
    {
        // All characters will have a Movement behavior
        _MovementBehavior = GetComponent<MovementBehavior>();
    }

}