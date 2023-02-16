using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    
    [SerializeField] private GameManager.ContrusctionType _Type;

    [SerializeField] private GameObject _Player1TemplateHuman;
    [SerializeField] private GameObject _Player2TemplateHuman;
    [SerializeField] private Transform _HumanPosition;

    private World _WorlManager;

    public bool isPlayer1 = true;

    public float _CurrentTimeSpawn;
    public float _MaxTimeSpaw = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _WorlManager = GameManager.GetInstance.WorldManager;
    }

    // Update is called once per frame
    void Update()
    {
        if(_Type == GameManager.ContrusctionType.House)
        {
            if(_CurrentTimeSpawn > _MaxTimeSpaw)
            {
                if(isPlayer1)
                {
                    if(_WorlManager._Player1Base._TotalHumans < _WorlManager._Player1Base._MaxHumans)
                    {
                        //Transform pos = gameObject.transform;

                         Instantiate(_Player1TemplateHuman, gameObject.transform);
                        _WorlManager._Player1Base._TotalHumans++;

                    }
                }
                else
                {
                    if (_WorlManager._Player2Base._TotalHumans < _WorlManager._Player2Base._MaxHumans)
                    {
                        Transform pos = gameObject.transform;

                        Instantiate(_Player2TemplateHuman, gameObject.transform);
                        _WorlManager._Player2Base._TotalHumans++;
                    }
                }
                
                _CurrentTimeSpawn = 0;
            }
            else
            {
                _CurrentTimeSpawn += Time.deltaTime;
            }
        }
    }


    public GameManager.ContrusctionType Type
    {
        get { return _Type; }
    }
}
