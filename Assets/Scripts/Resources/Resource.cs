using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private GameManager.ResourceType _Type;

    private float _GatheringTime;

    private float _RechargingTimeMax = 5f;
    private float _CurrentRechargingTime = 0f;
    // To know if a human is working here or not
    public bool _IsPlayerHuman;

    public bool isRecharging = false;

    World _WorldManager = null;

    // Start is called before the first frame update
    void Awake()
    {
        isRecharging = false;
        if(_Type == GameManager.ResourceType.Wood)
        {
            _GatheringTime = 2f;
        }
        else
        {
            _GatheringTime = 3f;
        }
    }

    private void Start()
    {
        _WorldManager = GameManager.GetInstance.WorldManager;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRecharging)
        {
            /*
            gameObject.SetActive(false);

            if(_CurrentRechargingTime > _RechargingTimeMax) 
            {
                gameObject.SetActive(true);
                _WorldManager.WoodResources.Add(this);
                _CurrentRechargingTime = 0;
            }
            else
            {
                _CurrentRechargingTime += Time.deltaTime;
            }
            */
        }
        else
        {
            //gameObject.SetActive(true);
        }
    }


    public float GatheringTime
    {
        get { return _GatheringTime; }
    }

    public GameManager.ResourceType Type
    {
        get { return _Type; }
    }
}
