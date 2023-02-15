using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private GameManager.ResourceType _Type;

    private float _GatheringTime;

    // To know if a human is working here or not
    public bool _IsPlayerHuman;

    // Start is called before the first frame update
    void Start()
    {
        if(_Type == GameManager.ResourceType.Wood)
        {
            _GatheringTime = 2f;
        }
        else
        {
            _GatheringTime = 3f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
