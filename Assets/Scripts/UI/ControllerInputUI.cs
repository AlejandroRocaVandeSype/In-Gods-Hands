using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControllerInputUI : MonoBehaviour
{
    public Camera _Cam;
    [SerializeField]
    private bool _Player1;
    [SerializeField]
    private bool _Player2;

    private RaycastHit hit;
    private PointerEventData _Pointer = null;
    public Vector3 PointerPos;

    private Vector3 _InstancedAOEScale;
    private Vector3 HitPoint;

    public GameObject _AOE;
    private GameObject _Instantiated;
    public float _AOEScale = 1.0f;

    [SerializeField]
    private List<Image> _Cards;

    private Image _SelectedCard;
    public Image SelectedCard
    {
        get {return _SelectedCard;}
    }

    public CardManager _CardManager;
    public CardAbilities _CardAbilities;
    private GameObject _Sphere;
    //private bool _IsDragging;

    private float _PointerSpeed = 2;

    string JOYSTICK_HORIZONTAL_AXIS;
    string JOYSTICK_VERTICAL_AXIS;

    string DPAD_HORIZONTAL_AXIS;
    string DPAD_VERTICAL_AXIS;

    private void Start()
    {
        _Instantiated = Instantiate(_AOE, new Vector3(0, 0, 0), Quaternion.identity);
        _InstancedAOEScale = _Instantiated.transform.localScale = new Vector3(_Instantiated.transform.localScale.x * _AOEScale, _Instantiated.transform.localScale.y, _Instantiated.transform.localScale.z * _AOEScale);
        _Instantiated.active = false;
        if (_Player1)
        {
            JOYSTICK_HORIZONTAL_AXIS = "Horizontal1RightJoystick";
            JOYSTICK_VERTICAL_AXIS = "Vertical1RightJoystick";

            DPAD_HORIZONTAL_AXIS = "Dpad1Horizontal";
            DPAD_VERTICAL_AXIS = "Dpad1Vertical";
        }
        else if (_Player2)
        {
            JOYSTICK_HORIZONTAL_AXIS = "Horizontal2RightJoystick";
            JOYSTICK_VERTICAL_AXIS = "Vertical2RightJoystick";

            DPAD_HORIZONTAL_AXIS = "Dpad2Horizontal";
            DPAD_VERTICAL_AXIS = "Dpad2Vertical";
        }
        else
        {
            Debug.Log("No Player Selected");
        }


    }
    private void Update()
    {
        Vector3 v = (new Vector3(Input.GetAxis(JOYSTICK_HORIZONTAL_AXIS), Input.GetAxis(JOYSTICK_VERTICAL_AXIS), 0.0f));
        Vector3 dpad = new Vector3(Input.GetAxis(DPAD_HORIZONTAL_AXIS), Input.GetAxis(DPAD_VERTICAL_AXIS), 0.0f);
        // Debug.Log(dpad);
        MovePointer(v);
        SelectCard(dpad);

        if (_SelectedCard)
            _SelectedCard.GetComponent<OnHoverEffect>().MoveUp();


        if (_Player1)
        {
            //Added offset to poiner
            _Pointer = new PointerEventData(EventSystem.current) { position = new Vector3(transform.position.x + Screen.width / 4, transform.position.y, 0) };
            PointerPos = _Pointer.position;
        }
        if (_Player2)
        {
            _Pointer = new PointerEventData(EventSystem.current) { position = new Vector3(transform.position.x - Screen.width / 4, transform.position.y, 0) };
            PointerPos = _Pointer.position;


        }


        if (_SelectedCard)
        {

            RaycastHit hit;
            Ray ray = _Cam.ScreenPointToRay(_Pointer.position);
           int layerMask =~ LayerMask.GetMask("Destructible");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask))
            {
                HitPoint = hit.point;
                _Instantiated.active = true;

                object[] objects = new object[3];
                    objects[0] = _SelectedCard.name;
                    objects[1] = _Player1;
                objects[2] = _Player2;
                if (_Player1)
                {

                    _Instantiated.transform.position = new Vector3(hit.point.x, 45, hit.point.z);

                    if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                    {
                        //Spawn primitive sphere
                        //_Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        //_Sphere.GetComponent<SphereCollider>().enabled = false;
                        //_Sphere.transform.localScale = Vector3.one * 100;
                        //_Sphere.transform.position = new Vector3(-500, -500, -500);
                    }

                    if (Input.GetKey(KeyCode.Joystick1Button0))
                    {
                        //_Sphere.transform.position = hit.point;

                    }
                    
                    if (Input.GetKeyUp(KeyCode.Joystick1Button0))
                    {
                        _CardAbilities.SendMessage("DoCardEffect",objects);
                       //Remove selected card from the cardmanager
                       _CardManager.RemoveCard(_SelectedCard.name);
                       

                    }

                }
                if (_Player2)
                {
                    HitPoint = hit.point;

                    _Instantiated.transform.position = new Vector3(hit.point.x, 45, hit.point.z);

                    if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                    {


                        ////Spawn primitive sphere
                        //_Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        //_Sphere.GetComponent<SphereCollider>().enabled = false;
                        //_Sphere.transform.localScale = Vector3.one * 100;
                        //_Sphere.transform.position = new Vector3(-500, -500, -500);
                    }

                    if (Input.GetKey(KeyCode.Joystick2Button0))
                    {
                        //_Sphere.transform.position = hit.point;

                    }
                     if (Input.GetKeyUp(KeyCode.Joystick2Button0))
                    {
                        _CardAbilities.SendMessage("DoCardEffect",objects);

                       //Remove selected card from the cardmanager
                       _CardManager.RemoveCard(_SelectedCard.name);


                    }
                }

            }
        }


    }

    void MovePointer(Vector3 v3)
    {
        transform.position += new Vector3(v3.x, v3.y, 0) * _PointerSpeed;
        var size = gameObject.GetComponent<RectTransform>().lossyScale;
        //Constrain player 
        if (_Player1)
        {
            if (transform.position.x < 0 + size.x / 2)
            {
                transform.position = new Vector3(size.x / 2, transform.position.y, 0);
            }
            if (transform.position.x > Screen.width / 2 - size.x / 2)
            {
                transform.position = new Vector3(Screen.width / 2 - size.x / 2, transform.position.y, 0);
            }
            if (transform.position.y < 0 + size.y / 2)
            {
                transform.position = new Vector3(transform.position.x, size.y / 2, 0);
            }
            if (transform.position.y > Screen.height - size.y / 2)
            {
                transform.position = new Vector3(transform.position.x, Screen.height - size.y / 2, 0);
            }

        }

        if (_Player2)
        {
            if (transform.position.x < Screen.width / 2 + size.x / 2)
            {
                transform.position = new Vector3(Screen.width / 2, transform.position.y, 0);
            }
            if (transform.position.x > Screen.width - size.x / 2)
            {
                transform.position = new Vector3(Screen.width, transform.position.y, 0);
            }
            if (transform.position.y < 0 + size.y / 2)
            {
                transform.position = new Vector3(transform.position.x, 0, 0);
            }
            if (transform.position.y > Screen.height - size.y / 2)
            {
                transform.position = new Vector3(transform.position.x, Screen.height, 0);
            }
        }

    }

    void SelectCard(Vector3 dpad)
    {

        if (dpad.x > .7f)
        {
            foreach (var card in _Cards)
            {
                card.GetComponent<OnHoverEffect>()._IsSelected = false;
                card.GetComponent<OnHoverEffect>().MoveDown();
                card.GetComponent<OnHoverEffect>().ScaleDown();
            }

            _Cards[3].GetComponent<OnHoverEffect>()._IsSelected = true;
            _Cards[3].GetComponent<OnHoverEffect>().ScaleUp();
            _SelectedCard = _Cards[3];
        }
        if (dpad.y < -.7f)
        {
            foreach (var card in _Cards)
            {
                card.GetComponent<OnHoverEffect>()._IsSelected = false;
                card.GetComponent<OnHoverEffect>().MoveDown();
                card.GetComponent<OnHoverEffect>().ScaleDown();

            }

            _Cards[2].GetComponent<OnHoverEffect>()._IsSelected = true;
            _Cards[2].GetComponent<OnHoverEffect>().ScaleUp();

            _SelectedCard = _Cards[2];

        }
        if (dpad.x < -.7f)
        {
            foreach (var card in _Cards)
            {
                card.GetComponent<OnHoverEffect>()._IsSelected = false;
                card.GetComponent<OnHoverEffect>().MoveDown();
                card.GetComponent<OnHoverEffect>().ScaleDown();


            }

            _Cards[1].GetComponent<OnHoverEffect>()._IsSelected = true;
            _Cards[1].GetComponent<OnHoverEffect>().ScaleUp();

            _SelectedCard = _Cards[1];

        }
        if (dpad.y > .7f)
        {
            foreach (var card in _Cards)
            {
                card.GetComponent<OnHoverEffect>()._IsSelected = false;
                card.GetComponent<OnHoverEffect>().MoveDown();
                card.GetComponent<OnHoverEffect>().ScaleDown();


            }

            _Cards[0].GetComponent<OnHoverEffect>()._IsSelected = true;
            _Cards[0].GetComponent<OnHoverEffect>().ScaleUp();

            _SelectedCard = _Cards[0];

        }
    }


    public bool Player1
    {
        get { return _Player1; }
    }
    public bool Player2
    {
        get { return _Player2; }
    }
    public Vector3 InstancedAOEScale
    {
        get { return _InstancedAOEScale; }
    }

    public GameObject InstancedAOE
    {
        get { return _Instantiated; }
    }

    public Vector3 _Hit
    {
        get { return HitPoint; }
    }
}
