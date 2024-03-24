using System.IO;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class Save_Boosters : MonoBehaviour
{
    public Boosters _saveB;
    public Boosters_Time _saveB_time;
    public string _PathBoost;
    public string _pathDellBoost;
    public string _fileName = "Boost.json";
    public string _fileDellName = "Boost.json.meta";
    public Button[] _bostersButton;
    [SerializeField] private Sprite[] _iconBustAct;
    public TextMeshProUGUI[] _countsBusters;





    public void ButtonActiv(int[] bo)
    {
        for (int i = 0; i < _bostersButton.Length; i++)
        {
            if (bo[i] != 0)
            {
                _bostersButton[i].interactable = true;
                _bostersButton[i].transform.GetChild(0).GetComponent<Image>().sprite = _iconBustAct[i];
            }
        }
    }

    public void SaveToFile()
    {
        SetPath();
        Boosterss _boosters = new Boosterss
        {
            UnTime = _saveB._busterUnlimited,
            _time = _saveB_time._busterlimit
        };
        string _jsonBo = JsonUtility.ToJson(_boosters, prettyPrint: true);
        File.WriteAllText(_PathBoost, contents: _jsonBo);
    }

    public void LoadFromFile()
    {
        SetPath();
        if (!File.Exists(_PathBoost))
        {
            return;
        }
        else
        {
            string _jsonBo = File.ReadAllText(_PathBoost);
            Boosterss _BoostFromJson = JsonUtility.FromJson<Boosterss>(_jsonBo);
            _saveB._busterUnlimited = _BoostFromJson.UnTime;
            _saveB_time._busterlimit = _BoostFromJson._time;
            test();
        }

    }

    public void test()
    {
        int[] bo = new int[4];
        bo[0] = _saveB._busterUnlimited._coin_2x;
        bo[1] = _saveB._busterUnlimited._healthFour;
        bo[2] = _saveB_time._busterlimit._oxyUnlimit;
        bo[3] = _saveB_time._busterlimit._unlimitLives;
        for(int i = 0; i < 4; i++) 
        {
            _countsBusters[i].text = bo[i].ToString();
        }

       

        ButtonActiv(bo);
    }

    public void SetPath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _PathBoost = Path.Combine(Application.persistentDataPath, _fileName);
        _pathDellBoost = Path.Combine(Application.persistentDataPath, _fileDellName);
#else
        _PathBoost = Path.Combine(Application.dataPath, _fileName);
        _pathDellBoost = Path.Combine(Application.dataPath, _fileDellName);
#endif
    }
}
