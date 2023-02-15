using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float _basePositionY;
    private RectTransform _picture;
    private void Start()
    {
         _picture = gameObject.GetComponent<RectTransform>();
        _basePositionY = _picture.anchoredPosition.y;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
       
        Debug.Log("PointerEnter");
        _picture.anchoredPosition = new Vector2(_picture.anchoredPosition.x, _basePositionY+20);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("PointerExit");

        _picture.anchoredPosition = new Vector2(_picture.anchoredPosition.x, _basePositionY);
    }
}
