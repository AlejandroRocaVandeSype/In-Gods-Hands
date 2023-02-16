using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    // Resources
    public int _TotalAmountWood ;
    public int _TotalAmountMineral;
    const int _WoodIncAmount = 1;
    const int _MineralIncAmount = 1;

    // Humans
    public int _TotalHumans;
    public int _MaxHumans = 10;          // Max humans allow

    // Buildings
    public int _TotalHouses;
    public int _TotalChurches;
    public const int _HousesPerChurch = 5;
    const int _ChurchCost = 3;      // WoodAndMetal
    const int _HouseCost = 4;       //  wood

    public GameManager.ResourceType _ResourceNeeded;
    private GameManager.HumanOrders _Order;

    private float _WaitNoOrders = 1f;
    private float _CurrentWait = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _ResourceNeeded = GameManager.ResourceType.Wood;
    }

    // Update is called once per frame
    void Update()
    {

        _TotalHumans = _TotalHouses * 10; // Each house increments the max amount of humans by then

        if (_Order == GameManager.HumanOrders.NoOrders)
        {
            if (_CurrentWait > _WaitNoOrders)
            {
                _CurrentWait = 0f;
            }
            else
            {
                _CurrentWait += Time.deltaTime;
                return;

            }
        }
        
        if(_TotalChurches == 0)
        {
            // GameOver
            /*
            // No churches --> Priority N� 1
            _ResourceNeeded = GameManager.ResourceType.WoodAndMineral;
            if (_TotalAmountWood >= _ChurchCost && _TotalAmountMineral >= _ChurchCost)
            {
                _Order = GameManager.HumanOrders.BuildChurch;
            }
            */
            return;
        }
        
        if(_TotalHouses < (_HousesPerChurch * _TotalChurches) )
        {
            
            // Min amount of houses before start worrying about the churches
            _ResourceNeeded = GameManager.ResourceType.Wood;

            if(_TotalAmountWood >= _HouseCost)
            {
                _Order = GameManager.HumanOrders.BuildHouse;
            }
            return;
        }
        else
        {
            if(_TotalHouses % _HousesPerChurch == 0)
            {
                // A church is needed 
                _ResourceNeeded = GameManager.ResourceType.Wood;
                if (_TotalAmountWood >= _ChurchCost /*&& _TotalAmountMineral >= _ChurchCost*/)
                {
                    _Order = GameManager.HumanOrders.BuildChurch;
                }
            }
            else
            {
                // A house is needed
                _ResourceNeeded = GameManager.ResourceType.Wood;

                if (_TotalAmountWood >= _HouseCost)
                {
                    _Order = GameManager.HumanOrders.BuildHouse;
                }
            }
           
            return;
        }

    }


    public void IncWood()
    {
        _TotalAmountWood += _WoodIncAmount;
    }

    public void IncStone()
    {
        _TotalAmountMineral += _MineralIncAmount;
    }

    public void DecWood(GameManager.ContrusctionType type)
    {
        switch(type)
        {
            case GameManager.ContrusctionType.House:

                _TotalAmountWood -= _HouseCost;
                if(_TotalAmountWood< 0)
                    _TotalAmountWood= 0;
                break;
            case GameManager.ContrusctionType.Church:
                _TotalAmountWood -= _ChurchCost;
                if (_TotalAmountWood < 0)
                    _TotalAmountWood = 0;
                break;
        }
    }

    public void DecMineral()
    {
        _TotalAmountMineral -= _ChurchCost;
        if (_TotalAmountMineral < 0)
            _TotalAmountWood = 0;
    }

    public GameManager.HumanOrders Order
    {
        get { return _Order; }
        set { _Order = value;  }
    }
}
