using Facebook.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bay_Currency : MonoBehaviour
{
    [SerializeField] private GameObject _buttonSoft;
    [SerializeField] private GameObject _buttonHard;
    [SerializeField] private Counter _counCurrensy;
    [SerializeField] private Imission_Tab_shop _TabShop;
    public int _numSoft;
    [SerializeField] private TextMeshProUGUI _priseSoft;
    [SerializeField] private GameObject[] _buttonBuyCurency;
    [SerializeField] private GameObject[] _PreviewShop;
    [SerializeField] private Sprite[] _iconSoft;
    [SerializeField] private Image _softImage;
    [SerializeField] private string[] _valSofttext;
    [SerializeField] private TextMeshProUGUI _Soft;
   

    public void BaySoft(int indexS)
    {
    
         _numSoft = indexS;
        TextPriceSoft();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).GetComponent<Image>().color = Color.white;
        }
        this.transform.GetChild(indexS).GetComponent<Image>().color = Color.blue;
        _Soft.text = _valSofttext[indexS];
        _softImage.sprite = _iconSoft[indexS];
        _counCurrensy._cristalMenu.text = _counCurrensy._countCristal.ToString();
        _counCurrensy._coins.text = _counCurrensy._coinsToMenu.text = _counCurrensy._countCoin.ToString();
    }
    private void OfferPurchaseHard(int prise)
    {
        _counCurrensy._soundPlay.SoundB();//звук проваленой покупки
        _buttonSoft.SetActive(false);
        _buttonHard.SetActive(true);
        _buttonBuyCurency[0].SetActive(false);
        _buttonBuyCurency[1].SetActive(true);
        _TabShop.ShowPreview(3);
        _TabShop.OnImmission(0);//
        _TabShop.Check(1,false,0, true);
        _TabShop.ReSiseContent("hard");
        _TabShop._priceM[1].SetActive(false);
        _TabShop._priceM[0].SetActive(true);
        _TabShop.ShowWinNotMoney("Not enough crystals \n You are missing: \n"+ (prise- _counCurrensy._countCristal),true);
    }
    private void TextCounter(int price)
    {
        _counCurrensy._soundPlay.SoundB();//звук успешной покупки
        _TabShop._checkText = false;
        _TabShop.Check(2,false,price, true);
    }
    public void PriseSoft()
    {
        switch (_numSoft)
        {
            case 0:
                if (_counCurrensy._countCristal >= 60)
                {
                    _counCurrensy._countCristal -= 60;
                    _counCurrensy._countCoin += 250;
                    TextCounter(60);
                }
                else if(_counCurrensy._countCristal < 60)
                {
                    OfferPurchaseHard(60);
                }
                break;
            case 1:
                if (_counCurrensy._countCristal >= 100)
                {
                    _counCurrensy._countCristal -= 100;
                    _counCurrensy._countCoin += 500;
                    TextCounter(100);
                }
                else if (_counCurrensy._countCristal < 100)
                {
                    OfferPurchaseHard(100);
                }
                break;
            case 2:
                if (_counCurrensy._countCristal >= 180)
                {
                    _counCurrensy._countCristal -= 180;
                    _counCurrensy._countCoin += 1000;
                    TextCounter(180);
                }
                else if (_counCurrensy._countCristal < 180)
                {
                    OfferPurchaseHard(180);
                }
                break;
            case 3:
                if (_counCurrensy._countCristal >= 210)
                {
                    _counCurrensy._countCristal -= 210;
                    _counCurrensy._countCoin += 3000;
                    TextCounter(210);
                }
                else if (_counCurrensy._countCristal < 210)
                {
                    OfferPurchaseHard(210);
                }
                break;
            case 4:
                if (_counCurrensy._countCristal >= 600)
                {
                    _counCurrensy._countCristal -= 600;
                    _counCurrensy._countCoin += 10000;
                    TextCounter(600);
                }
                else if (_counCurrensy._countCristal < 600)
                {
                    OfferPurchaseHard(600);
                }
                break;
            case 5:
                if (_counCurrensy._countCristal >= 1500)
                {
                    _counCurrensy._countCristal -= 1500;
                    _counCurrensy._countCoin += 50000;
                    TextCounter(1500);
                }
                else if (_counCurrensy._countCristal < 1500)
                {
                    OfferPurchaseHard(1500);
                }
                break;
        }
        _counCurrensy._cristalMenu.text = _counCurrensy._countCristal.ToString();
        _counCurrensy._coins.text = _counCurrensy._coinsToMenu.text = _counCurrensy._countCoin.ToString();
    }

    private void TextPriceSoft()
    {
        switch (_numSoft)
        {
            case 0:
                _priseSoft.text = "60";
                break;
            case 1:
                _priseSoft.text = "100";
                break;
            case 2:
                _priseSoft.text = "180";
                break;
            case 3:
                _priseSoft.text = "210";
                break;
            case 4:
                _priseSoft.text = "600";
                break;
            case 5:
                _priseSoft.text = "1500";
                break;

        }
    }
}
