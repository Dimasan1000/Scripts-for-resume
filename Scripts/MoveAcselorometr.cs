using UnityEngine;
using Cinemachine;
using TMPro;
using System;

public class MoveAcselorometr : MonoBehaviour
{
    private float _moveX;
    private float _moveY;
    [SerializeField] private Seve_Parametres _saveTest;
    [SerializeField] private Create_Tasks_Progress _tasks;
    [SerializeField] private Counter _Wall;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _playerAnim;
    [SerializeField] private GameObject _canvacGame;
    [SerializeField] private GameObject _canvasMenu;
    [SerializeField] private Change_Animation _changeAnim;
    [SerializeField] private Transform _garbageCollector;
    [SerializeField] private FixedJoystick _joystik;
    public float _speed;
    public float _buferZ;
    [SerializeField] private float _radius;
    public bool flag = false;
    public bool flagStop = false;
    public float _timerUpSpeed = 0.5f;
    public float _timerLowSpeed = 0.5f;
    public bool stopAnim;
    // [SerializeField] private TextMeshProUGUI FPs;
    public bool startSpeed;
    public bool _joystiOrfGiro;

    public void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Start()
    {
        Input.gyro.enabled = false;
        //Debug.Log("After Off" + Input.gyro.enabled);
    }

    private void Update()
    {
        // FPs.text = (1.0/Time.deltaTime).ToString("#");
        _Wall.Disdanse();
        if (_speed!=0)
        {
            OgranichDvizh();
        }
        
        if (Convert.ToInt32(_player.position.z) % 20 == 15)
        {
            flag = false;
            _changeAnim._flagDie = false;
        }
    }

    private void LateUpdate()
    {
        if (_buferZ > _speed)
        {
            _timerUpSpeed -= Time.deltaTime;
            _timerLowSpeed = _timerUpSpeed;
            if (_timerUpSpeed < 0 && startSpeed == true)
            {
                _Wall.SpeedafterWall();
                startSpeed = false;
                _timerUpSpeed = 0.5f;
                
            }
            if (_timerUpSpeed < 0 && startSpeed == false)
            {
                _Wall.RecoverySpeed();
            }
        }
        else if (_timerUpSpeed < -1)
        {
            _timerUpSpeed = 0.5f;
            startSpeed = true;
        }
        if (stopAnim == false)
        {
            EnableSpeed();
        }
        if (_timerUpSpeed < -1)
        {
            _timerLowSpeed = 0.5f;
        }
    }

    private void MoveCamera()
    {
        _camera.position = new Vector3(_player.position.x / 2.5f, (_player.position.y + 3f) / 2f, _player.position.z - 10);
        _camera.transform.LookAt(new Vector3(_player.position.x, _player.position.y + 2f, _player.position.z));
    }

    private void OgranichDvizh()
    {
        float _cornerX = 0;
        float _cornerY = 0;

        if (transform.position.x < 0)
            _cornerX = -transform.position.x;
        else _cornerX = transform.position.x;

        if (transform.position.y < 0)
            _cornerY = -transform.position.y;
        else _cornerY = transform.position.y;
        if (_cornerX + _cornerY <= _radius)
        {
            MOVE(true);
            MoveCamera();
        }
        else if (_cornerX + _cornerY >= _radius)
        {
            if (BeckwordMove())
            {
                MOVE(true);
                MoveCamera();
            }
            else
            {
                MOVE(false);
                MoveCamera();
            }
        }
    }

    private bool BeckwordMove()
    {
        if (_joystiOrfGiro == false)
        {
            switch (transform.position.x, transform.position.y)
            {
                case ( < 0, < 0): return Input.gyro.rotationRate.x > 0 && Input.gyro.rotationRate.y > 0;
                case ( > 0, < 0): return Input.gyro.rotationRate.x > 0 && Input.gyro.rotationRate.y < 0;
                case ( > 0, > 0): return Input.gyro.rotationRate.x < 0 && Input.gyro.rotationRate.y < 0;
                case ( < 0, > 0): return Input.gyro.rotationRate.x < 0 && Input.gyro.rotationRate.y > 0;
                default: return _moveX == 0 && _moveY == 0;
            }
        }
        else if (_joystiOrfGiro == true)
        {
            switch (transform.position.x, transform.position.y)
            {
                case ( < 0, < 0): return _joystik.Vertical+_joystik.Horizontal > 0;
                case ( > 0, < 0):
                    if (transform.position.x > -transform.position.y)
                    {
                        return _joystik.Vertical > -0.6 && _joystik.Horizontal < 0.7;
                    }
                    else if (transform.position.x < -transform.position.y)
                    {
                        return _joystik.Vertical > -0.7 && _joystik.Horizontal < 0.6;
                    }
                    Debug.Log(_joystik.Vertical);
                    return _joystik.Vertical>-0.7 && _joystik.Horizontal <0.7;
                case ( > 0, > 0): return _joystik.Vertical + _joystik.Horizontal < 0;
                case ( < 0, > 0):
                    if (-transform.position.x > transform.position.y)
                    {
                        return _joystik.Vertical < 0.7 && _joystik.Horizontal > -0.6; 
                    }
                    else if (-transform.position.x < -transform.position.y)
                    {
                        return _joystik.Vertical < 0.6 && _joystik.Horizontal > -0.7;
                    }
                    return _joystik.Vertical < 0 && _joystik.Horizontal > 0;
            }
        }
         return _moveX == 0 && _moveY == 0;
    }

    public void EnableGiroskope(int i)
    {
        if (i == 0)
        {
            Input.gyro.enabled = true;
        }
        else if (i == 1)
        {
            Input.gyro.enabled = false;
        }
    }

    public void EnableSpeed()
    {
        if (_playerAnim.transform.position.z > -0.5 && _playerAnim.transform.position.z < 0.5)
        {
            _camera.gameObject.GetComponent<CinemachineBrain>().enabled = false;
            _speed = 3.7f;
            _buferZ = _speed;
            stopAnim = true;
            _canvacGame.SetActive(true);
            _canvasMenu.SetActive(false);
            Time.timeScale = 1;
            EnableGiroskope(0);
        }
    }

    private void MOVE(bool _notMove)
    {
        if (_joystiOrfGiro == false)
        {
            transform.rotation = new Quaternion(-Input.gyro.rotationRate.x / 17, Input.gyro.rotationRate.y / 17, 0, 0.9f);//??????? ????????. ????????? ??????? ??????????.
            if (_notMove == true)
            {
                transform.Translate(Input.gyro.rotationRate.y * ((_speed / 2 + 12f) * Time.deltaTime), Input.gyro.rotationRate.x * ((_speed / 2 + 12f) * Time.deltaTime), _speed * Time.deltaTime, Space.World);
            }
            if (_notMove == false)
            {
                transform.Translate(new Vector3(0, 0, 1f * _speed * Time.deltaTime), Space.World);

            }
        }
        else if (_joystiOrfGiro == true)
        {
            transform.rotation = new Quaternion(-_joystik.Vertical/5 , _joystik.Horizontal/5, 0, 0.9f);//??????? ????????. ????????? ??????? ??????????.
            if (_notMove == true)
            {
                transform.Translate(_joystik.Horizontal * ((_speed / 5 + 5f) * Time.deltaTime), _joystik.Vertical * ((_speed / 5 + 5f) * Time.deltaTime), _speed * Time.deltaTime, Space.World);
              
            }
            if (_notMove == false)
            {
                transform.Translate(new Vector3(0, 0, 1f * _speed * Time.deltaTime), Space.World);

            }
        }
        _garbageCollector.position = new Vector3(0, 0, _player.position.z - 6f);
        _moveX = transform.rotation.x;
        _moveY = transform.rotation.y;

    }



    private void OnTriggerExit(Collider collision)
    {
        if (_Wall._metBoost._boosttime[1] == false)
        {
            if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Shark")
            {
                
                flagStop = false;
                transform.rotation = Quaternion.identity;
                _timerUpSpeed = 0.5f;
                _Wall.SpeedafterWall();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            other.transform.parent.GetChild(1).gameObject.SetActive(true);
            _Wall.CollectCoins(other.gameObject);

        }
        if (other.gameObject.tag == "speedMod")
        {
            other.transform.parent.GetChild(1).gameObject.SetActive(true);
            _Wall.SpeedMod("Up", other.gameObject);
        }
        else if (other.gameObject.tag == "speedModDown")
        {
            other.transform.parent.GetChild(1).gameObject.SetActive(true);
            
            _Wall.SpeedMod("Down", other.gameObject);
        }
        if (other.gameObject.tag == "Oxygen")
        {
            other.transform.parent.GetChild(1).gameObject.SetActive(true);
            Destroy(other.gameObject);
            _Wall.OxigenRecovery();
        }
        if (other.gameObject.tag == "Wall" && flag == false || other.gameObject.tag == "Shark" && flag == false)
        {
            if (_speed > _buferZ)
                _buferZ = _speed;
            _Wall.HelthReduction();
            flag = true;
        }
        if (other.gameObject.tag == "Shark" && _Wall._metBoost._boosttime[1] == false ||
           other.gameObject.tag == "Wall" && _Wall._metBoost._boosttime[1] == false)
        {
            if (_timerLowSpeed == 0.5)
                _speed = 0.1f;
            if (flagStop == false)
            {
                flagStop = true;
            }
        }
    }
}