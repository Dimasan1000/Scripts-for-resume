using UnityEngine;
using TMPro;

public class All_Timers : MonoBehaviour
{
    [SerializeField] private Metods_boosters _bools;
    public float _tHealth;
    public bool _tOxyTime;
    public TextMeshProUGUI _textTOxy;
    public float _tOxy;
    public bool _tHealthTime;
    public TextMeshProUGUI _textTHealth;
    public float _tAmountOxy = 7;
    public float _countForAmOx;
    public float[] _speedCount;
    public float[] _tAmOxy;
    public bool _tStartAmount;
    public TextMeshProUGUI _textScrDie;
    [SerializeField] private Sound _soundEndBuster;
    [SerializeField] private Counter _counter;
    [SerializeField] private MoveAcselorometr _flag;

    public void Update()
    {
        if (_tOxyTime == true)
        {
            _tOxy -= Time.deltaTime;
            _textTOxy.text = _tOxy.ToString("#,#");
            if (_tOxy < 0)
            {
                _tOxyTime = false;
                _tOxy = 20;
                _bools._boosttime[1] = false;
                _soundEndBuster.PlaySounds(4);//???? ????? ???????
                _bools._iconBoostsRan[1].transform.parent.gameObject.SetActive(false);
                Debug.Log(_bools._iconBoostsRan[1].transform.parent.gameObject.name);
            }
        }
        if (_tHealthTime == true)
        {
            _tHealth -= Time.deltaTime;
            _textTHealth.text = _tHealth.ToString("#,#");
            if (_tHealth < 0)
            {
                _tHealthTime = false;
                _tHealth = 10;
                _bools._boosttime[0] = false;
                _flag.flag = false;
                _soundEndBuster.PlaySounds(4);//???? ????? ???????
                _bools._iconBoostsRan[0].transform.parent.gameObject.SetActive(false);
                Debug.Log(_bools._iconBoostsRan[0].transform.parent.gameObject.name);
            }
        }
        if (_tStartAmount == true)
        {
            _tAmountOxy -= Time.deltaTime;
            if (_tAmountOxy < 0)
            {
                _counter.RecoveryAmmauntOxy();
                _tStartAmount = false;
                _tAmountOxy = _countForAmOx;
            }
        }
    }

    public float TimerOxy()
    {
        _tOxy -= Time.deltaTime;
        return _tOxy;
    }

    public void StartTimeOxy()
    {
        _tOxyTime = true;
    }

    public void StartTimeHealth()
    {
        _tHealthTime = true;
    }

    public void StartAmountOx(float _speed)
    {
        for (int j = 0; j < _speedCount.Length; j++)
        {
            if (_speed > _speedCount[j])
            {
                continue;
            }
            else
            {
                _countForAmOx = _tAmountOxy = _tAmOxy[j];
                _tStartAmount = true;
                return;
            }
        }
    }


    public float TimerHealth()
    {
        _tHealth -= Time.deltaTime;
        // Debug.Log("TimeHealth");
        return _tHealth;
    }

    public float TimerAmountOx()
    {
        _tAmountOxy -= Time.deltaTime;
        return _tOxy;
    }

    public void OnPauseRan()
    {
        Time.timeScale = 0;
        //  Debug.Log("timeScale " + 0);
    }

    public void OffPauseRan()
    {
        Time.timeScale = 1;
        // Debug.Log("timeScale "+ 1);
    }
}
