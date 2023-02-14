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
         _picture = GetComponent<RectTransform>();
        _basePositionY = _picture.position.y;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _picture.anchoredPosition = new Vector2(_picture.anchoredPosition.x, _basePositionY+20);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _picture.anchoredPosition = new Vector2(_picture.anchoredPosition.x, _basePositionY);
    }
}
