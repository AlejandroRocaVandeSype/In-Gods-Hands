using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControllerInputUI : MonoBehaviour
{
    private GraphicRaycaster _GraphicRaycaster;
    public Camera _Cam;
    [SerializeField]
    private bool _Player1;
    [SerializeField]
    private bool _Player2;


    public GameObject _AOE;
    private GameObject _Instantiated;
    public float _AOEScale = 1.0f;

    [SerializeField]
    private List<Image> _Cards;

    private Image _SelectedCard;

    private GameObject _Sphere;
    //private bool _IsDragging;

    private float _PointerSpeed = 2;

    string JOYSTICK_HORIZONTAL_AXIS;
    string JOYSTICK_VERTICAL_AXIS;

    string DPAD_HORIZONTAL_AXIS;
    string DPAD_VERTICAL_AXIS;

    private void Start()
    {
        _GraphicRaycaster = GetComponentInParent<GraphicRaycaster>();
        _Instantiated = Instantiate(_AOE,new Vector3(0,0,0),Quaternion.identity);
        _Instantiated.transform.localScale = new Vector3(_Instantiated.transform.localScale.x * _AOEScale, _Instantiated.transform.localScale.y, _Instantiated.transform.localScale.z * _AOEScale);
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

        PointerEventData pointer = null;
        if (_Player1)
        {
            //Added offset to poiner
            pointer = new PointerEventData(EventSystem.current) { position = new Vector3(transform.position.x + Screen.width/4, transform.position.y, 0) };

        }
        if (_Player2)
        {
            pointer = new PointerEventData(EventSystem.current) { position = new Vector3(transform.position.x - Screen.width / 4, transform.position.y, 0) };

        }
        Debug.Log(pointer.position);

        //Cast ray towards Canvas elements through pointer's position and store result
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        _GraphicRaycaster.Raycast(pointer, raycastResults);



        //UI element hit by the graphics raycaster
        //UIBehaviour ui;
        //if (raycastResults.Count > 0)
        //    ui = raycastResults[0].gameObject.GetComponent<UIBehaviour>();
        //else
        //{
        //    ui = null;
        //}

        //if raycast hits ui element
        if (_SelectedCard)
        {
           
            RaycastHit hit;
            Ray ray = _Cam.ScreenPointToRay(pointer.position);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                _Instantiated.active = true;
                if (_Player1)
                {
                   
                     _Instantiated.transform.position = hit.point;
                   
                    if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                    {
                        //Spawn primitive sphere
                        _Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        _Sphere.GetComponent<SphereCollider>().enabled = false;
                        _Sphere.transform.localScale = Vector3.one * 100;
                        _Sphere.transform.position = new Vector3(-500, -500, -500);
                    }

                    if (Input.GetKey(KeyCode.Joystick1Button0))
                    {
                        _Sphere.transform.position = hit.point;

                    }
                }
                if (_Player2)
                {
                    
                    _Instantiated.transform.position = hit.point;

                    if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                    {


                        //Spawn primitive sphere
                        _Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        _Sphere.GetComponent<SphereCollider>().enabled = false;
                        _Sphere.transform.localScale = Vector3.one * 100;
                        _Sphere.transform.position = new Vector3(-500, -500, -500);
                    }

                    if (Input.GetKey(KeyCode.Joystick2Button0))
                    {
                        _Sphere.transform.position = hit.point;

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
            if (transform.position.x < 0 + size.x/2)
            {
                transform.position = new Vector3(size.x/2, transform.position.y, 0);
            }
            if (transform.position.x > Screen.width / 2 -size.x/2)
            {
                transform.position = new Vector3(Screen.width / 2 - size.x/2, transform.position.y, 0);
            }
            if (transform.position.y < 0 + size.y/2)
            {
                transform.position = new Vector3(transform.position.x, size.y/2, 0);
            }
            if (transform.position.y > Screen.height - size.y/2)
            {
                transform.position = new Vector3(transform.position.x, Screen.height - size.y/2, 0);
            }

        }

        if(_Player2)
        {
            if (transform.position.x < Screen.width / 2+ size.x/2)
            {
                transform.position = new Vector3(Screen.width / 2, transform.position.y, 0);
            }
            if (transform.position.x > Screen.width -  size.x/2)
            {
                transform.position = new Vector3(Screen.width, transform.position.y, 0);
            }
            if (transform.position.y < 0+ size.y/2)
            {
                transform.position = new Vector3(transform.position.x, 0, 0);
            }
            if (transform.position.y > Screen.height- size.y/2)
            {
                transform.position = new Vector3(transform.position.x, Screen.height, 0);
            }
        }


        //Change input later to use joystick axes
        //if (Input.GetKey(KeyCode.Z))
        //{
        //    transform.position += Vector3.up;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position -= Vector3.up;
        //}
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.position -= Vector3.right;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += Vector3.right;
        //}
    }

    void SelectCard(Vector3 dpad)
    {

        if (dpad.x > .7f)
        {
            foreach (var card in _Cards)
            {
                card.GetComponent<OnHoverEffect>()._IsSelected = false;
            }

            _Cards[3].GetComponent<OnHoverEffect>()._IsSelected = true;
            _SelectedCard = _Cards[3];
        }
        if (dpad.y < -.7f)
        {
            foreach (var card in _Cards)
            {
                card.GetComponent<OnHoverEffect>()._IsSelected = false;
            }

            _Cards[2].GetComponent<OnHoverEffect>()._IsSelected = true;
            _SelectedCard = _Cards[2];

        }
        if (dpad.x < -.7f)
        {
            foreach (var card in _Cards)
            {
                card.GetComponent<OnHoverEffect>()._IsSelected = false;
            }

            _Cards[1].GetComponent<OnHoverEffect>()._IsSelected = true;
            _SelectedCard = _Cards[1];

        }
        if (dpad.y > .7f)
        {
            foreach (var card in _Cards)
            {
                card.GetComponent<OnHoverEffect>()._IsSelected = false;
            }

            _Cards[0].GetComponent<OnHoverEffect>()._IsSelected = true;
            _SelectedCard = _Cards[0];

        }
    }



}
