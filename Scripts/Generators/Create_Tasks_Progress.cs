using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Create_Tasks_Progress : MonoBehaviour
{
    [SerializeField] private Sound _soundT;
    [SerializeField] private Counter count;
    public Tasks _plash;
    [SerializeField] private GameObject _winTask;
    [SerializeField] private GameObject _winProgress;
    public GameObject[] _clonTask;
    public GameObject[] _clonProgress;
    public Tusks_struct TuStr;
    public Progress_struct ProStr;
    [SerializeField] private Sprite[] _currency;
    [SerializeField] int[] _compl=new int[2];
    [SerializeField] private GameObject[] _image;

    //Tasks
    #region
    public Create_Tasks_Progress(Tasks plash)
    {
        _plash = plash;
    }

    public void InitTask()
    {
        for (int i = 0; i < _plash._tasksData.Count; i++)
        {
            _clonTask[i] = Instantiate(_plash._plashTask, _winTask.transform);
            Vector3 temp = _clonTask[i].transform.position;
            temp.y -= (i *29);
            _clonTask[i].transform.position = temp;

            Pattern_Task TTT = _clonTask[i].GetComponent<Pattern_Task>();
            TTT.count = count;
            TTT._sortTask = this.GetComponent<Create_Tasks_Progress>();
            GetValuePlashs(i);
            TuStr.StrTusk[i]._parametrValue = InitParametr(TuStr.StrTusk[i]._enumT);
            WriteInTask(TTT, TuStr.StrTusk[i]);
            TuStr._pos_yT[i] = temp.y;
            _clonTask[i].GetComponent<Sound>()._audio = _soundT._audio;
            _clonTask[i].GetComponent<Sound>()._clip = _soundT._clip;
            _clonTask[i].transform.GetChild(5).gameObject.SetActive(false);
        }
        SortTasks();
    }

    public void GetValuePlashs(int i)
    {

        TuStr.StrTusk[i]._description1 = _plash._tasksData[i].description;
        TuStr.StrTusk[i]._description2 = _plash._tasksData[i].description2;
        TuStr.StrTusk[i]._reward = Convert.ToString(_plash._tasksData[i].coins);
        TuStr.StrTusk[i]._enumT = Convert.ToString(_plash._tasksData[i].val);
        TuStr.StrTusk[i]._enumCur = Convert.ToString(_plash._tasksData[i].Coin_cristal);
        TuStr.StrTusk[i]._parametrValue = _clonTask[i].GetComponent<Pattern_Task>()._parametrValue;
        TuStr.StrTusk[i]._icon = _plash._tasksData[i].icon;
        TuStr.StrTusk[i]._valtask = _clonTask[i].transform.GetChild(2).GetComponent<Scrollbar>();
        TuStr.StrTusk[i]._valueScrollbar = _clonTask[i].transform.GetChild(2).GetComponent<Scrollbar>().size;
        TuStr.StrTusk[i]._pos = _clonTask[i].transform.position;
        TuStr.StrTusk[i]._compleate = _clonTask[i].GetComponent<Pattern_Task>()._compleate;
        TuStr.StrTusk[i]._took = _clonTask[i].GetComponent<Pattern_Task>()._took;
        TuStr.StrTusk[i].value = _clonTask[i].GetComponent<Pattern_Task>().val;
    }
 
    public void WriteInTask(Pattern_Task TTT, StructTusk c)
    {
        TTT._compleate = c._compleate;
        if (c._parametrValue == 0 || c._parametrValue == 1)
        {
            TTT._description.text = c._description1 + " " + c._description2;
        }
        else
            TTT._description.text = c._description1 + " " + c._parametrValue + " " + c._description2;
        TTT._reward.text = c._reward;
        TTT.Reward = Convert.ToInt32(c._reward) * Convert.ToInt32(c._parametrValue);
        TTT._reward.text = TTT.Reward.ToString();
        TTT._enumT = c._enumT;
        TTT._enumCur = c._enumCur;
        if (TTT._enumCur == "Coin")
            TTT._imageCurency.sprite = _currency[0];
        if (TTT._enumCur == "Cristal")
            TTT._imageCurency.sprite = _currency[1];
        TTT._icon.sprite = c._icon;
        TTT._parametrValue = c._parametrValue;
        TTT._valtask = c._valtask;
        TTT._valtask.size = c._valueScrollbar;
        TTT._took = c._took;
        TTT.val = c.value;
    }

    public void SortTasks()
    {
        int count = 0;
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < _clonTask.Length; j++)
            {
                if (_clonTask[j].GetComponent<Pattern_Task>()._compleate == true &&
                    _clonTask[j].GetComponent<Pattern_Task>()._took == false && i == 0)
                {
                    _compl[0]++;
                    count = Sort(count, _clonTask[j], TuStr._pos_yT);
                }
                if (_clonTask[j].GetComponent<Pattern_Task>()._compleate == false &&
                    _clonTask[j].GetComponent<Pattern_Task>()._took == false && i == 1)
                {
                    count = Sort(count, _clonTask[j], TuStr._pos_yT);
                }
                if (_clonTask[j].GetComponent<Pattern_Task>()._compleate == true &&
                    _clonTask[j].GetComponent<Pattern_Task>()._took == true && i == 2)
                {
                    count = Sort(count, _clonTask[j], TuStr._pos_yT);
                }
            }
        }
        if (_compl[0] < 1)
        {
            _image[0].gameObject.SetActive(false);
        }
        if (_compl[0] > 0)
        {
            _image[0].gameObject.SetActive(true);
            _image[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _compl[0].ToString();
        } 
        _winTask.transform.localPosition = new Vector3(_winTask.transform.localPosition.x, 0, 0);
        _compl[0] = 0;
    }


    private int Sort(int count, GameObject _clon, float[] TuPos)
    {
        _clon.transform.parent.GetComponent<RectTransform>().position = new Vector2
       (_clon.transform.parent.GetComponent<RectTransform>().position.x,
         _clon.transform.parent.GetComponent<RectTransform>().position.y);
        Vector3 posProg = _clon.GetComponent<RectTransform>().position;
        posProg = new Vector3(posProg.x, TuPos[count]);
        _clon.transform.position = posProg;
        //  Debug.Log(_clon.transform.position);

        count++;
        return count;
    }

    public void LoadTask()
    {
        for (int i = 0; i < _plash._tasksData.Count; i++)
        {
            _clonTask[i] = Instantiate(_plash._plashTask, _winTask.transform);
            Pattern_Task temp = _clonTask[i].GetComponent<Pattern_Task>();
            temp._compleate = TuStr.StrTusk[i]._compleate;
            if (TuStr.StrTusk[i]._parametrValue == 0 || TuStr.StrTusk[i]._parametrValue == 1)
            {
                temp._description.text = TuStr.StrTusk[i]._description1 + " " + TuStr.StrTusk[i]._description2;
            }
            else
                temp._description.text = TuStr.StrTusk[i]._description1 + " " + TuStr.StrTusk[i]._parametrValue + " " + TuStr.StrTusk[i]._description2;
            temp._enumT = TuStr.StrTusk[i]._enumT;
            temp._enumCur = TuStr.StrTusk[i]._enumCur;
            if (TuStr.StrTusk[i]._enumCur == "Coin")
                temp._imageCurency.sprite = _currency[0];
            if (TuStr.StrTusk[i]._enumCur == "Cristal")
                temp._imageCurency.sprite = _currency[1];
            temp._icon.sprite = _plash._tasksData[i].icon;
            temp._parametrValue = TuStr.StrTusk[i]._parametrValue;
            temp._took = TuStr.StrTusk[i]._took;
            temp._valtask = _clonTask[i].transform.GetChild(2).GetComponent<Scrollbar>();
            temp._valtask.size = TuStr.StrTusk[i]._valueScrollbar;
            temp.count = count;
            temp._sortTask = this.GetComponent<Create_Tasks_Progress>();
            temp.transform.position = new Vector3(_clonTask[i].transform.position.x, TuStr._pos_yT[i], _clonTask[i].transform.position.z);
            temp.Reward = Convert.ToInt32(TuStr.StrTusk[i]._reward) * Convert.ToInt32(TuStr.StrTusk[i]._parametrValue);
            temp._reward.text = temp.Reward.ToString();
            temp.val = TuStr.StrTusk[i].value;
            _clonTask[i].GetComponent<Sound>()._audio = _soundT._audio;
            _clonTask[i].GetComponent<Sound>()._clip = _soundT._clip;
            Activ_Butt_Image(TuStr.StrTusk[i]._took, TuStr.StrTusk[i]._compleate, _clonTask[i]);
        }
        SortTasks();
    }

    public float InitParametr(string _enam)
    {
        float _parametrValue = 0;
        switch (_enam)
        {
            case "Count_Oxy":
                _parametrValue = UnityEngine.Random.Range(5, 25);
                return _parametrValue;
            case "ValueSpeed":
                _parametrValue = UnityEngine.Random.Range(5, 17);
                return _parametrValue;
            case "ValCoins":
                _parametrValue = UnityEngine.Random.Range(5, 10);//30,75
                return _parametrValue;
            case "ValueDistans_damage":
                _parametrValue = UnityEngine.Random.Range(30, 150);//(5, 50) * 10
                return _parametrValue;
            case "Rans":
                _parametrValue = UnityEngine.Random.Range(3, 5);//(5, 50) * 10
                return _parametrValue;
            case "OneSkin":
                _parametrValue = 1;
                return _parametrValue;
            case "BaySkin":
                _parametrValue = UnityEngine.Random.Range(1, 2);
                return _parametrValue;


        }
        return _parametrValue;

    }

    public void GetValForSave()
    {
        for (int i = 0; i < TuStr.StrTusk.Length; i++)
        {
            GetValuePlashs(i);
        }
    }
    #endregion


    //Progress
    #region
    public void InitProgress()
    {
        for (int i = 0; i < _plash._progressData.Count; i++)
        {
            _clonProgress[i] = Instantiate(_plash._plashProgress, _winProgress.transform);
            Vector3 temp = _clonProgress[i].transform.position;
            temp.y -= (i * 29);
            _clonProgress[i].transform.position = temp;
            //Debug.Log(temp);
            ProStr._pos_yPr[i] = _clonProgress[i].transform.position.y;
            Pattern_Progres_plash Prog = _clonProgress[i].GetComponent<Pattern_Progres_plash>();
            Prog.count = count;
            Prog._sortProgress = this.GetComponent<Create_Tasks_Progress>();
            GetValuePlashsPr(i);
            ProStr._strProgr[i]._parametrValue = _plash._progressData[i].num;
            WriteInTaskPr(Prog, ProStr._strProgr[i]);
            _clonProgress[i].GetComponent<Sound>()._audio = _soundT._audio;
            _clonProgress[i].GetComponent<Sound>()._clip = _soundT._clip;
            _clonProgress[i].transform.GetChild(5).gameObject.SetActive(false);
            // Debug.Log("Init"+_clonProgress[i].transform.position);
        }
        SortProgress();
    }

    public void GetValuePlashsPr(int i)
    {
        ProStr._strProgr[i]._description1 = _plash._progressData[i].description;
        ProStr._strProgr[i]._description2 = _plash._progressData[i].description2;
        ProStr._strProgr[i]._reward = Convert.ToString(_plash._progressData[i].coins);
        ProStr._strProgr[i]._enumP = Convert.ToString(_plash._progressData[i].val);
        ProStr._strProgr[i]._enumCur = Convert.ToString(_plash._progressData[i].Coin_cristal);
        ProStr._strProgr[i]._parametrValue = _clonProgress[i].GetComponent<Pattern_Progres_plash>()._parametrValue;
        ProStr._strProgr[i]._icon = _plash._progressData[i].icon;
        ProStr._strProgr[i]._valtask = _clonProgress[i].transform.GetChild(2).GetComponent<Scrollbar>();
        ProStr._strProgr[i]._valueScrollbar = _clonProgress[i].transform.GetChild(2).GetComponent<Scrollbar>().size;
        ProStr._strProgr[i]._pos = _clonProgress[i].transform.position;
        ProStr._strProgr[i]._compleate = _clonProgress[i].GetComponent<Pattern_Progres_plash>()._compleate;
        ProStr._strProgr[i]._took = _clonProgress[i].GetComponent<Pattern_Progres_plash>()._took;
        ProStr._strProgr[i].value = _clonProgress[i].GetComponent<Pattern_Progres_plash>().val;
    }

    public void WriteInTaskPr(Pattern_Progres_plash Prog, StructProgress _sP)
    {
        Prog._compleate = _sP._compleate;
        if (_sP._parametrValue==0|| _sP._parametrValue == 1)
        {
            Prog._description.text = _sP._description1 + " " + _sP._description2;
        }
        else
        Prog._description.text = _sP._description1 + " " + _sP._parametrValue + " " + _sP._description2;
        Prog._reward.text = _sP._reward;
        Prog.Reward = Convert.ToInt32(_sP._reward);
        Prog._enumP = _sP._enumP;
        Prog._enumCur = _sP._enumCur;
        if (_sP._enumCur == "Coin")
            Prog._imageCurency.sprite = _currency[0];
        if (_sP._enumCur == "Cristal")
            Prog._imageCurency.sprite = _currency[1];
        Prog._icon.sprite = _sP._icon;
        Prog._parametrValue = _sP._parametrValue;
        Prog._valProgres = _sP._valtask;
        Prog._valProgres.size = _sP._valueScrollbar;
        Prog._took = _sP._took;
        Prog.val = _sP.value;
    }

    public void SortProgress()
    {
        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < _clonProgress.Length; j++)
            {
                if (_clonProgress[j].GetComponent<Pattern_Progres_plash>()._compleate == true && _clonProgress[j].GetComponent<Pattern_Progres_plash>()._took == false && i == 0)
                {
                    _compl[1]++;
                    count = Sort(count, _clonProgress[j], ProStr._pos_yPr);
                }
                if (_clonProgress[j].GetComponent<Pattern_Progres_plash>()._compleate == false && _clonProgress[j].GetComponent<Pattern_Progres_plash>()._took == false && i == 1)
                {
                    count = Sort(count, _clonProgress[j], ProStr._pos_yPr);
                }
                if (_clonProgress[j].GetComponent<Pattern_Progres_plash>()._took == true && _clonProgress[j].GetComponent<Pattern_Progres_plash>()._took == true && i == 2)
                {
                    count = Sort(count, _clonProgress[j], ProStr._pos_yPr);
                }
            }
        }
        if (_compl[1] < 1)
        {
            _image[1].gameObject.SetActive(false);
        }
        if (_compl[1] > 0)
        {
            _image[1].gameObject.SetActive(true);
            _image[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _compl[1].ToString();
        }
        _winProgress.transform.localPosition = new Vector3(_winProgress.transform.localPosition.x, 0, 0);
        _compl[1] = 0;
    }

    public void LoadProgress()
    {
        for (int i = 0; i < _plash._progressData.Count; i++)
        {
            _clonProgress[i] = Instantiate(_plash._plashProgress, _winProgress.transform);
            Pattern_Progres_plash temp = _clonProgress[i].GetComponent<Pattern_Progres_plash>();
            temp._compleate = ProStr._strProgr[i]._compleate;
            if (ProStr._strProgr[i]._parametrValue == 0|| ProStr._strProgr[i]._parametrValue == 1)
            {
                temp._description.text = ProStr._strProgr[i]._description1 + " " + ProStr._strProgr[i]._description2;
            }
            else
                temp._description.text = ProStr._strProgr[i]._description1 + " " + ProStr._strProgr[i]._parametrValue + " " + ProStr._strProgr[i]._description2;
            temp._enumP = ProStr._strProgr[i]._enumP;
            temp._enumCur = ProStr._strProgr[i]._enumCur;
            if (ProStr._strProgr[i]._enumCur == "Coin")
                temp._imageCurency.sprite = _currency[0];
            if (ProStr._strProgr[i]._enumCur == "Cristal")
                temp._imageCurency.sprite = _currency[1];
            temp._icon.sprite = _plash._progressData[i].icon;
            temp._parametrValue = ProStr._strProgr[i]._parametrValue;
            temp._took = ProStr._strProgr[i]._took;
            temp._valProgres = _clonProgress[i].transform.GetChild(2).GetComponent<Scrollbar>();
            temp._valProgres.size = ProStr._strProgr[i]._valueScrollbar;
            temp.count = count;
            temp._sortProgress = this.GetComponent<Create_Tasks_Progress>();
            temp.transform.position = new Vector3(_clonProgress[i].transform.position.x, ProStr._pos_yPr[i], _clonProgress[i].transform.position.z);
            temp.Reward = Convert.ToInt32(ProStr._strProgr[i]._reward);
            temp._reward.text = ProStr._strProgr[i]._reward;
            temp.val = ProStr._strProgr[i].value;
            _clonProgress[i].GetComponent<Sound>()._audio = _soundT._audio;
            _clonProgress[i].GetComponent<Sound>()._clip = _soundT._clip;
            Activ_Butt_Image(ProStr._strProgr[i]._took, ProStr._strProgr[i]._compleate, _clonProgress[i]);
            // Debug.Log("LoadProg"+_clonProgress[i].transform.position);
        }
        SortProgress();
    }

    public void GetValForSavePr()
    {
        for (int i = 0; i < ProStr._strProgr.Length; i++)
        {
            GetValuePlashsPr(i);
        }
    }
    #endregion

    public void Activ_Butt_Image(bool took, bool compleate, GameObject clonProg)
    {
        if (took == true)
        {
            clonProg.transform.GetChild(2).gameObject.SetActive(false);
            clonProg.transform.GetChild(4).gameObject.SetActive(false);
            clonProg.transform.GetChild(5).gameObject.SetActive(false);
            clonProg.transform.GetChild(6).gameObject.SetActive(true);
        }
        if (compleate == true && took == false)
        {
            clonProg.transform.GetChild(2).gameObject.SetActive(false);
            clonProg.transform.GetChild(4).gameObject.SetActive(true);
            clonProg.transform.GetChild(5).gameObject.SetActive(true);
            clonProg.transform.GetChild(6).gameObject.SetActive(false);
        }
        if (compleate == false)
        {
            clonProg.transform.GetChild(4).gameObject.SetActive(true);
            clonProg.transform.GetChild(5).gameObject.SetActive(false);
            clonProg.transform.GetChild(6).gameObject.SetActive(false);
        }
    }
}