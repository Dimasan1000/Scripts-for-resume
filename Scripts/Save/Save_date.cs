using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using AppodealAds.Unity.Api;

public class Save_date : MonoBehaviour
{
    [SerializeField] private string _date;
    [SerializeField] private AppodealManag _ads;
    [SerializeField] private DateTime _dateSave;
    [SerializeField] private GameObject _plashBonusDay;
    [SerializeField] private Counter _countVal;
    [SerializeField] private Image[] _getBonus;
    [SerializeField] private Sprite _setCheck;
    [SerializeField] private Sprite _amission;
    [SerializeField] private Sprite _iconNative;
    private string _dayB;
    public int _dayBonus;
    public int _timeDay;
    [SerializeField] private int[] _valBonus;
    public float[] _posY;
    [SerializeField] private GameObject[] _textPlus;
    [SerializeField] private TextMeshProUGUI[] _priceText;
    [SerializeField] private bool[] _flag;
    [SerializeField] private GameObject _textBackUp;

    public void Start()
    {
        _posY[0] = _textPlus[0].transform.position.y + 20;
        _posY[1] = _textPlus[1].transform.position.y + 20;
        if (PlayerPrefs.HasKey("CountDay") == true)
            _dayBonus = Convert.ToInt32(PlayerPrefs.GetString("CountDay"));
        _date = Convert.ToString(DateTime.UtcNow);
        if (_dayBonus < 1)
        {
            _textBackUp.SetActive(false);
        }
        else if (_dayBonus > 0)
        {
            _textBackUp.SetActive(true);
        }
        if (PlayerPrefs.HasKey("DayBonus") == false)
        {
            Bonus_everyDay();
        }
        else
        {
            GetDays();
        }
    }
    public void Update()
    {
        if (_flag[0] == true)
        {
            TextEverydayBonesPlus();
        }
    }
    public void DayInWeek()
    {
        if (PlayerPrefs.HasKey("CountDay") == true)
        _dayBonus = Convert.ToInt32(PlayerPrefs.GetString("CountDay"));
        for (int i = 0; i < _dayBonus; i++)
        {
            _getBonus[i].sprite = _setCheck;
            _getBonus[i].transform.GetChild(0).gameObject.SetActive(false);
            _getBonus[i].rectTransform.sizeDelta = new Vector2(150 , 150);
        }
        for (int j = _dayBonus; j < _getBonus.Length; j++)
        {
            if (j == _dayBonus)
            {
                _getBonus[_dayBonus].sprite = _amission;
                _getBonus[_dayBonus].transform.GetChild(0).gameObject.SetActive(true);
                _getBonus[_dayBonus].rectTransform.sizeDelta = new Vector2(200, 200);
            }
            else
            {
                _getBonus[j].sprite = _iconNative;
                _getBonus[j].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    public void SetDayInWeekOut()
    {
        if (_dayBonus == 7)
        {
            _dayBonus = 0;
            _dayB = _dayBonus.ToString();
            PlayerPrefs.SetString("CountDay", _dayB);
        }
    }
    public void SetDayInWeek()
    {
        if (_dayBonus<7)
        {
            _dayBonus++;
            _dayB = _dayBonus.ToString();
            PlayerPrefs.SetString("CountDay", _dayB);
        }
    }
    public void GetDays()
    {
        Appodeal.cache(Appodeal.REWARDED_VIDEO);
        _dateSave = Convert.ToDateTime(PlayerPrefs.GetString("DayBonus"));
        SetDayInWeekOut();
        DateTime dateTime = DateTime.UtcNow;
        TimeSpan _days = dateTime - _dateSave;
        _timeDay = (int)_days.TotalHours;
        if (_timeDay > 24 && _timeDay < 48)
        {
            DayInWeek();
            _plashBonusDay.SetActive(true);
            _textBackUp.SetActive(false);
            Bonus_everyDay();
        }
        if (_timeDay > 48)
        {
            DayInWeek();
            _plashBonusDay.SetActive(true);
            _textBackUp.SetActive(false);
            Bonus_everyDay();
        }
    }
    public void Bonus_everyDay()
    {
        PlayerPrefs.SetString("DayBonus", _date);
    }
    public void SetCoins()
    {
        SetDayInWeek();
        DayInWeek();
        if (_dayBonus == 0)
        {
            _countVal._countCoin += _valBonus[_dayBonus];
            CheckText(true, false, _valBonus[_dayBonus].ToString(), "");
        }
        else if(_dayBonus > 0)
        {
            _countVal._countCoin += _valBonus[_dayBonus - 1];
            CheckText(true, false, _valBonus[_dayBonus - 1].ToString(), "");
        }
        AppMetrika_Metods.RepADS("Not double Everyday bonus");
        _countVal._coins.text= _countVal._coinsToMenu.text = Convert.ToString(_countVal._countCoin);
        _plashBonusDay.SetActive(false);
        _textBackUp.SetActive(true);

    }
    public void SetCoins2x()
    {
        _ads._checkFinish = 2;
        _ads.ShowRewardVideo();
    }
    public void GetBonusADS()
    {
        SetDayInWeek();
        DayInWeek();
        if (_dayBonus == 0)
        {
            _countVal._countCoin += _valBonus[_dayBonus] * 2;
            CheckText(true, false, (_valBonus[_dayBonus] * 2).ToString(), "");
        }
        else if (_dayBonus > 0)
        {
            _countVal._countCoin += _valBonus[_dayBonus - 1] * 2;
            CheckText(true, false, (_valBonus[_dayBonus - 1] * 2).ToString(), "");
        }
            _countVal._coins.text = _countVal._coinsToMenu.text = Convert.ToString(_countVal._countCoin);
        _plashBonusDay.SetActive(false);
        _textBackUp.SetActive(true);
    }

    public void SetFirstBonus()
    {
        _countVal._countCoin += 700;
        _countVal._coins.text = _countVal._coinsToMenu.text = Convert.ToString(_countVal._countCoin);
        _countVal._countCristal += 3;
        _countVal._cristalMenu.text= _countVal._countCristal.ToString();

        CheckText(true, true, "700", "3");
    }
    public void CheckText(bool flag, bool flag2, string textval, string textval2)
    {
        _flag[0] = flag;
        _flag[1]= flag2;
        _priceText[0].text = "+" + textval;
        _priceText[1].text = "+" + textval2;
        Debug.Log(_priceText);
    }
    public void TextEverydayBonesPlus()
    {
        if (_flag[0] == true && _textPlus[0].transform.position.y < _posY[0])
        {
            _textPlus[0].gameObject.SetActive(true);
            _textPlus[0].GetComponent<TextMeshProUGUI>().text = _priceText[0].text;
            _textPlus[0].transform.position = Vector3.Lerp(_textPlus[0].transform.position,
                new Vector3(_textPlus[0].transform.position.x, _posY[0], _textPlus[0].transform.position.z), 0.05f);
        }
        if (_textPlus[0].transform.position.y > _posY[0] - 1)
        {
            _flag[0] = false;
            _textPlus[0].transform.position = new Vector3(_textPlus[0].transform.position.x, _posY[0] - 20, _textPlus[0].transform.position.z);
            _textPlus[0].gameObject.SetActive(false);
        }

        if (_flag[1] == true && _textPlus[1].transform.position.y < _posY[1])
        {
            _textPlus[1].gameObject.SetActive(true);
            _textPlus[1].GetComponent<TextMeshProUGUI>().text = _priceText[1].text;
            _textPlus[1].transform.position = Vector3.Lerp(_textPlus[1].transform.position,
                new Vector3(_textPlus[1].transform.position.x, _posY[0], _textPlus[1].transform.position.z), 0.05f);
        }
        if (_textPlus[1].transform.position.y > _posY[0] - 1)
        {
            _flag[1] = false;
            _textPlus[1].transform.position = new Vector3(_textPlus[1].transform.position.x, _posY[0] - 20, _textPlus[1].transform.position.z);
            _textPlus[1].gameObject.SetActive(false);
        }

    }
}
