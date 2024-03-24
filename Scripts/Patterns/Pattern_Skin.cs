using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEditor.PackageManager;


public class Pattern_Skin : MonoBehaviour
{
    public GameObject _softCurency;
    [SerializeField] private Imission_Tab_shop _TabShop;
    [SerializeField] private GameObject _tabSkins;
    public bool _active;
    public bool _unActive;
    public bool _notBuy;
    private int _child;
    public Color[] _colorButton;
    [SerializeField] private Logic_Tasks _logicT;
    public System_Skins _systSkins;
    public Change_Skins _changeColor;
    [SerializeField] private GameObject[] _buttonBuy;
    [SerializeField] private GameObject _notvalMoney;
    public int[] _priceHead;
    public int[] _priceTors;

    public void Start()
    {
        _systSkins = GameObject.FindWithTag("ShopButton").GetComponent<System_Skins>();
        _changeColor = GameObject.FindWithTag("Player").GetComponent<Change_Skins>();

    }

    public void HowButton()
    {
        _changeColor._clik.SoundB();
        GameObject parent = transform.parent.gameObject;
        _systSkins._clicButton = this;
        switch (parent.name)
        {
            case "Pers":
                _child = transform.GetSiblingIndex();
                PreviewSkins();
                SetChoiseText("Free");
                break;
            case "Head":
                _child = transform.GetSiblingIndex();
                PreviewSkins();
                SetChoiseText(_priceHead[_child].ToString());
                break;
            case "Tors":
                _child = transform.GetSiblingIndex();
                PreviewSkins();
                SetChoiseText(_priceTors[_child].ToString());
                break;
            case "Legs":
                _child = transform.GetSiblingIndex();
                PreviewSkins();
                SetChoiseText(_priceTors[_child].ToString());
                break;
            case "Back":
                _child = transform.GetSiblingIndex();
                PreviewSkins();
                SetChoiseText(_priceTors[_child].ToString());
                break;
        }
        for(int i=0; i < this.transform.parent.transform.childCount; i++)
        {
            if(this.transform.parent.GetChild(i).GetComponent<Pattern_Skin>()._active == false)
            this.transform.parent.GetChild(i).GetComponent<Image>().color = Color.white;
        }
        if(this._active == false)
        this.GetComponent<Image>().color = Color.blue;

    }
    private void SetChoiseText(string textPrice)
    {
        if (_notBuy==true)
        {
            _systSkins._textChoise.gameObject.SetActive(true);
            _systSkins._textChoise.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            _systSkins._textChoise.text = textPrice;
            _systSkins._textUse.text = "Buy";
        }
        else if (_unActive == true)
        {
            _systSkins._textChoise.text ="Unuse";
            _systSkins._textChoise.gameObject.SetActive(true);
            _systSkins._textChoise.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            _systSkins._textUse.text = "Use";
        }
        else if(_active == true)
        {
            _systSkins._textChoise.gameObject.SetActive(false);

            _systSkins._textUse.text = "In use";
        }
    }

    public void ClicButton(GameObject clicBt,int clBT)
    {
        
        switch (_active, _notBuy)
        {
            case (false, true)://???????
                if (_systSkins._paySkin._countCoin >= clBT)
                {
                    _logicT.ChangeOneSkin(4);
                    _changeColor._clik.SoundB();//Звук успешной покупки.
                    _systSkins._textChoise.text ="Unuse";
                    _systSkins._textUse.text = "Use";
                    _systSkins._textChoise.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    _notBuy=false;
                    _active = true;
                    _systSkins.SystemS(transform.GetSiblingIndex(), _active, _unActive,_notBuy, clicBt.transform.parent.name);
                    _systSkins._paySkin._countCoin -= clBT;//Pay
                    _TabShop.Check(2,true, clBT, false);
                    _systSkins._paySkin._coinsToMenu.text = _systSkins._paySkin._coins.text = _systSkins._paySkin._countCoin.ToString();
                    _changeColor._logTask.CountSkin();
                    _changeColor._progress.CountSkin(clicBt.transform.parent.name);
                    ChangeColorSkin(clicBt);
                }
                else if (_systSkins._paySkin._countCoin < clBT)
                {
                    _changeColor._clik.SoundB();//Звук проваленой покупки.
                    clicBt.transform.parent.parent.gameObject.SetActive(false);
                    _tabSkins.gameObject.SetActive(false);
                    _softCurency.gameObject.SetActive(true);
                    _buttonBuy[0].SetActive(false);
                    _buttonBuy[1].SetActive(true);
                    _TabShop.OnImmission(1);
                    _TabShop.Check(1,true,0, false);
                    _TabShop.ReSiseContent("soft");
                    _TabShop.ShowPreview(2);
                    _TabShop._priceM[2].SetActive(false);
                    _TabShop._priceM[1].SetActive(true);
                    _TabShop.ShowWinNotMoney("Not enough coins \n You are missing: \n" + (clBT - _systSkins._paySkin._countCoin),false);

                }
                break;
            case (false, false)://?????????????
                ChangeColorSkin(clicBt);
                Debug.Log(_active);
                break;
        }
        Debug.Log(_active);
    }
    public void ChangeColorSkin(GameObject clicBt)
    {
        Debug.Log(_active+"   2");
        _systSkins._textUse.text = "In use";
        _systSkins._textChoise.gameObject.SetActive(false);
        for (int i = 0; i < clicBt.transform.parent.childCount; i++)
        {
            Pattern_Skin test = clicBt.transform.parent.GetChild(i).GetComponent<Pattern_Skin>();
            if (test._active == true || test._unActive == true)
            {
                test._active = false;
                test._unActive = true;
                
                Debug.Log(i+"Проход по кнопкам " + clicBt.transform.parent.name);
                test.GetComponent<Image>().color = Color.white;
                _systSkins.SystemS(i, test._active, test._unActive, test._notBuy, clicBt.transform.parent.name);
            }
            if (test._notBuy == true)
            {
                _systSkins.SystemS(i, test._active, test._unActive, test._notBuy, clicBt.transform.parent.name);

            }
        }
        _active = true;
        _unActive = false;
        Debug.Log(_active);
        _systSkins.SystemS(transform.GetSiblingIndex(), _active, _unActive, _notBuy, clicBt.transform.parent.name);
        this.GetComponent<Image>().color = _colorButton[1];
        if (clicBt.transform.parent.name == "Pers")
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (clicBt.transform.parent.name != "Pers" && _active == true)
        {
            _changeColor._logTask.ChangeOneSkin(4);

        }
        if (clicBt.transform.parent.name == "Head")
        {
            _changeColor.ChangeColor(_changeColor._colorHead[transform.GetSiblingIndex()], clicBt.transform.parent.name);
        }
        else
        {
            _changeColor.ChangeColor(_changeColor._colorSoot[transform.GetSiblingIndex()], clicBt.transform.parent.name);
        }

    }
    public void PreviewSkins() 
    {
        if (transform.parent.name == "Pers")
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (transform.parent.name == "Head")
        {
            _changeColor.ChangeColor(_changeColor._colorHead[transform.GetSiblingIndex()],transform.parent.name);
        }
        else
        {
            _changeColor.ChangeColor(_changeColor._colorSoot[transform.GetSiblingIndex()],transform.parent.name);
        }
    }
}