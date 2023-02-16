using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class God_Choice : MonoBehaviour
{
    public int _godChoice; // 0 = Trinity
                           // 1 = Thunder
                           // 2 = Color
                           // 3 = Mother
                           // 4 = Time
    public GameObject _Controls;

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

   public void NextScreen()
    {
        _Controls.SetActive(true);
        this.gameObject.SetActive(false);
    }

}