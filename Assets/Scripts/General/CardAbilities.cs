using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CardAbilities : MonoBehaviour
{

    public Camera _Cam;
    [SerializeField]
    private bool _Player1;
    [SerializeField]
    private bool _Player2;

    private GameManager _GameManager;
    private World _WorldManager = null;
    [SerializeField]
    private ControllerInputUI _ControllerInputUI;

    [SerializeField]
    private GameObject _PointerP1;

    [SerializeField]
    private GameObject _PointerP2;

     RaycastHit hit;

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
         _GameManager = GameManager.GetInstance;
        _WorldManager = _GameManager.WorldManager;
    }

    // Update is called once per frame
    void Update()
    {
        //var hit = _ControllerInputUI._Hit;
        if (_Player1)
        {
           
            Ray ray = _Cam.ScreenPointToRay(_ControllerInputUI.PointerPos);
            Debug.Log("PointerPos: " + _ControllerInputUI.PointerPos);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                int layerMask = LayerMask.GetMask("Destructible");
                Collider[] destructibles = Physics.OverlapSphere(hit.point, 50, layerMask, QueryTriggerInteraction.Collide);
                
                for(int i = 0; i < destructibles.Length; ++i)
                {
                   
                    Destroy(destructibles[i].gameObject);
                }
               
                
            }
        }

        if (_Player2)
        {
            Ray ray = _Cam.ScreenPointToRay(_ControllerInputUI.PointerPos);
            Debug.Log("PointerPos: " + _ControllerInputUI.PointerPos);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                int layerMask = LayerMask.GetMask("Destructible");
               Collider[] destructibles = Physics.OverlapSphere(hit.point, 50, layerMask, QueryTriggerInteraction.Collide);
                
                for(int i = 0; i < destructibles.Length; ++i)
                {
                    
                    Destroy(destructibles[i].gameObject);
                }
                
            }
        }

        //var p1Humans = _WorldManager.Player1Humans;
        //var p2Humans = _WorldManager.Player2Humans;

        //foreach (var human in p1Humans)
        //{
        //    foreach(var humanInArea in humansInArea)
        //    {
        //        if(human.name == humanInArea.name)
        //        {
        //            Destroy(human);
        //            Destroy(humanInArea);
        //        }
        //    }
        //}
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(hit.point, 50);
    }

}
