using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Image))]
public class DragMe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool dragOnSurfaces = true;
    public Camera Cam;
    private GameObject m_DraggingIcon;
    private RectTransform m_DraggingPlane;
    private GameObject _sphere;

    public void OnBeginDrag(PointerEventData eventData)
    {

        
        //Spawn primitive sphere
        _sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        _sphere.GetComponent<SphereCollider>().enabled = false;
        _sphere.transform.localScale = Vector3.one * 500;


        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        // We have clicked something that can be dragged.
        // What we want to do is create an icon for this.
        m_DraggingIcon = new GameObject("icon");

        m_DraggingIcon.transform.SetParent(canvas.transform, false);
        m_DraggingIcon.transform.SetAsLastSibling();

        var image = m_DraggingIcon.AddComponent<Image>();

        image.sprite = GetComponent<Image>().sprite;
        image.SetNativeSize();

        if (dragOnSurfaces)
            m_DraggingPlane = transform as RectTransform;
        else
            m_DraggingPlane = canvas.transform as RectTransform;

        SetDraggedPosition(eventData);
    }

    public void OnDrag(PointerEventData data)
    {
        if (m_DraggingIcon != null)
            SetDraggedPosition(data);


        //Fades the icon when dragging.
        var image = m_DraggingIcon.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Exp(-3 * ((data.position.y / (Screen.height / 1.5f)))) );


        //Scaling
        //image.transform.localScale = Vector2.one * (1.0f-(data.position.y / (Screen.height)));

        //Raycast towards the land while dragging
        RaycastHit hit;
        Ray ray = Cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log("Hit");
            //Debug.DrawLine(ray.origin, hit.point,Color.red);
            _sphere.transform.position = hit.point;
        }
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            m_DraggingPlane = data.pointerEnter.transform as RectTransform;

        var rt = m_DraggingIcon.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = m_DraggingPlane.rotation;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (m_DraggingIcon != null)
            Destroy(m_DraggingIcon);
    }

    static public T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }
}