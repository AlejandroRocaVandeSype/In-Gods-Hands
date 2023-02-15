using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverEffect : MonoBehaviour
{
    private float _basePositionY;
    private RectTransform _picture;
    private bool _Selected;
    public bool _IsSelected
    {
        get { return _Selected; }
        set { _Selected = value; }
    }

    private void Start()
    {
        _picture = gameObject.GetComponent<RectTransform>();
        _basePositionY = _picture.anchoredPosition.y;
    }
    //public void OnPointerEnter(PointerEventData eventData)
    //{

    //    Debug.Log("PointerEnter");
    //    _picture.anchoredPosition = new Vector2(_picture.anchoredPosition.x, _basePositionY + 20);
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    Debug.Log("PointerExit");

    //    _picture.anchoredPosition = new Vector2(_picture.anchoredPosition.x, _basePositionY);
    //}
    public void MoveUp()
    {
        _picture.anchoredPosition = new Vector2(_picture.anchoredPosition.x, _basePositionY + 20);
    }
    public void MoveDown()
    {
        _picture.anchoredPosition = new Vector2(_picture.anchoredPosition.x, _basePositionY);
    }

    //void Update()
    //{
    //    if (_Selected)
    //    {
    //        _picture.anchoredPosition = new Vector2(_picture.anchoredPosition.x, _basePositionY + 20);
    //    }
    //    else
    //    {
    //        _picture.anchoredPosition = new Vector2(_picture.anchoredPosition.x, _basePositionY);

    //    }

    //}
}
