using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.VFX;
using System.Linq;


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
    private CardManager _CardManagerP1;
    [SerializeField]
    private CardManager _CardManagerP2;
    [SerializeField]
    private GameObject _PointerP1;

    [SerializeField]
    private GameObject _PointerP2;

    RaycastHit hit;

    [SerializeField]
    private List<VisualEffectAsset> _Effects;

    [SerializeField]
    private List<GameObject> _CardEffects;
    [SerializeField]
    private Resource _Tree;
    [SerializeField]
    private Human _Human;


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
            if (_ControllerInputUI.SelectedCard)
            {
                //switch (_ControllerInputUI.SelectedCard.name)
                //{
                //    case "BadOmens":
                //        BadOmens();
                //        break;
                //    case "HolyWar":
                //        HolyWar();
                //        break;
                //    case "CrushHope":
                //        CrushHope();
                //        break;
                //    case "Sunshine":
                //        SunShine();
                //        break;
                //    case "BackToServe":
                //        BackToServe();
                //        break;
                //    case "GodsWill": //Changed from "God's Will"
                //        GodsPlan();
                //        break;
                //    case "Wololo":
                //        Wololo();
                //        break;
                //    case "DenyProphecy":
                //        DenyProphecy();
                //        break;

                //}
                //Ray ray = _Cam.ScreenPointToRay(_ControllerInputUI.PointerPos);
                //// Debug.Log("PointerPos: " + _ControllerInputUI.PointerPos);
                //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                //{

                //    int layerMask = LayerMask.GetMask("Destructible");
                //    Collider[] destructibles = Physics.OverlapSphere(hit.point, 50, layerMask, QueryTriggerInteraction.Collide);

                //    for (int i = 0; i < destructibles.Length; ++i)
                //    {

                //        Destroy(destructibles[i].gameObject);
                //    }


                //}
            }

        }

        if (_Player2)
        {
            {

                //switch (_ControllerInputUI.SelectedCard.name)
                //{
                //    case "BadOmens":
                //        BadOmens();
                //        break;
                //    case "HolyWar":
                //        HolyWar();
                //        break;
                //    case "CrushHope":
                //        CrushHope();
                //        break;
                //    case "Sunshine":
                //        SunShine();
                //        break;
                //    case "BackToServe":
                //        BackToServe();
                //        break;
                //    case "GodsWill": //Changed from "God's Will"
                //        GodsPlan();
                //        break;
                //    case "Wololo":
                //        Wololo();
                //        break;
                //    case "DenyProphecy":
                //        DenyProphecy();
                //        break;

                //}
                //Ray ray = _Cam.ScreenPointToRay(_ControllerInputUI.PointerPos);
                ////Debug.Log("PointerPos: " + _ControllerInputUI.PointerPos);
                //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                //{
                //    int layerMask = LayerMask.GetMask("Destructible");
                //    Collider[] destructibles = Physics.OverlapSphere(hit.point, 50, layerMask, QueryTriggerInteraction.Collide);

                //    for (int i = 0; i < destructibles.Length; ++i)
                //    {

                //        Destroy(destructibles[i].gameObject);
                //    }

                //}
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




    void DoCardEffect(object[] arr)
    {
        if (_ControllerInputUI.Player1)
        {
            if (_ControllerInputUI.SelectedCard)
            {
                switch (_ControllerInputUI.SelectedCard.name)
                {
                    case "BadOmens":
                        BadOmens();
                        Debug.Log("1");

                        break;
                    case "HolyWar":
                        HolyWar();
                        Debug.Log("1");

                        break;
                    case "CrushHope":
                        CrushHope();
                        Debug.Log("1");

                        break;
                    case "Sunshine":
                        SunShine();
                        Debug.Log("1");

                        break;
                    case "BackToServe":
                        BackToServe();
                        Debug.Log("1");

                        break;
                    case "GodsWill": //Changed from "God's Will"
                        GodsPlan();
                        Debug.Log("1");

                        break;
                    case "Wololo":
                        Wololo();
                        Debug.Log("1");

                        break;
                    case "DenyProphecy":
                        DenyProphecy();
                        Debug.Log("1");

                        break;

                }
            }
        }


        if (_ControllerInputUI.Player2)
        {
            if (_ControllerInputUI.SelectedCard)
            {
                switch (_ControllerInputUI.SelectedCard.name)
                {
                    case "BadOmens":
                        BadOmens();
                        Debug.Log("2");
                        break;
                    case "HolyWar":
                        HolyWar();
                        Debug.Log("2");

                        break;
                    case "CrushHope":
                        CrushHope();
                        Debug.Log("2");

                        break;
                    case "Sunshine":
                        SunShine();
                        Debug.Log("2");

                        break;
                    case "BackToServe":
                        BackToServe();
                        Debug.Log("2");

                        break;
                    case "GodsWill": //Changed from "God's Will"
                        GodsPlan();
                        Debug.Log("2");

                        break;
                    case "Wololo":
                        Wololo();
                        Debug.Log("2");

                        break;
                    case "DenyProphecy":
                        DenyProphecy();
                        Debug.Log("2");

                        break;

                }
            }
        }
    }


    void BadOmens()
    {

        Debug.Log("BadOmens");
        Ray ray = _Cam.ScreenPointToRay(_ControllerInputUI.PointerPos);
        //Debug.Log("PointerPos: " + _ControllerInputUI.PointerPos);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            int layerMask = LayerMask.GetMask("SunShine");
            Collider[] SunShine = Physics.OverlapSphere(hit.point, 50, layerMask, QueryTriggerInteraction.Collide);
            foreach (var sun in SunShine)
            {
                Destroy(sun.gameObject);
            }
            var BadOmen = Instantiate(_CardEffects.Where(eff => eff.name == "BadOmenEffect").SingleOrDefault(), hit.point, Quaternion.identity);

        }
    }

    void HolyWar()
    {
        Debug.Log("HolyWar");

    }

    void CrushHope()
    {
        Debug.Log("CrushHope");
        Ray ray = _Cam.ScreenPointToRay(_ControllerInputUI.PointerPos);
        //Debug.Log("PointerPos: " + _ControllerInputUI.PointerPos);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            int layerMask = LayerMask.GetMask("Destructible");
            Collider[] destructibles = Physics.OverlapSphere(hit.point, 25, layerMask, QueryTriggerInteraction.Collide);
            var CrushHope = Instantiate(_CardEffects.Where(eff => eff.name == "CrushHopeEffect").SingleOrDefault(), hit.point, Quaternion.identity);


            for (int i = 0; i < destructibles.Length; ++i)
            {

                Destroy(destructibles[i].gameObject);
            }

        }

    }
    void SunShine()
    {
        Debug.Log("SunShine");
        Ray ray = _Cam.ScreenPointToRay(_ControllerInputUI.PointerPos);
        //Debug.Log("PointerPos: " + _ControllerInputUI.PointerPos);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {

            int layerMask = LayerMask.GetMask("BadOmens");
            Collider[] BadOmen = Physics.OverlapSphere(hit.point, 50, layerMask, QueryTriggerInteraction.Collide);
            foreach (var omen in BadOmen)
            {
                Destroy(omen.gameObject);
            }
            var SunShine = Instantiate(_CardEffects.Where(eff => eff.name == "SunShineEffect").SingleOrDefault(), hit.point, Quaternion.identity);
            var Tree = Instantiate(_Tree, new Vector3(hit.point.x - 25, hit.point.y, hit.point.z), Quaternion.identity);
            _WorldManager.WoodResources.Add(Tree);

            Tree = Instantiate(_Tree, new Vector3(hit.point.x + 25, hit.point.y, hit.point.z), Quaternion.identity);
            _WorldManager.WoodResources.Add(Tree);

            Tree = Instantiate(_Tree, new Vector3(hit.point.x, hit.point.y, hit.point.z + 25), Quaternion.identity);
            _WorldManager.WoodResources.Add(Tree);

        }

    }
    void BackToServe()
    {
        Debug.Log("BackToServe");
        //check the max number of people possible according to the houses
        //sopawn 5 or less humans and add them to the player

        Ray ray = _Cam.ScreenPointToRay(_ControllerInputUI.PointerPos);
        //Debug.Log("PointerPos: " + _ControllerInputUI.PointerPos);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            var BackToServe = Instantiate(_CardEffects.Where(eff => eff.name == "BackToServeEffect").SingleOrDefault(), hit.point, Quaternion.identity);
            if (_Player1)
            {
                for (int i = 0; i < 5; ++i)
                {
                    var human = Instantiate(_Human, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                    _WorldManager.Player1Humans.Add(human);
                }
            }

            if (_Player2)
            {
                for (int i = 0; i < 5; ++i)
                {
                    var human = Instantiate(_Human, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
                    _WorldManager.Player2Humans.Add(human);
                }
            }
        }
    }
    void GodsPlan() //drake 
    {
        Debug.Log("GodsPlan");

    }
    void Wololo()
    {
        Debug.Log("Wololo");
        Ray ray = _Cam.ScreenPointToRay(_ControllerInputUI.PointerPos);
        //Debug.Log("PointerPos: " + _ControllerInputUI.PointerPos);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            int layerMask = LayerMask.GetMask("Destructible");
            Collider[] destructibles = Physics.OverlapSphere(hit.point, 50, layerMask, QueryTriggerInteraction.Collide);

            var vfx = new GameObject("WololoVFX");
            vfx.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            vfx.transform.localScale = new Vector3(10, 10, 10);

            vfx.AddComponent<VisualEffect>();
            vfx.GetComponent<VisualEffect>().visualEffectAsset = _Effects.Where(obj => obj.name == "VFX_Wololo").SingleOrDefault();
            vfx.GetComponent<VisualEffect>().Play();


            for (int i = 0; i < destructibles.Length; ++i)
            {

                if (destructibles[i].tag == "Human")
                {
                    List<Human> humans = new List<Human>();
                    foreach (var human in humans)
                    {
                        if (_Player1)
                            human.PlayerOwner = GameManager.PlayerNumber.Player1;
                        else
                        {
                            human.PlayerOwner = GameManager.PlayerNumber.Player2;

                        }
                    }
                }
            }

        }

    }
    void DenyProphecy()
    {
        Debug.Log("DenyProphecy");
        if (_Player1)
            _CardManagerP2.RemoveRandomCard();
        else
            _CardManagerP1.RemoveRandomCard();

    }
}
