using UnityEngine;
using UnityEngine.UI;


public class Logic_Tasks : MonoBehaviour
{
    private Counter _valueParam;
    [SerializeField] private Create_Tasks_Progress _metodsTask;
    [SerializeField] private Tasks _paramTask;
    [SerializeField] private MoveAcselorometr _player;




    public void AchivOxy(int _countOx, int i)
    {
        string _text = _paramTask._tasksData[i].val.ToString();

        if (_metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate == false &&
            _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._enumT == _text &&
            _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._took == false)
        {
            if (_countOx == _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._parametrValue)
            {
                _metodsTask._clonTask[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1;
                _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate = true;
                _metodsTask._clonTask[i].transform.GetChild(5).gameObject.SetActive(true);
            }
        }
    }

    public void AchivSpeed(int i)
    {
        string _text = _paramTask._tasksData[i].val.ToString();
        if (_metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate == false &&
            _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._enumT == _text &&
            _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._took == false)
        {
            if (_player._speed >= _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._parametrValue)// _metodsTask._clonTask[1].GetComponent<Pattern_Task>()._parametrValue)
            {
                _metodsTask._clonTask[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1;
                _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate = true;
                _metodsTask._clonTask[i].transform.GetChild(5).gameObject.SetActive(true);
            }
        }
    }

    public void AchivDistDamage(float _distNull, float _dist, int i)
    {
        string _text = _paramTask._tasksData[i].val.ToString();
        if (_metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate == false &&
            _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._enumT == _text &&
            _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._took == false)
        {
            if ((_dist - _distNull) >= _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._parametrValue)
            {
                _metodsTask._clonTask[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1;
                _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate = true;
                _metodsTask._clonTask[i].transform.GetChild(5).gameObject.SetActive(true);
            }
        }
    }

    public void CountRans()
    {
        float count = _metodsTask._clonTask[3].GetComponent<Pattern_Task>().val;
        count++;
        _metodsTask._clonTask[3].GetComponent<Pattern_Task>().val = count;
        AchivCountRans(3, count);

    }

    private void AchivCountRans(int i, float count)
    {
        string _text = "Rans";
        if (_metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate == false
            && _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._enumT == _text)
        {
            if (count > _metodsTask.ProStr._strProgr[i].value)
            {
                _metodsTask._clonTask[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1 /
                _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._parametrValue * count;
                _metodsTask._clonTask[i].GetComponent<Pattern_Task>().val = count;
            }
            if (count >= _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._parametrValue)
            {
                _metodsTask._clonTask[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1;
                _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate = true;
                _metodsTask._clonTask[i].transform.GetChild(5).gameObject.SetActive(true);
            }
        }
    }

    public void ChangeOneSkin(int i)
    {
        string _text = "OneSkin";
        if (_metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate == false &&
            _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._enumT == _text &&
            _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._took == false)
        {
            _metodsTask._clonTask[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1;
            _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate = true;
            _metodsTask._clonTask[i].transform.GetChild(5).gameObject.SetActive(true);
        }
    }

    public void CountSkin()
    {
        float _myBuy = _metodsTask._clonTask[5].GetComponent<Pattern_Task>().val;
        _myBuy++;
        _metodsTask._clonTask[5].GetComponent<Pattern_Task>().val = _myBuy;
        AchivBuySkin(5, _myBuy);
    }

    private void AchivBuySkin(int i, float myBuy)
    {
        string _text = "BaySkin";
        if (_metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate == false
            && _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._enumT == _text)
        {
            if (myBuy > _metodsTask.ProStr._strProgr[i].value)
            {
                _metodsTask._clonTask[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1 /
                _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._parametrValue * myBuy;
                _metodsTask._clonTask[i].GetComponent<Pattern_Task>().val = myBuy;
            }
            if (myBuy >= _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._parametrValue)
            {
                _metodsTask._clonTask[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1;
                _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate = true;
                _metodsTask._clonTask[i].transform.GetChild(5).gameObject.SetActive(true);
            }
        }
    }

    public void AchivCoinsRan(int i, int coins)
    {
        string _text = _paramTask._tasksData[i].val.ToString();
        if (_metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate == false &&
            _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._enumT == _text &&
            _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._took == false)
        {
            if (coins >= _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._parametrValue)
            {
                _metodsTask._clonTask[i].transform.GetChild(2).GetComponent<Scrollbar>().size = 1;
                _metodsTask._clonTask[i].GetComponent<Pattern_Task>()._compleate = true;
                _metodsTask._clonTask[i].transform.GetChild(5).gameObject.SetActive(true);
            }
        }
    }
}


