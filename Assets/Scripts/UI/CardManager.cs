using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> _CardImages;
    [SerializeField]
    private Sprite _ReverseCard;
    private Image[] _Cards;
    public float _CardCooldown = 2.0f;
    List<int> idx;
    // Start is called before the first frame update
    void Start()
    {
        _Cards = GetComponentsInChildren<Image>();
        int randomIdx;
        idx = new List<int>();
        for (int i = 0; i < 2; ++i)
        {
            do
            {
                randomIdx = Random.Range(0, _Cards.Length);

            } while (idx.Contains(randomIdx));
            idx.Add(randomIdx);
        }

        foreach (int i in idx)
        {
            int randCard = Random.Range(0, _CardImages.Count);
            _Cards[i].sprite = _CardImages[randCard];
            _Cards[i].name = _CardImages[randCard].name;
        }
        for (int i = 0; i < _Cards.Length; ++i)
        {
            if (idx.Contains(i) == false)
                _Cards[i].sprite = _ReverseCard;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _CardCooldown -= Time.deltaTime;
        if (_CardCooldown <= 0)
        {
            for (int i = 0; i < _Cards.Length; ++i)
            {
                if (idx.Contains(i) == false)
                {
                    int randCard = Random.Range(0, _CardImages.Count);
                    idx.Add(i);
                    _Cards[i].sprite = _CardImages[randCard];
                    _Cards[i].name = _CardImages[randCard].name;
                    _CardCooldown = 2;
                    break;
                }

            }
        }
    }

    public void RemoveCard(string cardName)
    {
        for (int i = 0; i < _Cards.Length; ++i)
        {
            if (_Cards[i].name == cardName)
            {
                _Cards[i].sprite = _ReverseCard;
                _Cards[i].name = "ReverseCard";
                idx.Remove(i);
                _CardCooldown = 2;

            }
        }
    }

    public void RemoveRandomCard()
    {
        int randCard;

        do
        {
            randCard = Random.Range(0, _Cards.Length);

        } while (_Cards[randCard].name == "ReverseCard");
        if (_Cards[randCard].name != "ReverseCard")
        {
            _Cards[randCard].sprite = _ReverseCard;
            _Cards[randCard].name = "ReverseCard";
            idx.Remove(randCard);
            _CardCooldown = 2;
        }

    }
}
