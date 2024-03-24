using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class System_Skins : MonoBehaviour
{
    public Struct_skins _allSkins;
    public System_Skins _prefabSkin;
    public Change_Skins _changeSkin;
    public GameObject _SkinPers;
    public Counter _paySkin;
    public string _pathSkins;
    public string _pathSkinsDell;
    public string _nameFileSkins = "Skins.json";
    public string _nameFileSkinsDell = "Skins.json.meta";
    public Pattern_Skin _clicButton;
    public TextMeshProUGUI _textChoise;
    public TextMeshProUGUI _textUse;

    public void SystemS(int count, bool active, bool unActive, bool _notBuy, string nameParent)
    {
        switch (nameParent)
        {
            case "Pers":
                Pers(count, unActive,_notBuy, active);
                break;
            case "Head":
                Head(count, unActive, _notBuy, active);
                break;
            case "Tors":
                Tors(count, unActive, _notBuy, active);
                break;
            case "Legs":
                Legs(count, unActive, _notBuy, active);
                break;
            case "Back":
                Back(count, unActive, _notBuy, active);
                break;
        }
    }

    private void Pers(int countM, bool unActiveM, bool _notBuyM, bool activeM)
    {
        _allSkins._pers[countM]._unActive = unActiveM;
        _allSkins._pers[countM]._active = activeM;
        _allSkins._pers[countM]._notBuy = _notBuyM;
        Debug.Log("Pers");
    }
    private void Head(int countM, bool unActiveM, bool _notBuyM, bool activeM)
    {
        _allSkins._head[countM]._unActive = unActiveM;
        _allSkins._head[countM]._active = activeM;
        _allSkins._head[countM]._notBuy= _notBuyM;
        Debug.Log("Head");
    }
    private void Tors(int countM, bool unActiveM, bool _notBuyM, bool activeM)
    {
        _allSkins._tors[countM]._unActive = unActiveM;
        _allSkins._tors[countM]._active = activeM;
        _allSkins._tors[countM]._notBuy = _notBuyM;
        Debug.Log("Tors");
    }
    private void Legs(int countM, bool unActiveM, bool _notBuyM, bool activeM)
    {
        _allSkins._legs[countM]._unActive = unActiveM;
        _allSkins._legs[countM]._active = activeM;
        _allSkins._legs[countM]._notBuy = _notBuyM;
        Debug.Log("Legs");
    }
    private void Back(int countM, bool unActiveM, bool _notBuyM, bool activeM)
    {
        _allSkins._back[countM]._unActive = unActiveM;
        _allSkins._back[countM]._active = activeM;
        _allSkins._back[countM]._notBuy = _notBuyM;
        Debug.Log("Back");
    }

    #region

    public void SeveSystSkins()
    {
        SetPath();
        Struct_skins _skinsStr = new Struct_skins
        {
            boy_Girl = _changeSkin.boy_Girl,
            _pers = _allSkins._pers,
            _head = _allSkins._head,
            _tors = _allSkins._tors,
            _legs = _allSkins._legs,
            _back = _allSkins._back
        };
        string _jsonSk = JsonUtility.ToJson(_skinsStr, prettyPrint: true);
        File.WriteAllText(_pathSkins, contents: _jsonSk);
        //Debug.Log("SaveSKINS");
    }

    public void LoadFromFile()
    {
        SetPath();
        if (!File.Exists(_pathSkins))
        {
            return;
        }
        else
        {
            string _jsonSki = File.ReadAllText(_pathSkins);
            Struct_skins _SkinsFromJson = JsonUtility.FromJson<Struct_skins>(_jsonSki);
            _changeSkin.boy_Girl = _SkinsFromJson.boy_Girl;
            _allSkins._pers = _SkinsFromJson._pers;
            _allSkins._head = _SkinsFromJson._head;
            _allSkins._tors = _SkinsFromJson._tors;
            _allSkins._legs = _SkinsFromJson._legs;
            _allSkins._back = _SkinsFromJson._back;
            FindButtons();
            // Debug.Log("LOADSkins");
        }
    }

    #endregion
    public void FindButtons()
    {
        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    AplyButtons(_SkinPers.transform.GetChild(i).gameObject, _allSkins._pers);
                    break;
                case 1:
                    AplyButtons(_SkinPers.transform.GetChild(i).gameObject, _allSkins._head);
                    break;
                case 2:
                    AplyButtons(_SkinPers.transform.GetChild(i).gameObject, _allSkins._tors);
                    break;
                case 3:
                    AplyButtons(_SkinPers.transform.GetChild(i).gameObject, _allSkins._legs);
                    break;
                case 4:
                    AplyButtons(_SkinPers.transform.GetChild(i).gameObject, _allSkins._back);
                    break;
            }
        }
    }

    private void AplyButtons(GameObject test, BoolsSkins[] bools)
    {
        Pattern_Skin _childModul;
        for (int i = 0; i < test.transform.childCount; i++)
        {
            _childModul = test.transform.GetChild(i).gameObject.GetComponent<Pattern_Skin>();
            _childModul._systSkins = _prefabSkin;
            _childModul._changeColor = _changeSkin;
           // if (bools[i]._active == true || bools[i]._unActive == true)
            //{
                switch (bools[i]._active, bools[i]._unActive, bools[i]._notBuy)
                {
                    case (true, false,false):
                        _childModul.GetComponent<Pattern_Skin>().transform.GetComponent<Image>().color = _childModul.GetComponent<Pattern_Skin>()._colorButton[1];
                       
                        break;
                    case (false, true,false):
                        _childModul.GetComponent<Pattern_Skin>().transform.GetComponent<Image>().color = Color.white;
                        bools[i]._unActive = true;
                        break;
                    case (false, false, false):
                        bools[i]._notBuy = true;
                        Debug.Log(i );
                        break;
                }
                _childModul._active = bools[i]._active;
                _childModul._unActive = bools[i]._unActive;
                _childModul._notBuy= bools[i]._notBuy;
                if (test.name == "Pers" && _childModul._active == true && _childModul._unActive == false)
                {
                    _changeSkin.ChangeGender(_childModul.gameObject.transform.GetSiblingIndex());
                }
                if (_childModul._active == true && test.name != "Pers")
                {
                    if (test.name == "Head")
                    {
                        //Debug.Log("ColorHead");
                        _changeSkin.ChangeColor(_changeSkin._colorHead[i], test.name);
                    }
                    else
                    {
                        //Debug.Log("Color");
                        _changeSkin.ChangeColor(_changeSkin._colorSoot[i], test.name);
                    }
                }
           // }
        }
    }

    public void BayAndUse()
    {
        if (_clicButton.gameObject.transform.parent.name == "Pers")
        {
            _changeSkin.ChangeGender(_clicButton.transform.GetSiblingIndex());
            _clicButton.ClicButton(_clicButton.gameObject, _clicButton._priceTors[_clicButton.transform.GetSiblingIndex()]);
        }
        else
            if (_clicButton.gameObject.transform.parent.name == "Head")
        {
            _clicButton.ClicButton(_clicButton.gameObject, _clicButton._priceHead[_clicButton.transform.GetSiblingIndex()]);
            
        }
        else
            _clicButton.ClicButton(_clicButton.gameObject, _clicButton._priceTors[_clicButton.transform.GetSiblingIndex()]);
    }

    public void SetPath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _pathSkins = Path.Combine(Application.persistentDataPath, _nameFileSkins);
        _pathSkinsDell = Path.Combine(Application.persistentDataPath, _nameFileSkinsDell); 
#else
        _pathSkins = Path.Combine(Application.dataPath, _nameFileSkins);
        _pathSkinsDell = Path.Combine(Application.dataPath, _nameFileSkinsDell);
#endif
    }
}

