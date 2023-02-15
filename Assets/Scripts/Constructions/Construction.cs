using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    private bool _IsConstructed;
    [SerializeField] private GameManager.ContrusctionType _Type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameManager.ContrusctionType Type
    {
        get { return _Type; }
    }
}
