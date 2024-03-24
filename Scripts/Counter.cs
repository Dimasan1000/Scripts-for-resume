using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private Logic_Progress _logic_AchivProg;
    [SerializeField] private Logic_Tasks _logic_Achiv;
    public Image _oxygen2;
    public Image _oxygen3;
    public Change_Animation _animRan;
    public ScreenDeath _death;
    [SerializeField] private SaveAndQuit _load;
    public GameObject _playerbody;
    public Metods_boosters _metBoost;
    [SerializeField] private CountervaluesforAppMetrica _coutHits;
    [SerializeField] private All_Timers _allTimers;
    [SerializeField] private PlayADV _textPlusCoin;
    public int _countCoin;
    public TextMeshProUGUI _coins;
    public TextMeshProUGUI _coinsToMenu;
    public int _countCristal;
    public TextMeshProUGUI _cristalMenu;
    public TextMeshProUGUI _distanse;
    public string _repFin;
    [SerializeField] private float _speedMnozh;
    [SerializeField] private float _countForSpeed;
    public Sound _soundPlay;
    public int _maxSpeed = 20;
    public float _time = 1f;
    private float _reBuferZ;
    private float _recoverySp;
    private int _countOx;
    public int _massOxy;
    private bool _boolOxy;
    private bool _getOxy;
    public bool _deathS;
    private float _distAchiv;
    [SerializeField] private bool[] _ObstChek;
    public GameObject _coinImission;
    public GameObject _objMod;
    private bool _checkCoin = false;
    private bool _checkMod = false;
    public bool _chekBonusCulbit = true;
    [SerializeField] private PlayAnimAfterRan _playAnim;
    [SerializeField] private ParticleSystem _boubles;
   


    void Start()
    {
        AppMetrika_Metods.EnterGame();
        _load.Load();
        _oxygen2.fillAmount = 1;
        _coinsToMenu.text = _coins.text = _countCoin.ToString();
        _cristalMenu.text = _countCristal.ToString();
        _playAnim.gameObject.SetActive(false);
        _playAnim._afterRanCam.depth = 0;
    }
    public void Update()
    {
        if (_coinImission != null)
        {
            _soundPlay.PlaySounds(1);//???? ?????? ??????
                    Destroy(_coinImission);
                    _coinImission = null;
                    _checkCoin = false;
        }
        if (_objMod != null)
        {
            _soundPlay.PlaySounds(3);
                Destroy(_objMod);
           
            _objMod = null;
                _checkMod = false;
        }

    }
    public void CollectCoins(GameObject coin)
    {
        switch (_metBoost._boost[0])
        {
            case false:
                _countCoin++;
                _textPlusCoin.CheckText(true, 1.ToString());
                _coinsToMenu.text = _coins.text = _countCoin.ToString();
                _logic_AchivProg.AchivCoins(_countCoin, "ValueCoin");
                break;
            case true:
                _countCoin += 2;
                _textPlusCoin.CheckText(true, 2.ToString());
                _coinsToMenu.text = _coins.text = _countCoin.ToString();
                _logic_AchivProg.AchivCoins(_countCoin, "ValueCoin");
                break;
        }
       
        _checkCoin = true;
        _coinImission = coin;
    }
    public void SpeedMod(string mod,GameObject _mod)
    {
        MoveAcselorometr _modSpeed= _playerbody.GetComponent<MoveAcselorometr>();
        if (mod == "Up" && _modSpeed._speed + _modSpeed._speed / 100 * 35<18)
        {

            _boubles.Play();
            _modSpeed._speed += _modSpeed._speed / 100 * 35;
            _checkMod = true;
            _objMod = _mod;
        }
        if(mod == "Down"&& _modSpeed._speed + _modSpeed._speed / 100 * 35 >3.7)
        {
            _modSpeed._speed -= _modSpeed._speed / 100 * 35;
            _checkMod = true;
            _objMod = _mod;
        }
    }

    public void OxigenReduction(float player)
    {
        _logic_Achiv.AchivOxy(_countOx, 0);
        int _posZ = Convert.ToInt32(player);
        if (_posZ != 0 && _posZ % 20 == 0)
        {
            if (_boolOxy == false)
            {
                _countOx = 0;
            }
            _boolOxy = false;
            if (_getOxy == false)
            {
                if (_metBoost._boosttime[0] == false)
                {
                    _oxygen2.fillAmount -= 0.03f;
                    _getOxy = false;
                }
                else
                if (_metBoost._boosttime[0] == true && _allTimers.TimerOxy() < 0)
                    _metBoost._boosttime[0] = false;
            }
            else
                _getOxy = false;
            MoveAcselorometr _speedUp = _playerbody.GetComponent<MoveAcselorometr>();
            if (_speedUp._speed < _maxSpeed)
            {
                _speedUp._speed += SpeedMnozh(_speedUp._speed);
                _logic_Achiv.AchivSpeed(1);
            }
        }
        if (_oxygen2.fillAmount <= 0)
        {
            _logic_AchivProg.AchivDistanse(Convert.ToInt32(_playerbody.transform.position.z), "Distanse");
            _logic_AchivProg.AchivValOxy(_massOxy, "Count_Oxy");
            _playerbody.GetComponent<MoveAcselorometr>()._speed = 0;
            _deathS = true;
            _playerbody.GetComponent<MoveAcselorometr>().EnableGiroskope(1);
            _animRan.StartAnimDie();
            _repFin = "Out of Oxygen";
            // AppMetrika_Metods.RepFinish("Out of Oxygen");
            _death.DieScreen();
        }
        _distAchiv = Convert.ToUInt32(_distanse);  
    }
    private float SpeedMnozh(float _sP)
    {
        if (_sP > _countForSpeed)
        {
            _countForSpeed++;
            _speedMnozh = _speedMnozh / 1.04f;
        }
        if (_sP < _countForSpeed)
        {
            return _speedMnozh;
        }
        return _speedMnozh;
    }
    public void OxigenRecovery()
    {

        _boolOxy = true;
        if (_boolOxy == true)
        {
            _countOx++;
        }
        _massOxy++;
        if (_oxygen2.fillAmount <= 1 - _oxygen3.fillAmount)
        {
            _soundPlay.PlaySounds(2);//???? ?????? ?????????
            _oxygen2.fillAmount += 0.05f;
            _getOxy = true;
        }
    }
    public void HelthReduction()
    {
        Health();
        if (_metBoost._boosttime[1] == false)
        {
            _oxygen3.fillAmount = 1 - _oxygen2.fillAmount;
            _reBuferZ = _playerbody.GetComponent<MoveAcselorometr>()._buferZ / 2;
            _recoverySp = _reBuferZ / 10;
        }
        if (_oxygen2.fillAmount <= 0)
        {
            _logic_AchivProg.AchivDistanse(Convert.ToInt32(_playerbody.transform.position.z), "Distanse");
            _logic_AchivProg.AchivValOxy(_massOxy, "Count_Oxy");
            _playerbody.GetComponent<MoveAcselorometr>()._speed = 0;
            _deathS = true;
            _playerbody.GetComponent<MoveAcselorometr>().EnableGiroskope(1);
            _repFin = "Collision with Obstacle";
            _animRan.StartAnimDie();
            //_death.DieScreen();
            //  AppMetrika_Metods.RepFinish("Collision with Obstacle");
        }
        _distAchiv = Convert.ToUInt32(_distanse);
        SpeedafterWall();
    }
    private void Health()
    {
        BonusCulbit();
        if (_allTimers.TimerHealth() < 0)
            _metBoost._boosttime[1] = false;
        if (_metBoost._boosttime[1] == false && _deathS == false)
        {     
            if (_metBoost._boost[1] == false)
            {
                if (_oxygen2.fillAmount > 0.5)
                {
                    _oxygen2.fillAmount = 0.5f;
                }
                if (_oxygen2.fillAmount < 0.5)
                {
                    _oxygen2.fillAmount -= 0.5f;
                }
                _coutHits.CounterforAppMetrica(0);
                _allTimers.StartAmountOx(_playerbody.GetComponent<MoveAcselorometr>()._buferZ);
                SoundDamageDie();
                _animRan.StartAnimDamage();
            }
            else if (_metBoost._boost[1] == true)
            {
                _oxygen2.fillAmount -= 0.25f;
                _coutHits.CounterforAppMetrica(0);
                _allTimers.StartAmountOx(_playerbody.GetComponent<MoveAcselorometr>()._buferZ);
                SoundDamageDie();
                _animRan.StartAnimDamage();
            }   
        }
    }
    private void SoundDamageDie()
    {
        if (_oxygen2.fillAmount - 0.25f > 0 || _oxygen2.fillAmount - 0.5f > 0)
            _soundPlay.PlaySounds(0);
        else
            _soundPlay.PlaySounds(5);
    }
    public void BonusCulbit()
    {
        if (_animRan.animator.GetCurrentAnimatorStateInfo(0).IsName("Swim") == false &
            _animRan.animator.GetCurrentAnimatorStateInfo(0).IsName("Stay") == false &
            _animRan.animator.GetCurrentAnimatorStateInfo(0).IsName("Die") == false &
            _animRan.animator.GetCurrentAnimatorStateInfo(0).IsName("Damage") == false)
        {
            _chekBonusCulbit = false;
            Debug.Log("_chekBonusCulbit = " + _chekBonusCulbit);
        }
    }
    public void Disdanse()
    {
        int dist = Convert.ToInt32(_playerbody.transform.position.z) + 20;
        _distanse.text = dist.ToString();
        MoveAcselorometr _speedUp = _playerbody.GetComponent<MoveAcselorometr>();
        _logic_Achiv.AchivDistDamage(_distAchiv, dist, 2);
    }
    public void RecoverySpeed()
    {
        MoveAcselorometr Speed = _playerbody.GetComponent<MoveAcselorometr>();
        int count = 10;
        _time -= Time.deltaTime;
        while (count != 0 && _time < 0 && _oxygen2.fillAmount > 0)
        {
            Speed._speed += _recoverySp;
            _time = 0.1f;
            count--;
        }
    }
    public void SpeedafterWall()
    {
        MoveAcselorometr Speed = _playerbody.GetComponent<MoveAcselorometr>();
        if (_oxygen2.fillAmount > 0)
        {
            Speed._speed = 3.7f;
        }
    }
    public void RecoveryAmmauntOxy()
    {
        _oxygen3.fillAmount = 0;
    }
    public void AdaptiveObstacles(GameObject _obst)
    {
        switch (_playerbody.GetComponent<MoveAcselorometr>()._buferZ, _playerbody.GetComponent<MoveAcselorometr>()._buferZ)
        {
            case ( > 15, < 21):
                if (_ObstChek[0] == false)
                {
                    _obst.transform.GetChild(0).gameObject.SetActive(false);
                    _ObstChek[0] = true;
                    return;
                }
                else if (_ObstChek[0] == true)
                    _ObstChek[0] = false;
                break;
               
        }
    }
}
