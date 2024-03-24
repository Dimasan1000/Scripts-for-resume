using System;
using UnityEngine;

public class Create_Coins_Ox_Health : MonoBehaviour
{
    [SerializeField] public Coin_Ox_Health _collections;
    private GameObject _segment;
    private GameObject _coin;
    private GameObject _oxigen;
    public GameObject _speedMod;
    [SerializeField] private Counter _createObst;
    public int _coutCreatePines;
    public GameObject[] _ModSpeed;
    [SerializeField] private GameObject _obstSpeedMod0;
    [SerializeField] private GameObject[] _obstSpeedMod1;
    [SerializeField] private GameObject[] _obstSpeedMod2;
    [SerializeField] private GameObject _obstSpeedMod3;
    public int _speedMod_OffOn;



    public Create_Coins_Ox_Health(GameObject Segment, GameObject Coin, GameObject Oxigen, GameObject speedMod)
    {
        _segment = Segment;
        _coin = Coin;
        _oxigen = Oxigen;
        _speedMod = speedMod;
    }

    public GameObject CreatePines(GameObject t, Vector3 _posPine)
    {
        int _randSegm = UnityEngine.Random.Range(0, _collections._pine[_coutCreatePines].pines.Length);
        Create_Coins_Ox_Health _tube = new Create_Coins_Ox_Health(_collections._pine[_coutCreatePines].pines[_randSegm], _collections.coin, _collections.oxigen, _collections.boostSpeed);
        float _posZ = _posPine.z - 6;
        GameObject _pine = Instantiate(_tube._segment, _posPine, _collections._pine[_coutCreatePines].pines[_randSegm].transform.rotation, t.transform);
        CreateObstacle(_tube, _pine, _posPine);
        CreateCoins(t, _posZ, _tube, _pine, _posPine);

        return _pine;
    }

    private void CreateObstacle(Create_Coins_Ox_Health test, GameObject _pine, Vector3 _posPine)
    {
        float _rotatObstY = Random(0, 8) * 45;
        int _obstMass = UnityEngine.Random.Range(0, _collections.obstacles.Count);
        Vector3 _posObst = new Vector3(_pine.transform.position.x, _pine.transform.position.y, _posPine.z + 10);
        Quaternion _rotObst = Quaternion.Euler(0, 0, _rotatObstY);
        Quaternion _rotOxy = Quaternion.Euler(0, 0, -_rotatObstY);
        int _RandEnd = _collections.obstacles[_coutCreatePines].obstacle.Length;
        GameObject _obst = Instantiate(_collections.obstacles[_coutCreatePines].obstacle[UnityEngine.Random.Range(0, _RandEnd)], _posObst, Quaternion.Euler(0, 0, 0), _pine.transform);
        _createObst.AdaptiveObstacles(_obst);
        GameObject _oXy = Instantiate(test._oxigen, new Vector3(-2, 0, _obst.transform.position.z), transform.localRotation= _rotOxy, _obst.transform);
        //метод создания ускор замедл. В зависимости какое препятствие.
        CreateSpeedMod(_obst, _rotOxy);
        
        _obst.transform.rotation = _rotObst;
      
        if(_speedMod!=null)
        _speedMod.transform.rotation= Quaternion.Euler(0, 0, 0);
    }

    public void CreateSpeedMod(GameObject _obst, Quaternion _rotspeedMod)
    {
        if (_speedMod_OffOn == 0)
        {
            PosSpeedMod(_obst, _rotspeedMod);
            _speedMod_OffOn = 1;
        }
        else if (_speedMod_OffOn == 1)
        {
            PosSpeedMod(_obst, _rotspeedMod);
            _speedMod_OffOn = 0;
        }
    }
    
    public void PosSpeedMod(GameObject _obst,Quaternion _rotspeedMod)
    {
        
       if(_obst.name== (_obstSpeedMod0.name+"(Clone)"))
        {
            _speedMod = Instantiate(_ModSpeed[_speedMod_OffOn], new Vector3(2.5f, 0, _obst.transform.position.z), _rotspeedMod, _obst.transform);
         //   Debug.Log(_obst.name + "  " + _obstSpeedMod0.name);
        }
        for (int i=0;i< _obstSpeedMod1.Length; i++)
        {
            if(_obst.name == (_obstSpeedMod1[i].name + "(Clone)"))
            {
                _speedMod = Instantiate(_ModSpeed[_speedMod_OffOn], new Vector3(2, -0.5f, _obst.transform.position.z), _rotspeedMod, _obst.transform);
               // Debug.Log(_obst.name + "  " + _obstSpeedMod1[i].name);
            }
        }

        for (int i = 0; i < _obstSpeedMod2.Length; i++)
        {
            if (_obst.name == (_obstSpeedMod2[i].name + "(Clone)"))
            {
                _speedMod = Instantiate(_ModSpeed[_speedMod_OffOn], new Vector3(2.5f, 0, _obst.transform.position.z), _rotspeedMod, _obst.transform);
              //  Debug.Log(_obst.name + "  " + _obstSpeedMod2[i].name);
            }
        }

        if(_obst.name == (_obstSpeedMod3.name + "(Clone)"))
        {
            int randMod = Convert.ToInt32(Random(0, 2));
          //  Debug.Log(randMod);
            switch (randMod)
            {
                case 0:
                    _speedMod = Instantiate(_ModSpeed[_speedMod_OffOn], new Vector3(3, 0, _obst.transform.position.z), _rotspeedMod, _obst.transform);
                    break;
                case 1:
                    _speedMod = Instantiate(_ModSpeed[_speedMod_OffOn], new Vector3(0.5f, 3, _obst.transform.position.z), _rotspeedMod, _obst.transform);
                    break;
                case 2:
                    _speedMod = Instantiate(_ModSpeed[_speedMod_OffOn], new Vector3(0, -3, _obst.transform.position.z), _rotspeedMod, _obst.transform);
                    break;
            }
        }
    }

    private void CreateCoins(GameObject tube, float _posZ, Create_Coins_Ox_Health test, GameObject _pine, Vector3 _posPine)
    {
        Vector3 _posCoin = tube.transform.position;
        for (int i = 0; i < 2; i++)
        {
            int _randomX = Convert.ToInt32(tube.transform.position.x + Random(-2.5f, 2.5f));
            int _randomY = Convert.ToInt32(tube.transform.position.y + Random(-2.5f, 2.5f));

            for (int j = 0; j < 2; j++)
            {
                _posCoin = new Vector3(_randomX, _randomY, _posZ);
                _posZ += 4;
                Instantiate(test._coin, _posCoin, tube.transform.rotation, _pine.transform);
            }
        }
    }


    private float Random(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }
}

