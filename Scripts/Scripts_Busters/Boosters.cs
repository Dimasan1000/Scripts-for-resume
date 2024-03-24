using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Boosters : MonoBehaviour
{
    public GameObject _softCurency;
    public GameObject _boosters;
    public Struct_Busters _busterUnlimited;
    [SerializeField] private Counter _payBuster;
    public GameObject _buyBuster;
    [SerializeField] private Imission_Tab_shop _TabShop;
    [SerializeField] private Metods_boosters _manageBoost;
    [SerializeField] private TextMeshProUGUI _prise;
    [SerializeField] private GameObject[] ButtonBuy;

    [SerializeField] private Image _busterImage;

    [SerializeField] private string[] _valUnTtext;
    [SerializeField] private TextMeshProUGUI _BustUnT;
    [SerializeField] private string[] _valtextDuration;
    [SerializeField] private TextMeshProUGUI _textDuration;
    [SerializeField] private Sprite[] _iconBoost;


    public void ChoiseBuster(int B)
    {
        _manageBoost._soundBuster.SoundB();
        _manageBoost._boostCount = B;
        _manageBoost.boostModul = 1;
        _prise.text = "300";
        for (int i = 0; i < _boosters.transform.GetChild(0).childCount; i++)
        {
            _boosters.transform.GetChild(1).GetChild(i).GetComponent<Image>().color = Color.white;
        }
        _boosters.transform.GetChild(1).GetChild(B).GetComponent<Image>().color = Color.blue;
        if (B == 0)
        {
            _busterImage.rectTransform.sizeDelta = new Vector2(350, 290);
        }
        else
            _busterImage.rectTransform.sizeDelta = new Vector2(350, 290);
        _busterImage.sprite = _iconBoost[B];
        _BustUnT.text = _valUnTtext[B];
        _textDuration.text = _valtextDuration[B];

    }
    public void BayBuster(int num)
    {
        
        if (_payBuster._countCoin >= 300)//
        {
            _payBuster._soundPlay.SoundB();//звук успешной покупки.
            _payBuster._countCoin -= 300;
            _TabShop.Check(2,true, 300, false);
            _payBuster._coins.text = _payBuster._coinsToMenu.text = _payBuster._countCoin.ToString();
            switch (num)
            {
                case 0:
                    _busterUnlimited._coin_2x += 1;
                    _manageBoost._SaveBoost._countsBusters[0].text=_busterUnlimited._coin_2x.ToString();
                    Debug.Log("2x" + _busterUnlimited._coin_2x);
                    _buyBuster.transform.GetChild(0).GetComponent<Button>().interactable=true;
                    _buyBuster.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = _iconBoost[0];

                    break;
                case 1:
                    _busterUnlimited._healthFour += 1;
                    _manageBoost._SaveBoost._countsBusters[1].text = _busterUnlimited._healthFour.ToString();
                    Debug.Log("oxyUnlimited" + _busterUnlimited._healthFour);
                    _buyBuster.transform.GetChild(1).GetComponent<Button>().interactable = true;
                    _buyBuster.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = _iconBoost[1];
                    break;
            }
            _manageBoost._saveB.test();
        }
        else if (_payBuster._countCoin < 300)
        {
           // _payBuster._soundPlay.SoundB();//звук проваленой покупки.
            _boosters.gameObject.SetActive(false);
            _softCurency.gameObject.SetActive(true);
            _TabShop.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
            _TabShop.OnImmission(1);
            _TabShop.Check(1,true,0, false);
            _TabShop.ShowPreview(2);
           // _TabShop.ReSiseContent("soft");
            ButtonBuy[0].gameObject.SetActive(false);
            ButtonBuy[1].gameObject.SetActive(true);
            _TabShop._priceM[2].SetActive(false);
            _TabShop._priceM[1].SetActive(true);
            _TabShop.ShowWinNotMoney("Not enough coins \n You are missing: \n"+ (300 - _payBuster._countCoin),false);

        }
    }
}
