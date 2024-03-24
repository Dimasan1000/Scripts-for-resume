using UnityEngine;
using UnityEngine.UI;
public class LerpBoosters : MonoBehaviour
{
    public Button _oNE;
    public Button one;
    public Button two;
    public Button three;
    [SerializeField] private Button _culbits;
    private Vector3 _posCulbits = new Vector3(0, 0, 0);
    public int _countOnButtonCulbit = 3;
    public int count = 0;
    [SerializeField] public GameObject _cursor;
    
    bool _flagC=false;
    public void Update()
    {
        LerpBoost();
        MoveButonCulbit();
        if (_cursor.activeSelf == true)
        ChangeCursor();

    }


    public void ChangeCursor()
    {
        Vector2 _scaleC = _cursor.GetComponent<RectTransform>().sizeDelta;
        if (_scaleC.x >= 120 && _flagC == false)
        {
            _scaleC.x -= 2f;
            _scaleC.y = _scaleC.x;
            _cursor.GetComponent<RectTransform>().sizeDelta = _scaleC;
            Debug.Log("--scale");
            if (_scaleC.x < 121)
                _flagC = true;
        }
        if (_scaleC.x <= 200f && _flagC == true)
        {
            _scaleC.x += 2f;
            _scaleC.y = _scaleC.x;
            _cursor.GetComponent<RectTransform>().sizeDelta = _scaleC;
            Debug.Log("++scale");
            if (_scaleC.x > 199)
                _flagC = false;
        }
    }

    public void OnCursor()
    {
        _cursor.SetActive(true);
    }

    public void LerpBoost()
    {
        if (one.gameObject.activeSelf == true || two.gameObject.activeSelf == true || three.gameObject.activeSelf == true)
        {
            one.transform.position = new Vector3(Mathf.Lerp(one.transform.position.x, _oNE.transform.position.x, 0.1f), one.transform.position.y, one.transform.position.z);
            two.transform.position = new Vector3(Mathf.Lerp(two.transform.position.x, _oNE.transform.position.x, 0.15f), two.transform.position.y, two.transform.position.z);
            three.transform.position = new Vector3(Mathf.Lerp(three.transform.position.x, _oNE.transform.position.x, 0.2f), three.transform.position.y, three.transform.position.z);
            Debug.Log("Work");
        }
    }

    public void MoveButonCulbit()
    {
        if (_culbits.gameObject.activeSelf == true)
        {
            _culbits.transform.localPosition = Vector3.Lerp(_culbits.transform.localPosition, _posCulbits, 0.5f * Time.deltaTime);
            if (Vector3.Distance(_culbits.transform.localPosition, _posCulbits) < 150)
            {
                float _yButtonCulbit = Random.Range(-40, 40)*20;
                float _xButtonCulbit = Random.Range(-20, 20)*20;
                if(_yButtonCulbit<-500|| _yButtonCulbit>500&& _xButtonCulbit<-200|| _xButtonCulbit>200)
                _posCulbits = new Vector3(_xButtonCulbit, _yButtonCulbit, _culbits.transform.localPosition.z);
            }

        }
    }
    public void OnButtonCulbit()
    {
        if (count != _countOnButtonCulbit)
        {
            count++;
        }
        if (count == _countOnButtonCulbit)
        {
            _culbits.gameObject.SetActive(true);
            if (PlayerPrefs.HasKey("cursor") == false)
                OnCursor();
            _countOnButtonCulbit = Random.Range(10, 20);
            count = 0;
            PlayerPrefs.SetString("cursor", "0");
        }

    }
}
