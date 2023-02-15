using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControllerInputUI : MonoBehaviour
{
    private GraphicRaycaster _graphicRaycaster;
    public Camera Cam;

    private GameObject _sphere;
    private bool _isDragging;

    private void Start()
    {
        _graphicRaycaster = GetComponentInParent<GraphicRaycaster>();


    }
    private void Update()
    {

        MovePointer();


        var pointer = new PointerEventData(EventSystem.current) { position = transform.position };

        //Cast ray towards Canvas elements through pointer's position and store result
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        _graphicRaycaster.Raycast(pointer, raycastResults);



        //UI element hit by the graphics raycaster
        UIBehaviour ui;
        if (raycastResults.Count > 0)
            ui = raycastResults[0].gameObject.GetComponent<UIBehaviour>();
        else
        {
            ui = null;
        }

        if (ui)
        {
            ExecuteEvents.Execute(ui.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log($"Hit {ui.name}");
                ExecuteEvents.Execute(ui.gameObject, pointer, ExecuteEvents.beginDragHandler);

            }

            if (Input.GetKey(KeyCode.Space))
            {
                ExecuteEvents.Execute(ui.gameObject, pointer, ExecuteEvents.dragHandler);
                _isDragging = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                ExecuteEvents.Execute(ui.gameObject, pointer, ExecuteEvents.endDragHandler);

            }
        }


        RaycastHit hit;
        Ray ray = Cam.ScreenPointToRay(pointer.position);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {

            //Debug.DrawLine(ray.origin, hit.point,Color.red);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Spawn primitive sphere
                _sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                _sphere.GetComponent<SphereCollider>().enabled = false;
                _sphere.transform.localScale = Vector3.one * 100;
                _sphere.transform.position = new Vector3(-500, -500, -500);
            }

            Debug.Log(_isDragging);
            if (Input.GetKey(KeyCode.Space))
            {
                _sphere.transform.position = hit.point;

            }
        }


    }

    void MovePointer()
    {
        //Change input later to use joystick axes
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.up;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position -= Vector3.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right;
        }
    }

}
