using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Net.Http.Headers;

public class Imission_Tab_shop : MonoBehaviour
{
    [SerializeField] private GameObject _colorCounterCoin;
    [SerializeField] private GameObject _colorCounterDiamond;
    [SerializeField] private GameObject[] _textMinus;
    public float[] _posY; 
    [SerializeField] private GameObject _imissionTabShop;
    [SerializeField] private Color[] _colorUI;
    [SerializeField] private Sprite[] _imageActive;
    [SerializeField] private Sprite[] _imageUnActive;
    [SerializeField] private Sprite[] _imageAcModuls;
    [SerializeField] private Sprite[] _imageUnAcModuls;
    public bool _check1=false;
    public bool _check2=false;
    public bool _chooseCounter=false;
    public bool[] flagcolor;
    public bool _checkText = false;
    public float timer=0.2f;
    private int _priceText;
    [SerializeField] private Counter _counters;
    [SerializeField] private TextMeshProUGUI _textCoin;
    [SerializeField] private TextMeshProUGUI _textCristal;
    [SerializeField] private RectTransform _content;
    [SerializeField] private GameObject _pers;
    [SerializeField] private GameObject[] _previewShopTab;
    [SerializeField] private GameObject[] _modul;
    public GameObject[] _priceM;
    public System_Skins _applyButton;
    [SerializeField] private GameObject _notvalMpney;
    [SerializeField] private Sprite[] _iconCurency;
    [SerializeField] private Image _imageCurency;

    public void Start()
    {
        _posY[0] = _textMinus[0].transform.position.y-10;
        _posY[1] = _textMinus[1].transform.position.y-10;
    }
    public void Update()
    {
        if (_check1 == true)
        {
            ColorCounterCoin();
        }
        if (_check2==true)
        {
            TextCounterMinus(_checkText);
        }
        _textCoin.text=_counters._countCoin.ToString();
        _textCristal.text=_counters._countCristal.ToString();
    }
    public void ChangeTextButBuy(int applyNomber)
    {
        for (int i = 0; i < _applyButton._SkinPers.transform.GetChild(applyNomber).childCount; i++)
        {
            GameObject tempButton = _applyButton._SkinPers.transform.GetChild(applyNomber).GetChild(i).gameObject;
            if (tempButton.GetComponent<Pattern_Skin>()._active == true)
            {
                _applyButton._clicButton = tempButton.GetComponent<Pattern_Skin>();
                _priceM[2].gameObject.SetActive(false);
                _modul[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "In use";
            }
            else if(tempButton.GetComponent<Pattern_Skin>()._active == false)
            {
                tempButton.GetComponent<Image>().color =Color.white;
            }
        }
    }
    public void ShowPreview(int show)
    {
        for(int i=0; i < _previewShopTab.Length; i++)
        {
            _previewShopTab[i].SetActive(false);
        }
        _previewShopTab[show].SetActive(true);
        if (_applyButton._clicButton != null)
        {
            for (int j = 0; j< _applyButton._clicButton.transform.parent.childCount; j++)
            {
                if (_applyButton._clicButton.transform.parent.GetChild(j).GetComponent<Pattern_Skin>()._active == false)
                {
                    _applyButton._clicButton.transform.parent.GetChild(j).GetComponent<Image>().color = Color.white;
                }
            }
        }
    }

    public void OpenModulTabShop(int show)
    {
        for(int i = 0; i < _modul.Length; i++)
        {
            _modul[i].SetActive(false);
        }
        _modul[show].SetActive(true);
    }
    public void ShowPriceModul(int show)
    {
        for (int i = 0; i < _priceM.Length; i++)
        {
            _priceM[i].SetActive(false);
        }
        _priceM[show].SetActive(true);
        _priceM[show].transform.GetChild(0).gameObject.SetActive(true);
    }
    public void OnImmission(int nomButton)
    {
        for (int i = 0; i <= 3; i++)
        {
            _imissionTabShop.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = _imageUnActive[i];
            _content.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        _imissionTabShop.transform.GetChild(nomButton).transform.GetChild(0).GetComponent<Image>().sprite = _imageActive[nomButton];
        _content.gameObject.transform.GetChild(nomButton).gameObject.SetActive(true);
    }
    public void OnImmissionModuls(int butt)
    {
        for (int i = 1; i <= 5; i++)
        {
            _imissionTabShop.transform.GetChild(3).transform.GetChild(1).transform.GetChild(i).GetComponent<Image>().sprite = _imageUnAcModuls[i - 1];
        }
        _imissionTabShop.transform.GetChild(3).transform.GetChild(1).transform.GetChild(butt + 1).GetComponent<Image>().sprite = _imageAcModuls[butt];
    }

    public void Check(int c, bool currency,int price,bool counter)
    {
        if (c==1)
        {
            _chooseCounter = counter;
            _check1 = true;
        }
        if (c == 2)
        {
            _priceText = price;
            _checkText = currency;
            _check2 = true;
        }
    }
    public void TextCounterMinus(bool _checkText)
    {
        if (_checkText == true&& _textMinus[0].transform.position.y> _posY[0])
        {
            _textMinus[0].gameObject.SetActive(true);
            _textMinus[0].GetComponent<TextMeshProUGUI>().text = "-"+_priceText;
            _textMinus[0].transform.position = Vector3.Lerp(_textMinus[0].transform.position,
                new Vector3(_textMinus[0].transform.position.x, _posY[0], _textMinus[0].transform.position.z), 0.08f);
        }
        else if (_checkText == false&& _textMinus[1].transform.position.y > _posY[1])
        {
            _textMinus[1].gameObject.SetActive(true);
            _textMinus[1].GetComponent<TextMeshProUGUI>().text = "-"+_priceText;
            _textMinus[1].transform.position=Vector3.Lerp(_textMinus[1].transform.position,
                new Vector3(_textMinus[1].transform.position.x, _posY[1], _textMinus[1].transform.position.z),0.08f);
        }
        if (_textMinus[0].transform.position.y < _posY[0]+1 ||_textMinus[1].transform.position.y < _posY[1]+1)
        {
            _check2 = false;
            _textMinus[0].transform.position =new Vector3(_textMinus[0].transform.position.x, _posY[0] + 10, _textMinus[0].transform.position.z);
            _textMinus[1].transform.position = new Vector3(_textMinus[1].transform.position.x, _posY[1] + 10, _textMinus[1].transform.position.z);
            _textMinus[0].gameObject.SetActive(false); 
            _textMinus[1].gameObject.SetActive(false);
        }   
    }

    public void ColorCounterCoin()
    {
        GameObject _colorCounter = null; ;
        if (_chooseCounter == false)
        {
            _colorCounter = _colorCounterCoin;
        }
        else if (_chooseCounter == true)
        {
            _colorCounter = _colorCounterDiamond;
        }
        timer -= Time.deltaTime;
        if (_colorCounter.GetComponent<Image>().color!= _colorUI[1] && flagcolor[0]==false)
        {
            if (timer < 0)
            {
                _colorCounter.GetComponent<Image>().color = Color.Lerp(_colorCounter.GetComponent<Image>().color, _colorUI[1], 0.4f);
                timer = 0.01f;
            }
            if (_colorCounter.GetComponent<Image>().color == _colorUI[1] && flagcolor[0] == false)
            {
                flagcolor[0] = true;
                timer = 0.3f;
            }
        }
        else  if(_colorCounter.GetComponent<Image>().color != _colorUI[2] && flagcolor[1] == false)
        {
            if (timer < 0)
            {
                _colorCounter.GetComponent<Image>().color = Color.Lerp(_colorCounter.GetComponent<Image>().color, _colorUI[2], 0.4f);
                timer = 0.02f;
            }
            if (_colorCounter.GetComponent<Image>().color == _colorUI[2] && flagcolor[1] == false)
            {
                flagcolor[1] = true;
            }
        }
        else if (flagcolor[0] == true && flagcolor[1] == true)
        {
            _check1 = flagcolor[0] = flagcolor[1] = false;
        }
    }

    public void ReSiseContent(string nameTabShop)
    {

        switch (nameTabShop)
        {
            case "hard":
                _content.sizeDelta =new Vector2(950, _content.sizeDelta.y);
                _content.localPosition = new Vector3(0, _content.localPosition.y, _content.localPosition.z);
                break;
            case "soft":
                _content.sizeDelta = new Vector2(950, _content.sizeDelta.y);
                _content.localPosition = new Vector3(0, _content.localPosition.y, _content.localPosition.z);
                break;
            case "boosters":
                _content.sizeDelta = new Vector2(700, _content.sizeDelta.y);
                _content.localPosition = new Vector3(0, _content.localPosition.y, _content.localPosition.z);
                break;
            case "skin":
                if (_pers.activeSelf==false)
                {
                    _content.sizeDelta = new Vector2(1400, _content.sizeDelta.y);
                    _content.localPosition = new Vector3(0, _content.localPosition.y, _content.localPosition.z);
                }
                else
                _content.sizeDelta = new Vector2(950, _content.sizeDelta.y);
                _content.localPosition = new Vector3(0, _content.localPosition.y, _content.localPosition.z);
                break;
            case "pers":
                _content.sizeDelta = new Vector2(950, _content.sizeDelta.y);
                _content.localPosition = new Vector3(0, _content.localPosition.y, _content.localPosition.z);
                break;
            case "skins":
                _content.sizeDelta = new Vector2(1400, _content.sizeDelta.y);
                _content.localPosition = new Vector3(0, _content.localPosition.y, _content.localPosition.z);
                break;
        }
    }

    public void ShowWinNotMoney(string _textCurrency,bool Hard_Soft)
    {
        _notvalMpney.SetActive(true);
        _notvalMpney.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _textCurrency;
        if( Hard_Soft == true)
        {
            _imageCurency.sprite = _iconCurency[0];
            _imageCurency.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 70);
        }
        else if( Hard_Soft == false) 
        {
            _imageCurency.sprite = _iconCurency[1];
            _imageCurency.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 88);
        }
    }
}
