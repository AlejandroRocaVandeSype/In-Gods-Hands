using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _button1;
    [SerializeField] private GameObject _button2;
    [SerializeField] private GameObject _credits;
    [SerializeField] private GameObject _Controls;

    public void Credits()
    {
        _button1.SetActive(false);
        _button2.SetActive(false);
        _credits.SetActive(true);

    }
    public void OutCredits()
    {
        _button1.SetActive(true);
        _button2.SetActive(true);
        _credits.SetActive(false);
    }
    public void PlayARound()
    {
        _Controls.SetActive(true);
        _button1.SetActive(false);
        _button2.SetActive(false);
    }
}