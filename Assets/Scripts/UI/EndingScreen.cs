using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScreen : MonoBehaviour
{
    [SerializeField] GameObject _Player1Winner;
    [SerializeField] GameObject _Player2Winner;
    [SerializeField] GameObject _Player1Loose;
    [SerializeField] GameObject _Player2Loose;


     // Start is called before the first frame update
    void Start()
    {
        GameManager.GetInstance.IsGameOver = false;
        if(GameManager.GetInstance._PlayerWinner == GameManager.PlayerNumber.Player1)
        {
            _Player1Winner.SetActive(true);
            _Player2Loose.SetActive(true); 
        }
        else
        {
            _Player2Winner.SetActive(true);
            _Player1Loose.SetActive(true);
        }
    }

    
}
