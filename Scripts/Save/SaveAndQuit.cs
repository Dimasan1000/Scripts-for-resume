using UnityEngine;
using System;
using System.IO;
using TMPro;

public class SaveAndQuit : MonoBehaviour
{
    [SerializeField] private Seve_Parametres _saveParam;
    [SerializeField] private CountervaluesforAppMetrica _eventsforAppMetrica;
    [SerializeField] private Counter _resurses;
    [SerializeField] private Save_Boosters _boosters;
    [SerializeField] private bool _chekDelete;
    [SerializeField] private System_Skins _saveSkins;
    [SerializeField] private PlayADV _methodAchivs;
    [SerializeField] private All_Timers _ispause;
    [SerializeField] private GameObject _panelPouse;
    [SerializeField] private GameObject _canvasGC;
    [SerializeField] private GameObject _diePanel;
    private bool _isFocus;
    public float _time = 3;
    [SerializeField] private TextMeshProUGUI _textPouse;
    

    public void Update()
    {
        TimerPouse();
    }


    public void OnApplicationFocus(bool focus)
    {
        _isFocus = focus;
        if (focus == false&&_canvasGC.activeSelf==true)
        {
            _panelPouse.SetActive(true);
            _time = 3;
            _ispause.OnPauseRan();
            Save(); 
        }
    }

    public void TimerPouse()
    {
        if (_panelPouse.activeSelf==true&&_isFocus==true)
        {
            _time-=0.025f;
            _textPouse.text = "Starting in: \n"+_time.ToString("0");
            if ( _time < 0)
            {
                _ispause.OffPauseRan();
                _panelPouse.SetActive(false);
            }
        }
    }

  

    public void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        Achivs();
        PlayerPrefs.SetInt("Coins", _resurses._countCoin);
        PlayerPrefs.SetInt("Crist", _resurses._countCristal);
        _saveParam.SaveToFile();//?????????? ? ???? json.
        _saveSkins.SeveSystSkins();

        AppmetricaEvents();

        if (_chekDelete == true)
            DeleteAllSaves();
    }

    private void AppmetricaEvents()
    {
        AppMetrika_Metods.CountHitsInRan(_eventsforAppMetrica._countHits);
        AppMetrika_Metods.CountClicRewive(_eventsforAppMetrica._countRewive);
        AppMetrika_Metods.Count2xBuster(_eventsforAppMetrica._countDoubleBuster);

    }


    public void Load()
    {
        _resurses._countCoin = PlayerPrefs.GetInt("Coins");
        _resurses._countCristal = PlayerPrefs.GetInt("Crist");
        _boosters.LoadFromFile();
        _saveParam.LoadFromFile(false);
        _saveParam.LoadProgFromFile();
        _saveSkins.LoadFromFile();
    }

    public void Ceck()
    {
        _chekDelete = true;
    }

    public void DeleteAllSaves()
    {
        Debug.Log("Delete");
        PlayerPrefs.DeleteAll();
        string _task = _saveParam._savePath;
        string _taskDell = _saveParam._deletePath;
        string _progress = _saveParam._savePathProg;
        string _progressDell = _saveParam._deletePathProg;
        string _limBoost = _boosters._PathBoost;
        string _limBoostDell = _boosters._pathDellBoost;
        string _skins = _saveSkins._pathSkins;
        string _skinsDell = _saveSkins._pathSkinsDell;
        File.Delete(_task);
        File.Delete(_taskDell);
        File.Delete(_progress);
        File.Delete(_progressDell);
        File.Delete(_limBoost);
        File.Delete(_limBoostDell);
        File.Delete(_skins);
        File.Delete(_skinsDell);
    }
    private void Achivs()
    {
        _methodAchivs.AchivCoinRan();
    }

}
