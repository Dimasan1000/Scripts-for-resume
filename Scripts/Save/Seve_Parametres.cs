using UnityEngine;
using System.IO;
using System;
using Facebook.Unity;

public class Seve_Parametres : MonoBehaviour
{
    [SerializeField] private string _date;
    DateTime _weekSave;
    public int _timeWeek;

    [SerializeField] private Create_Tasks_Progress _task;
    public string _savePath;
    public string _savePathProg;
    public string _fileName = "dataTask.json";
    public string _fileNameProgress = "dataProgress.json";
    public string _deletePath;
    public string _deletePathProg;
    public string _fileDelete = "dataTask.json.meta";
    public string _fileDeleteProgr = "dataProgress.json.meta";
    public FaseBook_SDK Inst;
    [SerializeField] private GameObject[] _firstBonus;

    public void Start()
    {
        SetPath();
        if (PlayerPrefs.HasKey("Mamage")==false)
        {
            _firstBonus[0].SetActive(true);
            _firstBonus[1].SetActive(true);
        }
            _date = Convert.ToString(DateTime.UtcNow);
        if (PlayerPrefs.HasKey("WeekUpdate") == false)
        {
           
            UpdateTasksWeek();
        }
        else
          GetWeeks();
    }

    public void GetWeeks()
    {
        _weekSave = Convert.ToDateTime(PlayerPrefs.GetString("WeekUpdate"));
        DateTime dateTime = DateTime.UtcNow;
        TimeSpan _days = dateTime - _weekSave;
        _timeWeek = (int)_days.TotalMinutes;
        //Debug.Log("initWeek");
        
    }

    public void UpdateTasksWeek()
    {
        PlayerPrefs.SetString("WeekUpdate", _date);
    }

    public void SaveToFile()
    {
        SetPath();
        _task.GetValForSave();
        _task.GetValForSavePr();
        Tusks_struct _taskS = new Tusks_struct
        {
            StrTusk = _task.TuStr.StrTusk,
            _pos_yT = _task.TuStr._pos_yT
        };
        Progress_struct _progressS = new Progress_struct
        {
            _strProgr = _task.ProStr._strProgr,
            _pos_yPr = _task.ProStr._pos_yPr
        };
        string _jsonT = JsonUtility.ToJson(_taskS, prettyPrint: true);
        File.WriteAllText(_savePath, contents: _jsonT);
        string _jsonP = JsonUtility.ToJson(_progressS, prettyPrint: true);
        File.WriteAllText(_savePathProg, contents: _jsonP);
    }


    public void LoadFromFile(bool check)
    {
        
        SetPath();
        _task._clonTask = new GameObject[_task._plash._tasksData.Count];
        _task.TuStr.StrTusk = new StructTusk[_task._plash._tasksData.Count];
        if (!File.Exists(_savePath) || _timeWeek > 100 || check == true)
        {
            _task.InitTask();
            UpdateTasksWeek();
            check = false;
            return;
        }
        else
        {
            string _jsonT = File.ReadAllText(_savePath);
            Tusks_struct _tuskFromJson = JsonUtility.FromJson<Tusks_struct>(_jsonT);
            _task.TuStr.StrTusk = _tuskFromJson.StrTusk;
          //  Debug.Log(_task.gameObject.name);
            _task.TuStr._pos_yT = _tuskFromJson._pos_yT;
        }
        _task.LoadTask();
    }
    public void LoadProgFromFile()
    {
       
        SetPath();
        _task._clonProgress = new GameObject[_task._plash._progressData.Count];
        _task.ProStr._strProgr = new StructProgress[_task._plash._progressData.Count];
        
        if (!File.Exists(_savePathProg))
        {

            _task.InitProgress();
            return;
        }
        else
        {
            string _jsonP = File.ReadAllText(_savePathProg);
            Progress_struct _progressFromJson = JsonUtility.FromJson<Progress_struct>(_jsonP);
            _task.ProStr._strProgr = _progressFromJson._strProgr;
            _task.ProStr._pos_yPr = _progressFromJson._pos_yPr;
            _task.LoadProgress();
        }
    }
    public void SetPath()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _savePath = Path.Combine(Application.persistentDataPath, _fileName);
        _deletePath = Path.Combine(Application.persistentDataPath, _fileDelete);
        _savePathProg = Path.Combine(Application.persistentDataPath, _fileNameProgress);
        _deletePathProg = Path.Combine(Application.persistentDataPath, _deletePathProg);
#else
        _savePath = Path.Combine(Application.dataPath, _fileName);
        _deletePath = Path.Combine(Application.dataPath, _fileDelete);
        _savePathProg = Path.Combine(Application.dataPath, _fileNameProgress);
        _deletePathProg = Path.Combine(Application.dataPath, _fileDeleteProgr);
#endif
    }
}

