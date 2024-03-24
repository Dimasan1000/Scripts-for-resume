using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boosters_Time : MonoBehaviour
{
    public GameObject _softCurency;
    public GameObject _boosters;
    public Struct_BustersLimit _busterlimit;
    [SerializeField] private Counter _payBuster;
    public GameObject _buyBusterLim;
    [SerializeField] private Imission_Tab_shop _TabShop;
    [SerializeField] private Metods_boosters _manageBoost;
    [SerializeField] private TextMeshProUGUI _prise;
    [SerializeField] private GameObject[] ButtonBuy;

    [SerializeField] private Image _busterImage;
    
    [SerializeField] private string[]_valTimetext;
    [SerializeField] private TextMeshProUGUI _BustTime;
    [SerializeField] private string[] _valtextDuration;
    [SerializeField] private TextMeshProUGUI _textDuration;
    [SerializeField] private Sprite[] _iconBoost;


    public void ChoiseBusterTime(int BTime)
    {
        _manageBoost._soundBuster.SoundB();
        _manageBoost._boostCount = BTime;
        _manageBoost.boostModul = 2;
        _prise.text = "300";
        for (int i = 0; i < _boosters.transform.GetChild(0).childCount; i++)
        {
            _boosters.transform.GetChild(0).GetChild(i).GetComponent<Image>().color = Color.white;
        }
        _boosters.transform.GetChild(0).GetChild(BTime).GetComponent<Image>().color = Color.blue;
        if(BTime ==0) 
        {
            _busterImage.rectTransform.sizeDelta = new Vector2(280, 350);
        }
        else
        _busterImage.rectTransform.sizeDelta=new Vector2 (300, 350);
        _busterImage.sprite = _iconBoost[BTime];
        _BustTime.text = _valTimetext[BTime];
        _textDuration.text = _valtextDuration[BTime];


    }
    public void BayBusterLim(int num)
    {
       
        if (_payBuster._countCoin >= 300)
        {
            _payBuster._soundPlay.SoundB();
            _payBuster._countCoin -= 300;
            _TabShop.Check(2,true, 300, false);
            _payBuster._coins.text = _payBuster._coinsToMenu.text = _payBuster._countCoin.ToString();
            switch (num)
            {
                case 0:
                    _busterlimit._oxyUnlimit += 1;
                    _manageBoost._SaveBoost._countsBusters[0].text = _busterlimit._oxyUnlimit.ToString();
                    Debug.Log("oxylimit" + _busterlimit._oxyUnlimit);
                    _buyBusterLim.transform.GetChild(3).GetComponent<Button>().interactable = true;
                    _buyBusterLim.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = _iconBoost[0];
                    break;
                case 1:
                    _busterlimit._unlimitLives += 1;
                    _manageBoost._SaveBoost._countsBusters[0].text = _busterlimit._unlimitLives.ToString();
                    Debug.Log("healthLimit" + _busterlimit._unlimitLives);
                    _buyBusterLim.transform.GetChild(4).GetComponent<Button>().interactable = true;
                    _buyBusterLim.transform.GetChild(4).GetChild(0).GetComponent<Image>().sprite = _iconBoost[1];
                    break;
            }
            _manageBoost._saveB.test();
        }
        else if (_payBuster._countCoin < 300)
        {
            _boosters.gameObject.SetActive(false);
            _softCurency.gameObject.SetActive(true);
            _TabShop.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
            _TabShop.OnImmission(1);
            _TabShop.Check(1,true,0, false);
            _TabShop.ShowPreview(2);
            ButtonBuy[0].gameObject.SetActive(false);
            ButtonBuy[1].gameObject.SetActive(true);
            _TabShop._priceM[2].SetActive(false);
            _TabShop._priceM[1].SetActive(true);
            
            _TabShop.ShowWinNotMoney("Not enough coins \n You are missing: \n" + (300 - _payBuster._countCoin),false);
        }
    }

}
