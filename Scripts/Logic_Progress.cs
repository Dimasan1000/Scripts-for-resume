using UnityEngine;
using UnityEngine.UI;

public class Logic_Progress : MonoBehaviour
{
    private Counter _valueParam;
    [SerializeField] private Create_Tasks_Progress _metodsProg;
    [SerializeField] private Tasks _paramProg;
    private MoveAcselorometr _player;
  //  [SerializeField] private Seve_Parametres _saveProg;



    public void AchivDistanse(float _distanse, string j)
    {
        string _text = j;
        for (int i = 0; i < _paramProg._progressData.Count; i++)
        {
            if (_metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._compleate == false
                && _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._enumP == _text)
            {
                if (_distanse > _metodsProg.ProStr._strProgr[i].value)
                {
                    _metodsProg._clonProgress[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1 /
                       _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._parametrValue * _distanse;
                    _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>().val = _distanse;
                }
                if (_distanse >= _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._parametrValue)
                {
                    _metodsProg._clonProgress[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1;
                    _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._compleate = true;
                    _metodsProg._clonProgress[i].transform.GetChild(5).gameObject.SetActive(true);
                }
            }
        }
    }

    public void AchivCoins(int coin, string j)
    {
        string _text = j;
        for (int i = 0; i < _paramProg._progressData.Count; i++)
        {
            if (_metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._compleate == false
            && _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._enumP == _text)
            {
                if (coin > _metodsProg.ProStr._strProgr[i].value)
                {
                    _metodsProg._clonProgress[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1 /
                    _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._parametrValue * coin;
                    _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>().val = coin;
                }
                if (coin >= _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._parametrValue)
                {
                    _metodsProg._clonProgress[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1;
                    _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._compleate = true;
                    _metodsProg._clonProgress[i].transform.GetChild(5).gameObject.SetActive(true);
                }
            }
        }
    }

    public void AchivValOxy(float _oxy, string j)
    {
        string _text = j;
        for (int i = 0; i < _paramProg._progressData.Count; i++)
        {
            if (_metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._compleate == false &&
            _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._enumP == _text)
            {
                if (_oxy > _metodsProg.ProStr._strProgr[i].value)
                {
                    _metodsProg._clonProgress[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1 /
                   _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._parametrValue * _oxy;
                    _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>().val += _oxy;
                }
                if (_oxy >= _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._parametrValue)
                {
                    _metodsProg._clonProgress[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1;
                    _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._compleate = true;
                    _metodsProg._clonProgress[i].transform.GetChild(5).gameObject.SetActive(true);
                }
            }
        }
    }

    public void CountSkin(string num)
    {
        string _name;
        float _myBuy;
        for (int x = 0; x < _paramProg._progressData.Count; x++)
        {
            if (_paramProg._progressData[x].val.ToString() == num)
            {
                _name = _paramProg._progressData[x].val.ToString();
                _myBuy = _metodsProg._clonProgress[x].GetComponent<Pattern_Progres_plash>().val;
                _myBuy++;
                _metodsProg._clonProgress[x].GetComponent<Pattern_Progres_plash>().val = _myBuy;
                AchiSkins(_myBuy, _name);
                return;
            }
        }
    }

    public void AchiSkins(float color, string j)
    {
        string _text = j;
        for (int i = 0; i < _paramProg._progressData.Count; i++)
        {
            if (_metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._compleate == false &&
            _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._enumP == _text)
            {
                if (color > _metodsProg.ProStr._strProgr[i].value)
                {
                    _metodsProg._clonProgress[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1 /
                   _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._parametrValue * color;
                    _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>().val += color;
                }
                if (color >= _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._parametrValue)
                {
                    _metodsProg._clonProgress[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1;
                    _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._compleate = true;
                    _metodsProg._clonProgress[i].transform.GetChild(5).gameObject.SetActive(true);
                }
            }
        }
    }
    public void Mecenat(int _countOx, int i)
    {
        string _text = _paramProg._progressData[i].val.ToString();
        if (_metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._compleate == false &&
            _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._enumP == _text &&
            _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._took == false)
        {
            if (_countOx == _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._parametrValue)
            {
                _metodsProg._clonProgress[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1;
                _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._compleate = true;
                _metodsProg._clonProgress[i].transform.GetChild(5).gameObject.SetActive(true);
            }
        }
    }
    public void ChangeChracter(int _countOx, int i)
    {
        string _text = _paramProg._progressData[i].val.ToString();
        if (_metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._compleate == false &&
            _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._enumP == _text &&
            _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._took == false)
        {
            if (_countOx == _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._parametrValue)
            {
                _metodsProg._clonProgress[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1;
                _metodsProg._clonProgress[i].GetComponent<Pattern_Progres_plash>()._compleate = true;
                _metodsProg._clonProgress[i].transform.GetChild(5).gameObject.SetActive(true);
            }
        }
        _metodsProg.SortProgress();
    }
}
