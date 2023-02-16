using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Human : BasicCharacter
{

    private GameManager.PlayerNumber _PlayerOwner;
    private GameObject _Target = null;
    private GameManager _GameManager = null;
    private World _WorldManager = null;

    // Resources
    private List<Resource> _WoodResources = null;
    private Resource _CurrentResource = null;   // Resource is gathering
    private int _CurrentResourceIndex = 0;
    private float _CurrentGatheringTime = 0f;
    private float _CurrentBuildingTime = 0f;

    // Constructions
    private List<Construction> _Churches = null;
    private BuildSpot _BuildSpotToBuild = null;


    // [SerializeField] private float m_AttackRange = 2.0f;

    public GameManager.HumanBehaviors _Behavior;
    public GameManager.ContrusctionType _BuildingToBuild;

    private void Start()
    {
        _GameManager = GameManager.GetInstance;
        _WorldManager = _GameManager.WorldManager;

        if (_WorldManager != null)
        {
            _WoodResources = _WorldManager.WoodResources;

            if (_PlayerOwner == GameManager.PlayerNumber.Player1)
            {
                _Churches = _WorldManager.Player1Churchs;
            }
            else
            {
                _Churches = _WorldManager.Player2Churchs;
            }

        }

        _Behavior = GameManager.HumanBehaviors.MovingToResource;
        _BuildingToBuild = GameManager.ContrusctionType.House;

    }

    // Update is called once per frame
    private void Update()
    {
              
        switch(_Behavior)
        {
            case GameManager.HumanBehaviors.CheckIfResources:
                bool areResourcesFree = false;
                for(int index = 0; index < _WoodResources.Count; index++)
                {
                    if (!_WoodResources[index]._IsPlayerHuman )
                    {
                        areResourcesFree = true;
                    }
                }

                if(areResourcesFree)
                {
                    _Behavior = GameManager.HumanBehaviors.MovingToResource;
                }
                break;
            case GameManager.HumanBehaviors.GatheringResource:
                GatheringResource();
                break;

            case GameManager.HumanBehaviors.MovingToResource:
                MovingToResource();
                break;

            case GameManager.HumanBehaviors.MovingToChurch:
                MovingToChurch();
                break;
            case GameManager.HumanBehaviors.MovingToBuild:
                MovingToBuild();
                break;
            case GameManager.HumanBehaviors.Building:
                Building();
                break;
        }

    }

    private void MovingToBuild()
    {
        if (_Target == null)
        {
            GetClosestFreeBuild();
        }
        
        HandleMovement();
        HandleRotation();

        float distanceToTarget = Vector3.Distance(_Target.transform.position, this.transform.position);
        if(distanceToTarget < 20f)
        {
            
            _Target = null;
            _Behavior = GameManager.HumanBehaviors.Building;

        }
    }

    public void Building()
    {
        if(_CurrentBuildingTime >= _BuildSpotToBuild.BuildingTime)
        {

            _CurrentBuildingTime = 0;
            Construction c = null;
            bool isAHouse = false;
            switch (_BuildingToBuild)
            {
                case GameManager.ContrusctionType.House:
                    c = _BuildSpotToBuild.BuildHouse(_PlayerOwner);
                    isAHouse = true;
                    break;

                case GameManager.ContrusctionType.Church:
                    c = _BuildSpotToBuild.BuildChurch(_PlayerOwner);
                    break;
            }
           
            
            _Behavior = GameManager.HumanBehaviors.MovingToResource;

            if(_PlayerOwner == GameManager.PlayerNumber.Player1)
            {
                
                if(isAHouse)
                {
                    _WorldManager.Player1Houses.Add(c);
                }
                else
                {
                    _WorldManager.Player1Churchs.Add(c);
                }
                
            }
            else
            {
                // Player 2

                if(isAHouse)
                {
                    _WorldManager.Player2Houses.Add(c);
                }
                else
                {
                    _WorldManager.Player2Churchs.Add(c);
                }
                
            }
        }
        else
        {
            _CurrentBuildingTime += Time.deltaTime;
        }
        
    }

    private void GetClosestFreeBuild()
    {
        float closestFreeBuild = -1;
        int freeBuildIdx = 0;

        for (int index = 0; index < _WorldManager._BuildSpots.Count; index++)
        {
            if (_WorldManager._BuildSpots[index].isFree)
            {
                float currentDistance = Vector3.Distance(this.transform.position, _WorldManager._BuildSpots[index].transform.position);

                if (closestFreeBuild == -1)
                {
                    closestFreeBuild = currentDistance;
                    freeBuildIdx = index;

                }
                else
                {
                    if (currentDistance < closestFreeBuild)
                    {
                        closestFreeBuild = currentDistance;
                        freeBuildIdx = index;
                    }
                }
            }
          


        }

        _Target = _WorldManager._BuildSpots[freeBuildIdx].gameObject;
        _WorldManager._BuildSpots[freeBuildIdx].isFree = false;
        _BuildSpotToBuild = _WorldManager._BuildSpots[freeBuildIdx];
    }

    private void GatheringResource()
    {
        
        // Wait some amount of time to gather resources
        if(_CurrentGatheringTime > _CurrentResource.GatheringTime)
        {
            
            _Behavior = GameManager.HumanBehaviors.MovingToChurch;
            _CurrentResource._IsPlayerHuman = false;
            _CurrentGatheringTime = 0;
            /*
            if(_CurrentResourceIndex >= 0 && _CurrentResourceIndex < _WoodResources.Count)
            {
                _WoodResources[_CurrentResourceIndex].isRecharging = true;
            }
                
            _WoodResources.Remove(_CurrentResource);
            */
        }
        else
        {
            _CurrentGatheringTime += Time.deltaTime;
        }
        
    }

    private void MovingToResource()
    {
        if(_Target == null)
        {
            // Which resource needs the human to gather
            if(_PlayerOwner == GameManager.PlayerNumber.Player1)
            {
                GetClosestResource(_WorldManager._Player1Base._ResourceNeeded);
            }
            else
            {
                GetClosestResource(_WorldManager._Player2Base._ResourceNeeded);
            }
           
        }
            

        HandleMovement();
        HandleRotation();

        float distanceToTarget = Vector3.Distance(_Target.transform.position, this.transform.position);

        if (distanceToTarget < 20f)
        {
            _Target = null;
            _Behavior = GameManager.HumanBehaviors.GatheringResource;
            
        }
    }

    private void MovingToChurch()
    {
        if(_Target == null)
        {
            if (_Churches.Count > 1)
            {
                GetClosestChurch();
            }
            else
            {
                // Only one church go to this one
                _Target = _Churches[0].gameObject;
            }
        }
       

        HandleMovement();
        HandleRotation();

        float distanceToTarget = Vector3.Distance(_Target.transform.position, this.transform.position);

        if (distanceToTarget < 20f)
        {
          
            if(_PlayerOwner == GameManager.PlayerNumber.Player1)
            {
                if(_CurrentResource.Type == GameManager.ResourceType.Wood)
                {
                    _WorldManager._Player1Base.IncWood();
                }
                else
                {
                    if(_CurrentResource.Type == GameManager.ResourceType.Mineral)
                    {
                        _WorldManager._Player1Base.IncStone();
                    }
                }
                
            }
            else
            {
                if (_CurrentResource.Type == GameManager.ResourceType.Wood)
                {
                    _WorldManager._Player2Base.IncWood();
                }
                else
                {
                    if (_CurrentResource.Type == GameManager.ResourceType.Mineral)
                    {
                        _WorldManager._Player2Base.IncStone();
                    }
                }
            }

            _Target = null;
            _Behavior = GameManager.HumanBehaviors.CheckIfResources;
            _CurrentResource= null;
        }
    }

    private void GetClosestChurch()
    {
        float closestChurch = -1;
        int churchIdx = 0;

        for(int index = 0; index < _Churches.Count; index++)
        {
            float currentDistance = Vector3.Distance(this.transform.position, _Churches[index].transform.position);

            if (closestChurch == -1)
            {
                closestChurch = currentDistance;
                churchIdx = index;

            }
            else
            {
                if (currentDistance < closestChurch)
                {
                    closestChurch = currentDistance;
                    churchIdx = index;
                }
            }
        }

        _Target = _Churches[churchIdx].gameObject;

    }
    private void GetClosestResource(GameManager.ResourceType type)
    {
        float closestResource = -1;
        int resourceIdx = 0;
        switch(type)
        {
            case GameManager.ResourceType.Wood:

                // Calculate where the closest resouce is
                for (int index = 0; index < _WoodResources.Count; index++)
                {
                    if(!_WoodResources[index]._IsPlayerHuman )
                    {
                        // Resource is free. Get closest one
                        float currentDistance = Vector3.Distance(this.transform.position, _WoodResources[index].transform.position);

                        if (closestResource == -1)
                        {
                            closestResource = currentDistance;
                            resourceIdx = index;

                        }
                        else
                        {
                            if (currentDistance < closestResource)
                            {
                                closestResource = currentDistance;
                                resourceIdx = index;
                            }
                        }
                    }
                                
                    

                }

                _CurrentResource = _WoodResources[resourceIdx];
                _CurrentResourceIndex = resourceIdx;
                _CurrentResource._IsPlayerHuman = true; // Resource taken
                _Target = _WoodResources[resourceIdx].gameObject;

                break;


                case GameManager.ResourceType.Mineral: 
                break;
        }
    }

    void HandleMovement()
    {
        if (_MovementBehavior == null)
            return;
        _MovementBehavior.Target = _Target;

    }

    void HandleRotation()
    {
        if(_MovementBehavior != null)
            _MovementBehavior.DesiredLookatPoint = _Target.transform.position;
       
    }

    void HandleAttacking()
    {
       // if (m_ShootingBehavior == null) return;

        //if (m_PlayerTarget == null) return;

        // If we are in range of the player, Fire our weapon
        // use sqr magnitude when comparing ranges as it is more efficient
      /*  if ((transform.position - m_PlayerTarget.transform.position).sqrMagnitude < m_AttackRange * m_AttackRange)
        {
            m_ShootingBehavior.PrimaryFire();

            // This is a Kamikaze enemy
            // When it fires, it should destroy itself

            Invoke(KILL_METHODNAME, 0.2f);
        }*/
    }

    const string KILL_METHODNAME = "Kill";
    void Kill()
    {
        if(_CurrentResource != null)
        {
            _CurrentResource._IsPlayerHuman = false;
        }

        if(_BuildSpotToBuild != null)
        {
            _BuildSpotToBuild.isFree = true;
        }
        Destroy(gameObject);
    }

    public GameManager.PlayerNumber PlayerOwner
    {
        get { return _PlayerOwner;  }
        set { _PlayerOwner = value;  }
    }

    public GameObject Target
    {
        set { _Target = value; }
    }
}
