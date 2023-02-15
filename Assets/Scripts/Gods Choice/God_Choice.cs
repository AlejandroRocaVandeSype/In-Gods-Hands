using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God_Choice : MonoBehaviour
{
    public int _godChoice;

    public void TrinityChosen()
    {
        _godChoice = 0;
    }
    public void ThunderChosen()
    {
        _godChoice = 1;
    }
    public void ColorChosen()
    {
        _godChoice = 2;
    }
    public void MotherChosen()
    {
        _godChoice = 3;
    }
    public void TimeChosen()
    {
        _godChoice = 4;
    }
}