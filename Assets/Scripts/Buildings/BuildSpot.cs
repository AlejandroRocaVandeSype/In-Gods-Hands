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
            GameObject g;
            if (playerHuman == GameManager.PlayerNumber.Player1)
            {
                g = Instantiate(_Player1HouseTemplate, gameObject.transform);

                
            }
            else
            {
                 g = Instantiate(_Player2HouseTemplate, gameObject.transform);
               
            }
            c = (Construction)g.GetComponent(typeof(Construction));

            return c;
        }

        return null;
    }

    public Construction BuildChurch(GameManager.PlayerNumber playerHuman)
    {

        if(_Player1ChurchTemplate!= null)
        {
            Construction c;
            GameObject g;
            if (playerHuman == GameManager.PlayerNumber.Player1)
            {
                  g = Instantiate(_Player1ChurchTemplate, gameObject.transform);
                 
            }
            else
            {
                 g = Instantiate(_Player2ChurchTemplate, gameObject.transform);
                
            }
            c = (Construction)g.GetComponent(typeof(Construction));
            return c;
        }
        return null;
    }
}
