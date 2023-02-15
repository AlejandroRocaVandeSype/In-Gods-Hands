using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private Construction[] _Player1Churchs;
    [SerializeField] private Construction[] _Player1Houses;
    [SerializeField] private Construction[] _Player1Forges;
    [SerializeField] private Construction[] _Player2Churchs;
    [SerializeField] private Construction[] _Player2Houses;
    [SerializeField] private Construction[] _Player2Forges;

    [SerializeField] private Resource[] _WoodResources;
    [SerializeField] private Resource[] _MineralResources;

    [SerializeField] private Human[] _Player1Humans;
    [SerializeField] private Human[] _Player2Humans;

    // Start is called before the first frame update
    void Start()
    {
        for(int index = 0; index < _Player1Humans.Length; index++)
        {
            _Player1Humans[index].PlayerOwner = GameManager.PlayerNumber.Player1;
        }

        for (int index = 0; index < _Player2Humans.Length; index++)
        {
            _Player1Humans[index].PlayerOwner = GameManager.PlayerNumber.Player2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Construction[] Player1Churchs
    {
        get { return _Player1Churchs; }
    }

    public Construction[] Player2Churchs
    {
        get { return _Player2Churchs; }
    }

    public Resource[] WoodResources
    {
        get { return _WoodResources; }
    }

    public Resource[] MineralResources
    {
        get { return _MineralResources; }
    }
}
