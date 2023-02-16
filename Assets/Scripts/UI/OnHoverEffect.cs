using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverEffect : MonoBehaviour
{
    private float _basePositionY;
    private Vector3 _baseScale;
    private RectTransform _picture;
    private bool _Selected;
    public float _CardScale = 2;
    public bool _IsSelected
    {
        get { return _Selected; }
        set { _Selected = value; }
    }

    private void Start()
    {
        _picture = gameObject.GetComponent<RectTransform>();
        _basePositionY = _picture.anchoredPosition.y;
        _baseScale = _picture.localScale;
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
    public void ScaleUp()
    {
        _picture.localScale = new Vector3(_picture.localScale.x * _CardScale, _picture.localScale.y * _CardScale, _picture.localScale.z * _CardScale);

    }
    public void ScaleDown()
    {
        _picture.localScale = _baseScale;

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
