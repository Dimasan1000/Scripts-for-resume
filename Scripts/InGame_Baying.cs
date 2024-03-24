using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using TMPro;

public class InGame_Baying : MonoBehaviour
{
    
    [SerializeField] private Counter _counCurrensy;
    [SerializeField] private Logic_Progress _mecenat;
    [SerializeField] private GameObject _buttonHard;
    [SerializeField] private Sprite[] _iconHard;
    [SerializeField] private Image _hardImage;
    [SerializeField] private string[] _priceHardtext;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private string[] _valHardtext;
    [SerializeField] private TextMeshProUGUI _Hard;

    public void ChoiseValHard(string nameVal)
    {
        _buttonHard.GetComponent<IAPButton>().productId= nameVal;

    }

    public void ColorHardGoise(int buttonH)
    {
        _counCurrensy._soundPlay.SoundB();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).GetComponent<Image>().color = Color.white;
        }
        this.transform.GetChild(buttonH).GetComponent<Image>().color = Color.blue;
        _Hard.text = _valHardtext[buttonH];
        _priceText.text = _priceHardtext[buttonH];
        _hardImage.sprite = _iconHard[buttonH];
        //цены за хард
    }

    public void OnPurchaseComplete(Product product)
    {
        _counCurrensy._soundPlay.SoundB();//звук успешной покупки.
        Debug.Log(_counCurrensy._countCristal);
        switch (product.definition.id)
        {

            case "200_gems":
                _counCurrensy._countCristal += 200;
                _mecenat.Mecenat(1, 28);
                _counCurrensy._cristalMenu.text = _counCurrensy._countCristal.ToString();
                break;
            case "500_gems":
                _counCurrensy._countCristal += 500;
                _mecenat.Mecenat(1, 28);
                _counCurrensy._cristalMenu.text = _counCurrensy._countCristal.ToString();
                break;
            case "1000_gems":
                _counCurrensy._countCristal += 1000;
                _mecenat.Mecenat(1, 28);
                _counCurrensy._cristalMenu.text = _counCurrensy._countCristal.ToString();
                break;
            case "3000_gems":
                _counCurrensy._countCristal += 3000;
                _mecenat.Mecenat(1, 28);
                _counCurrensy._cristalMenu.text = _counCurrensy._countCristal.ToString();
                break;
            case "10000_gems":
                _counCurrensy._countCristal += 10000;
                _mecenat.Mecenat(1, 28);
                _counCurrensy._cristalMenu.text = _counCurrensy._countCristal.ToString();
                break;
            case "50000_gems":
                _counCurrensy._countCristal += 50000;
                _mecenat.Mecenat(1, 28);
                _counCurrensy._cristalMenu.text = _counCurrensy._countCristal.ToString();
                break;
        }
        _counCurrensy._cristalMenu.text = _counCurrensy._countCristal.ToString();
    }

   
    public void OnPurchaseFailure(Product product, PurchaseFailureReason failureDescription)//неправильно второй параметр неверен
    {
        _counCurrensy._soundPlay.SoundB();//звук проваленой покупки
        Debug.Log(_counCurrensy._countCristal);
        Debug.Log("Purchaseproduct " + product.definition.id + " Failure becuse " + failureDescription);
    }
}
