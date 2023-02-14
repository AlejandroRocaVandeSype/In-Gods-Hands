using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public Transform _CameraTransform;

    // MOVEMENT
    public Vector3 _NewPosition;
    public float _MovementSpeed;
    public float _MovementTime;
    private float _MaxRightMovement;
    private float _MaxVerticalMovement;

    // CAMERA ZOOM
    public Vector3 _ZoomAmount;
    public Vector3 _NewZoom;
    private float _MaxZoomOut;
    private const float _MaxZoomIn = 10f;

    const string HORIZONTAL_AXIS = "Horizontal1";
    const string VERTICAL_AXIS = "Vertical1";
    const string ZOOM_OUT_AXIS = "ZoomOut1";
    const string ZOOM_IN_AXIS = "ZoomIn1";


    private void Awake()
    {

    }

    private void Start()
    {
        _NewPosition = transform.position;
        _MaxRightMovement = _NewPosition.x + 15000f;
        _MaxVerticalMovement = _NewPosition.z + 15000f;

        if (_CameraTransform != null)
        {
            _NewZoom = _CameraTransform.localPosition;
            _MaxZoomOut = _NewZoom.y;
        }
        else
        {
            Debug.Log("No Camera attach to PlayerConroller1");
        }
    }

    private void Update()
    {
        HandleMovement();

        // transform.Translate(new Vector3(movementInput.x, 0, 0) * _MovementSpeed * Time.deltaTime);


        if (_CameraTransform != null)
        {
            HandleZoom();
        }

    }


    //public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    

    private void HandleMovement()
    {
        Vector3 v = (new Vector3(Input.GetAxis(HORIZONTAL_AXIS), 0.0f, Input.GetAxis(VERTICAL_AXIS)) * _MovementSpeed);

        MoveHorizontal(v.x);

        MoveVertical(v.z);
    }

    private void HandleZoom()
    {

        if (Input.GetAxis(ZOOM_IN_AXIS) > 0 && (_NewZoom.y > _MaxZoomIn))
        {
            _NewZoom += _ZoomAmount;
        }

        if (Input.GetAxis(ZOOM_OUT_AXIS) > 0 && (_NewZoom.y < _MaxZoomOut))
        {
            _NewZoom -= _ZoomAmount;
        }

        _CameraTransform.localPosition = Vector3.Lerp(_CameraTransform.localPosition, _NewZoom, Time.deltaTime * _MovementTime);

    }

    private void MoveHorizontal(float x_offset)
    {
        if (_NewPosition.x >= -_MaxRightMovement && _NewPosition.x <= _MaxRightMovement)
        {
            _NewPosition.x += x_offset;
            transform.position = Vector3.Lerp(transform.position, _NewPosition, Time.deltaTime * _MovementTime);
        }
        else
        {
            if (_NewPosition.x <= -_MaxRightMovement)
            {
                _NewPosition.x = -_MaxRightMovement;
            }
            else
            {
                if (_NewPosition.x >= _MaxRightMovement)
                {
                    _NewPosition.x = _MaxRightMovement;
                }
            }



            //_NewPosition.x = _MaxRightMovement;


        }
    }

    private void MoveVertical(float z_offset)
    {
        if (_NewPosition.z >= -_MaxVerticalMovement && _NewPosition.z <= _MaxVerticalMovement)
        {
            _NewPosition.z += z_offset;
            transform.position = Vector3.Lerp(transform.position, _NewPosition, Time.deltaTime * _MovementTime);
        }
        else
        {
            if (_NewPosition.z <= -_MaxVerticalMovement)
            {
                _NewPosition.z = -_MaxVerticalMovement;
            }
            else
            {
                if (_NewPosition.z >= _MaxVerticalMovement)
                {
                    _NewPosition.z = _MaxVerticalMovement;
                }
            }


        }
    }
}
