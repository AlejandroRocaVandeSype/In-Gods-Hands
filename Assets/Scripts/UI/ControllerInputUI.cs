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
    private GameObject _Sphere;
    //private bool _IsDragging;


    string HORIZONTAL_AXIS;
    string VERTICAL_AXIS;
    private void Start()
    {
        _GraphicRaycaster = GetComponentInParent<GraphicRaycaster>();
        if (_Player1)
        {
            HORIZONTAL_AXIS = "Horizontal1RightJoystick";
            VERTICAL_AXIS = "Vertical1RightJoystick";
        }
        else if (_Player2)
        {
            HORIZONTAL_AXIS = "Horizontal2RightJoystick";
            VERTICAL_AXIS = "Vertical2RightJoystick";
        }
        else
        {
            Debug.Log("No Player Selected");
        }


    }
    private void Update()
    {
        Vector3 v = (new Vector3(Input.GetAxis(HORIZONTAL_AXIS), Input.GetAxis(VERTICAL_AXIS), 0.0f));
        Debug.Log(v);
        MovePointer(v);


        var pointer = new PointerEventData(EventSystem.current) { position = transform.position };

        //Cast ray towards Canvas elements through pointer's position and store result
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        _GraphicRaycaster.Raycast(pointer, raycastResults);



        //UI element hit by the graphics raycaster
        UIBehaviour ui;
        if (raycastResults.Count > 0)
            ui = raycastResults[0].gameObject.GetComponent<UIBehaviour>();
        else
        {
            ui = null;
        }

        //if raycast hits ui element
        if (ui)
        {
            //call the pointerEnter function
            ExecuteEvents.Execute(ui.gameObject, pointer, ExecuteEvents.pointerEnterHandler);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ExecuteEvents.Execute(ui.gameObject, pointer, ExecuteEvents.beginDragHandler);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                ExecuteEvents.Execute(ui.gameObject, pointer, ExecuteEvents.dragHandler);
                // _IsDragging = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                ExecuteEvents.Execute(ui.gameObject, pointer, ExecuteEvents.endDragHandler);

            }
        }


        RaycastHit hit;
        Ray ray = _Cam.ScreenPointToRay(pointer.position);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Spawn primitive sphere
                _Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                _Sphere.GetComponent<SphereCollider>().enabled = false;
                _Sphere.transform.localScale = Vector3.one * 100;
                _Sphere.transform.position = new Vector3(-500, -500, -500);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                _Sphere.transform.position = hit.point;

            }
        }


    }

    void MovePointer(Vector3 v3)
    {
        transform.position += new Vector3(v3.x, v3.y, 0) * 2;


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



}
