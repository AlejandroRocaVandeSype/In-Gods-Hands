
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{  
   public float _timeRemaining = 780;
   public bool _endGame;
   public bool _timerOn;

   public TextMeshProUGUI _timerText;
   public TextMeshProUGUI _humansText;
   public TextMeshProUGUI _woodText;
   public TextMeshProUGUI _mineralText;

    private int _humans;
    private int _wood;
    private int _mineral;

    void Update()
    {

        if (_timerOn)
        {
            Timer(_timeRemaining);

            if (_timeRemaining > 0)
                _timeRemaining -= Time.deltaTime;
            else
                _endGame = true;
        }
    }
    void Timer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void WoodCounter(int cuantity)
    {        
        _wood += cuantity;
        _woodText.SetText(_wood.ToString());
    }
    public void MineralCounter(int cuantity)
    {
        _mineral += cuantity;
        _mineralText.SetText(_mineral.ToString());
    }
    public void HumanCounter(int cuantity)
    {
        _humans += cuantity;
        _humansText.SetText(_humans.ToString());
    }
}