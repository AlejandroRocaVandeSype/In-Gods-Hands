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
            if (_ControllerInputUI.SelectedCard)
            {
                if (_ControllerInputUI.SelectedCard.name == "CrushHope")
                {
                    _ControllerInputUI._AOE.transform.localScale = new Vector3(25, 0.5f, 25);

                }

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




    void DoCardEffect(string name)
    {
        if (_Player1)
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


        if (_Player2)
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
            var BadOmen = Instantiate(_CardEffects.Where(eff => eff.name == "BadOmenEffect").SingleOrDefault(),hit.point,Quaternion.identity);

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

            var vfx = new GameObject("CrushHopeVFX");
            vfx.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            vfx.transform.localScale = new Vector3(10, 10, 10);

            vfx.AddComponent<VisualEffect>();
            vfx.GetComponent<VisualEffect>().visualEffectAsset = _Effects.Where(obj => obj.name == "VFX_CrushHope").SingleOrDefault();
            vfx.GetComponent<VisualEffect>().Play();


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
            var SunShineCollider = new GameObject("SunShineCollider");
            SunShineCollider.AddComponent<SphereCollider>();
            SunShineCollider.GetComponent<SphereCollider>().radius = 50;
            SunShineCollider.GetComponent<SphereCollider>().isTrigger = true;
            SunShineCollider.layer = 11;

            int layerMask = LayerMask.GetMask("BadOmens");
            Collider[] badOmens = Physics.OverlapSphere(hit.point, 50, layerMask, QueryTriggerInteraction.Collide);

            var vfx = new GameObject("SunShineVFX");
            vfx.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            vfx.transform.localScale = new Vector3(10, 10, 10);

            vfx.AddComponent<VisualEffect>();
            vfx.GetComponent<VisualEffect>().visualEffectAsset = _Effects.Where(obj => obj.name == "VFX_SunShine").SingleOrDefault();
            vfx.GetComponent<VisualEffect>().Play();


            for (int i = 0; i < badOmens.Length; ++i)
            {

                Destroy(badOmens[i].gameObject);
            }

        }

    }
    void BackToServe()
    {
        Debug.Log("BackToServe");
        //check the max number of people possible according to the houses
        //sopawn 5 or less humans and add them to the player

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
