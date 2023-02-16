using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpot : MonoBehaviour
{
    [SerializeField] private GameObject _Player1HouseTemplate;
    [SerializeField] private GameObject _Player1ChurchTemplate;
    [SerializeField] private GameObject _Player2HouseTemplate;
    [SerializeField] private GameObject _Player2ChurchTemplate;

    public bool isFree = true;

    public float BuildingTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Construction BuildHouse(GameManager.PlayerNumber playerHuman)
    {
        if(_Player1HouseTemplate!= null)
        {
            Construction c;
            if(playerHuman == GameManager.PlayerNumber.Player1)
            {
                GameObject g = Instantiate(_Player1HouseTemplate, gameObject.transform);

                c = (Construction) g.GetComponent(typeof(Construction));
            }
            else
            {
                GameObject g = Instantiate(_Player2HouseTemplate, gameObject.transform);
                c = (Construction)g.GetComponent(typeof(Construction));
            }

            return c;
        }

        return null;
    }

    public void BuildChurch(GameManager.PlayerNumber playerHuman)
    {
        if(_Player1ChurchTemplate!= null)
        {
            if (playerHuman == GameManager.PlayerNumber.Player1)
            {
                Instantiate(_Player1ChurchTemplate, gameObject.transform);
            }
            else
            {
                Instantiate(_Player2ChurchTemplate, gameObject.transform);
            }
        }
        
    }
}
