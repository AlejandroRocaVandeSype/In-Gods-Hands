using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private List<Construction> _Player1Churchs;
    [SerializeField] private List<Construction> _Player1Houses;
    [SerializeField] private List<Construction> _Player2Churchs;
    [SerializeField] private List<Construction> _Player2Houses;

    [SerializeField] private List<Resource> _WoodResources;
    [SerializeField] private List<Resource> _MineralResources;

    [SerializeField] private List<Human> _Player1Humans;
    [SerializeField] private List<Human> _Player2Humans;

    [SerializeField] public PlayerBase _Player1Base;
    [SerializeField] public PlayerBase _Player2Base;

    [SerializeField] public List<BuildSpot> _BuildSpots;


    int buildSpotIdx = -1;

    // Start is called before the first frame update
    void Start()
    {
        for(int index = 0; index < _Player1Humans.Count; index++)
        {
            _Player1Humans[index].PlayerOwner = GameManager.PlayerNumber.Player1;
        }

        for (int index = 0; index < _Player2Humans.Count; index++)
        {
            _Player1Humans[index].PlayerOwner = GameManager.PlayerNumber.Player2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_Player1Base!= null && _Player2Base != null)
        {
            // Update Info from each player base
            _Player1Base._TotalChurches = _Player1Churchs.Count;
            _Player1Base._TotalHumans = _Player1Humans.Count;
            _Player1Base._TotalHouses = _Player1Houses.Count;

            _Player2Base._TotalChurches = _Player2Churchs.Count;
            _Player2Base._TotalHumans = _Player2Humans.Count;
            _Player2Base._TotalHouses = _Player2Houses.Count;

            switch(_Player1Base.Order)
            {
                case GameManager.HumanOrders.GatherResources:
                    break;
                case GameManager.HumanOrders.BuildHouse:

                    if(IsThereAFreeBuildSpot())
                        SelectRandomHuman(GameManager.ContrusctionType.House, GameManager.PlayerNumber.Player1);
                    break;
                case GameManager.HumanOrders.BuildChurch:

                    if (IsThereAFreeBuildSpot())
                        SelectRandomHuman(GameManager.ContrusctionType.Church, GameManager.PlayerNumber.Player1);
                    break;
            }

            switch (_Player2Base.Order)
            {
                case GameManager.HumanOrders.GatherResources:
                    break;
                case GameManager.HumanOrders.BuildHouse:
                    if (IsThereAFreeBuildSpot())
                        SelectRandomHuman(GameManager.ContrusctionType.House, GameManager.PlayerNumber.Player2);
                    break;
                case GameManager.HumanOrders.BuildChurch:
                    if (IsThereAFreeBuildSpot())
                        SelectRandomHuman(GameManager.ContrusctionType.Church, GameManager.PlayerNumber.Player2);
                    break;
            }
        }

        
    }

    public void SelectRandomHuman(GameManager.ContrusctionType buildType, GameManager.PlayerNumber player)
    {
        if(player == GameManager.PlayerNumber.Player1)
        {
            int random = Random.Range(0, _Player1Humans.Count);
            GameManager.HumanBehaviors behavior = _Player1Humans[random]._Behavior;
            if (behavior != GameManager.HumanBehaviors.GatheringResource
                && behavior != GameManager.HumanBehaviors.MovingToChurch
                && behavior != GameManager.HumanBehaviors.MovingToBuild
                && behavior != GameManager.HumanBehaviors.Building)
            {
                _Player1Humans[random]._Behavior = GameManager.HumanBehaviors.MovingToBuild;
                _Player1Humans[random]._BuildingToBuild = buildType;
                _Player1Humans[random].Target = null;

                switch (buildType)
                {
                    case GameManager.ContrusctionType.House:
                        _Player1Base.DecWood(buildType);
                        break;
                    case GameManager.ContrusctionType.Church:
                        _Player1Base.DecWood(buildType);
                        break;
                }

                _Player1Base.Order = GameManager.HumanOrders.NoOrders;
            }
        }
        else
        {
            int random = Random.Range(0, _Player2Humans.Count);
            GameManager.HumanBehaviors behavior = _Player2Humans[random]._Behavior;
            if (behavior != GameManager.HumanBehaviors.GatheringResource
                && behavior != GameManager.HumanBehaviors.MovingToChurch
                && behavior != GameManager.HumanBehaviors.MovingToBuild
                && behavior != GameManager.HumanBehaviors.Building)
            {
                _Player2Humans[random]._Behavior = GameManager.HumanBehaviors.MovingToBuild;
                _Player2Humans[random]._BuildingToBuild = buildType;
                _Player2Humans[random].Target = null;

                switch (buildType)
                {
                    case GameManager.ContrusctionType.House:
                        _Player2Base.DecWood(buildType);
                        break;
                    case GameManager.ContrusctionType.Church:
                        _Player2Base.DecWood(buildType);
                        break;
                }

                _Player2Base.Order = GameManager.HumanOrders.NoOrders;
            }
        }
        
    }


    public bool IsThereAFreeBuildSpot()
    {
        
        for(int index= 0; index < _BuildSpots.Count; index++)
        {
            if (_BuildSpots[index].isFree)
            {               
                return true;
            }
        }

        return false;
    }
    

    public List<Construction> Player1Churchs
    {
        get { return _Player1Churchs; }
    }

    public List<Construction> Player2Churchs
    {
        get { return _Player2Churchs; }
    }

    public List<Construction> Player1Houses
    {
        get { return _Player1Houses; }
    }

    public List<Construction> Player2Houses
    {
        get { return _Player2Houses; }
    }

    public List<Resource> WoodResources
    {
        get { return _WoodResources; }
    }

    public List<Resource> MineralResources
    {
        get { return _MineralResources; }
    }
    public List<Human> Player1Humans
    {
        get { return _Player1Humans;}
    }
    public List<Human> Player2Humans
    {
        get { return _Player2Humans;}
    }
}
