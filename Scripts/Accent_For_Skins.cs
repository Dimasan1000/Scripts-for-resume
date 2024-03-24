using UnityEngine;
using System.Collections;

public class Accent_For_Skins : MonoBehaviour
{
    [SerializeField] private GameObject _pers;
    [SerializeField] private Vector3 _pos;
    [SerializeField] private Vector3 _Scale;
    [SerializeField] private GameObject[] _objOFF;
    public Vector3[] Position;
    public Vector3[] Scale;
    [SerializeField] int _skale;
    [SerializeField] private int _skins;
    [SerializeField] private GameObject _buttonSkale;
    public bool _enabledUp;
    public bool _enabledDown;

    public void Update()
    {
        if (_enabledUp == true)
        {
            Debug.Log(_pers.transform.localScale + "   " + Scale[_skins]);
            _enabledDown = false;
            _pers.transform.localScale = Vector3.Lerp(_pers.transform.localScale, Scale[_skins], 0.23f);//0.23
            _pers.transform.localPosition = Vector3.Lerp(_pers.transform.localPosition, Position[_skins], 0.23f);
        }
        if(_pers.transform.localScale.y>Scale[_skins].y-1f) 
        {
            _enabledUp = false;
        }
        if (_enabledDown == true)
        {
            Debug.Log(_pers.transform.localScale+"   "+ _Scale);
            _enabledUp = false;
            _pers.transform.localScale = Vector3.Lerp(_pers.transform.localScale, _Scale, 0.23f);
            _pers.transform.localPosition = Vector3.Lerp(_pers.transform.localPosition, _pos, 0.23f);
        }
        if (_pers.transform.localScale.y < _Scale.y+1)
        {
            _enabledDown = false;
        }

    }

   public void EmphasisOnTheExtremity(int _tabshop)
    {
        _skins = _tabshop;
        if(_skins == 4)
        _buttonSkale.SetActive(false);
        else
            _buttonSkale.SetActive(true);
        for (int i = 0; i < _objOFF.Length; i++)
        {
            _objOFF[i].SetActive(true);
        }
        _enabledUp = false;
        _enabledDown=true;
       // _pers.transform.localPosition = _pos;
       // _pers.transform.localScale = _Scale;
    }
    private void ScalePreviuw()
    {
        _enabledUp = true;
        //_pers.transform.localScale = Scale[_skins];
        // _pers.transform.localPosition = Position[_skins];
        for (int i = 0; i < _objOFF.Length; i++)
        {
            _objOFF[i].SetActive(false);
        }
    }
    public void ChangePosAndScaleUp()
    {
        if (_skale < 2)
        {
            switch (_skins)
            {
                case 0:
                    ScalePreviuw();
                    _objOFF[8].SetActive(true);
                    _objOFF[9].SetActive(true);
                    _objOFF[10].SetActive(true);
                    _objOFF[11].SetActive(true);
                    Debug.Log(_skins);
                    break;
                case 1:
                    ScalePreviuw();
                    _objOFF[0].SetActive(true);
                    _objOFF[12].SetActive(true);
                   
                    break;
                case 2:
                    ScalePreviuw();
                    _objOFF[2].SetActive(true);
                    
                    break;
                case 3:
                    ScalePreviuw();
                    _objOFF[1].SetActive(true);
                    break;
            }
        }
    }
    
    public void ChangePosAndScaleDown()
    {
        _enabledDown = true;
        _enabledUp = false;
        for (int i = 0; i < _objOFF.Length; i++)
        {
            _objOFF[i].SetActive(true);
        }
       // _pers.transform.localPosition = _pos;
       // _pers.transform.localScale = _Scale;
    }
}
