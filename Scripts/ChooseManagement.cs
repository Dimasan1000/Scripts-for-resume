using System;
using UnityEngine;

public class ChooseManagement : MonoBehaviour
{
    [SerializeField] private MoveAcselorometr _management;
    public bool _boolManage;
    [SerializeField] private GameObject _joistick;
   // [SerializeField] private GameObject _panelManage;
    public bool test;
    public void Start()
    {
        if (PlayerPrefs.GetString("Mamage")=="True")
        {
            ChooseJoistick();
            _management._joystiOrfGiro = _boolManage;
            test=true;
        }
        else if (PlayerPrefs.GetString("Mamage") == "False")
        {
            ChooseGiro();
            _management._joystiOrfGiro = _boolManage;
            test=false;
        }

    }

    public void ChooseJoistick()
    {
        _boolManage = true;
        _joistick.SetActive(true);
    }

    public void ChooseGiro()
    {
        _boolManage = false;
        _joistick.SetActive(false);
    }

    public void Apply()
    {
        _management._joystiOrfGiro = _boolManage;
        PlayerPrefs.SetString("Mamage", _management._joystiOrfGiro.ToString());
    }
}
