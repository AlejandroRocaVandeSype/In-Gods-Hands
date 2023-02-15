using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : BasicCharacter
{

    private GameManager.PlayerNumber _PlayerOwner;
    private GameObject _Target = null;
    private GameManager _GameManager = null;
    private World _WorldManager = null;

    // Resources
    private Resource[] _WoodResources = null;
    private Resource _CurrentResource = null;   // Resource is gathering

    // Constructions
    private Construction[] _Churches = null;

    // [SerializeField] private float m_AttackRange = 2.0f;

    private GameManager.HumanBehaviors _Behavior;
    private bool _IsAtTarget = false;


    protected override void Awake()
    {
        base.Awake();

        _GameManager = GameManager.GetInstance;
        _WorldManager = _GameManager.WorldManager;

        if(_WorldManager != null)
        {
            _WoodResources = _WorldManager.WoodResources;

            if(_PlayerOwner == GameManager.PlayerNumber.Player1)
            {
                _Churches = _WorldManager.Player1Churchs;
            }
            else
            {
                _Churches = _WorldManager.Player2Churchs;
            }
           
        }

        _Behavior = GameManager.HumanBehaviors.MovingToResource;

    }
    private void Start()
    {
        // Expensive method. Use it with caution
        // PlayerCharacter player = FindObjectOfType<PlayerCharacter>();

        // if (player != null)
        // m_PlayerTarget = player.gameObject;

        //_Target = _Constructions[0].gameObject;
       
    }

    // Update is called once per frame
    private void Update()
    {
        switch(_Behavior)
        {
            case GameManager.HumanBehaviors.GatheringResource:
                GatheringResource();
                break;

            case GameManager.HumanBehaviors.MovingToResource:
                MovingToResource();
                break;

            case GameManager.HumanBehaviors.MovingToChurch:
                MovingToChurch();
                break;
        }

    }

    private void GatheringResource()
    {
        _Behavior = GameManager.HumanBehaviors.MovingToChurch;
    }

    private void MovingToResource()
    {
        GetClosestResource(GameManager.ResourceType.Wood);
        HandleMovement();
        HandleRotation();

        float distanceToTarget = Vector3.Distance(_Target.transform.position, this.transform.position);

        if (distanceToTarget < 10f)
        {
            _IsAtTarget = true;
            _Target = null;
            _Behavior = GameManager.HumanBehaviors.GatheringResource;
        }
    }

    private void MovingToChurch()
    {
        if(_Churches.Length > 1 )
        {

        }
        else
        {
            // Only one church go to this one
            _Target = _Churches[0].gameObject;
        }

        HandleMovement();
        HandleRotation();

        float distanceToTarget = Vector3.Distance(_Target.transform.position, this.transform.position);

        if (distanceToTarget < 10f)
        {
            _IsAtTarget = true;
            _Target = null;
            _Behavior = GameManager.HumanBehaviors.MovingToResource;
        }
    }

    private void GetClosestResource(GameManager.ResourceType type)
    {
        float closestResource = -1;
        int resourceIdx = 0;
        switch(type)
        {
            case GameManager.ResourceType.Wood:

                // Calculate where the closest resouce is
                for (int index = 0; index < _WoodResources.Length; index++)
                {
                    if(_PlayerOwner == GameManager.PlayerNumber.Player1 && !_WoodResources[index]._IsPlayer1Human)
                    {
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
                    else
                    {
                        if(_PlayerOwner == GameManager.PlayerNumber.Player2 && !_WoodResources[index]._IsPlayer2Human)
                        {
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
                   
                    

                }

                _CurrentResource = _WoodResources[resourceIdx];
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


    private void OnCollisionEnter(Collision collision)
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
      
    }

    const string KILL_METHODNAME = "Kill";
    void Kill()
    {
        Destroy(gameObject);
    }

    public GameManager.PlayerNumber PlayerOwner
    {
        get { return _PlayerOwner;  }
        set { _PlayerOwner = value;  }
    }
}
