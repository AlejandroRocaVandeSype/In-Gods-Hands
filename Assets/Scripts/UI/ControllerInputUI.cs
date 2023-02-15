using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControllerInputUI : MonoBehaviour
{
    private GraphicRaycaster _graphicRaycaster;
    public Camera Cam;
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

        //Raycast towards the land while dragging
        RaycastHit hit;
        Ray ray = Cam.ScreenPointToRay(pointer.position);


        foreach (RaycastResult raycastResult in raycastResults)
        {
            var ui = raycastResult.gameObject.GetComponent<UIBehaviour>();

            //ExecuteEvents.Execute(raycastResult.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
            //ExecuteEvents.Execute(raycastResult.gameObject, pointer, ExecuteEvents.beginDragHandler);
            //xecuteEvents.Execute(raycastResult.gameObject, pointer, ExecuteEvents.pointerExitHandler);
            if (ui)
            {
                //if (Input.GetKeyDown(KeyCode.Space))
                //{
                   
                //        Debug.Log($"Hit {hit.collider.gameObject.name}");
                //        ExecuteEvents.Execute(hit.collider.gameObject, pointer, ExecuteEvents.beginDragHandler);
                   
                //}

                //if (Input.GetKey(KeyCode.Space))
                //{
                   
                //        ExecuteEvents.Execute(hit.collider.gameObject, pointer, ExecuteEvents.dragHandler);
                    
                //}

                //if (Input.GetKeyUp(KeyCode.Space))
                //{
                    
                //        ExecuteEvents.Execute(hit.collider.gameObject, pointer, ExecuteEvents.endDragHandler);
                    
                //}
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
