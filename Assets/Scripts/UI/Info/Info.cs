
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{  
   public float _timeRemaining = 780;
   public float _timeRemaining2 = 60;
    public bool _endGame;
    public bool _churchBreakable;
    public bool _timerOn;

   public TextMeshProUGUI _timerText;
   public TextMeshProUGUI _timerText2;
    public TextMeshProUGUI _humansText;
   public TextMeshProUGUI _woodText;
   public TextMeshProUGUI _mineralText;

    [SerializeField] private God_Choice _godManager;

    [SerializeField] private GameObject _color;
    [SerializeField] private GameObject _mother;
    [SerializeField] private GameObject _thunder;
    [SerializeField] private GameObject _timeLord;
    [SerializeField] private GameObject _trinity;
    // 0 = Trinity
    // 1 = Thunder
    // 2 = Color
    // 3 = Mother
    // 4 = Time

    private int _humans;
    private int _wood;
    private int _mineral;

    private void Start()
    {
        if(_godManager._godChoice == 0)
        {
            _trinity.SetActive(true);
        }
        if (_godManager._godChoice == 1)
        {
            _thunder.SetActive(true);
        }
        if (_godManager._godChoice == 2)
        {
            _color.SetActive(true);
        }
        if (_godManager._godChoice == 3)
        {
            _mother.SetActive(true);
        }
        if (_godManager._godChoice == 4)
        {
            _timeLord.SetActive(true);
        }
    }

    void Update()
    {

        if (_timerOn)
        {
            Timer(_timeRemaining);

            if (_timeRemaining > 0)
                _timeRemaining -= Time.deltaTime;
            else
                _endGame = true;

            //Timer 2
            Timer2(_timeRemaining2);

            if (_timeRemaining2 > 0)
                _timeRemaining2 -= Time.deltaTime;
            else
                _churchBreakable = true;
        }
    }
    void Timer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void Timer2(float currentTime)
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