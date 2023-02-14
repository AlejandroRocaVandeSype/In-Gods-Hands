using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDeck : MonoBehaviour
{
    public GameObject Deck;
    private bool _isActive = true;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            _isActive = !_isActive;
            Deck.SetActive(_isActive);

        }
    }
}
