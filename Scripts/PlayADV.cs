using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Linq.Expressions;

public class PlayADV : MonoBehaviour
{
    [SerializeField] private AppodealManag _ads;
    [SerializeField] private All_Timers _timer;
    [SerializeField] private Counter _counter;
    public int _beforeRan;
    public int _differense;
    [SerializeField] private GameObject _screenDie;
    [SerializeField] private GameObject _screenSave;
    [SerializeField] private Play_Music _stopMusic;
    [SerializeField] private GameObject _offGameCore;
    [SerializeField] private GameObject _panelOn;
    [SerializeField] private SaveAndQuit _saveAndQuit;
    [SerializeField] private Logic_Tasks _coinRan;
    [SerializeField] private PlayAnimAfterRan _playAnim;
    [SerializeField] private GameObject _textPlus;
    public float[] _posY;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private bool[] _flag;
    public GameObject _playerPosZ;
    public int _mnozhCristal;
    public TextMeshProUGUI _priseRaRan;
    [SerializeField] private GameObject[] _colorcountes_button;
    [SerializeField] private float timer=0.2f;
    [SerializeField] private bool[] flagcolor;
    [SerializeField] private TextMeshProUGUI _crist;

    public void Start()
    {
        _posY[0] = _textPlus.transform.position.y + 20;
        _posY[1] = _crist.gameObject.transform.position.y + 20;
    }
    public void Update()
    {
        if (_flag[0] == true|| _flag[1] == true)
        {
            TextCounterPlus();
        }
        if (flagcolor[2] == true)
        {
            ImissionCrisralsInRan();
        }
    }


    public void CoinsBeforeRan()
    {
        _beforeRan = _counter._countCoin;
        AppMetrika_Metods.RepStart();
    }

    public void CoinsTextAfterRan()
    {
        _screenDie.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Watch for double your "+ (_counter._countCoin - _beforeRan)+ " coins.";
        _screenDie.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Get " + (_counter._countCoin - _beforeRan) * 2;
    }

    public void PlayAdvSave()
    {
        //???????? ??????? ? ???? ?? ??????????? ?? ????V
        _ads._checkFinish = 0;
        _ads.ShowRewardVideo();
       
    }
    public void CristalSave()
    {
        if (_counter._countCristal>25*_mnozhCristal)
        {
            _counter._countCristal -= 25 * _mnozhCristal;
            Debug.Log(25 * _mnozhCristal);
            _counter._cristalMenu.text = _counter._countCristal.ToString();
            _counter._deathS = false;
            _screenSave.SetActive(false);
            _counter._oxygen2.fillAmount = 1;
            _counter._oxygen3.fillAmount = 0;
            _counter._playerbody.GetComponent<MoveAcselorometr>()._speed = 3;
            _counter._animRan.ResetSwim();
        }
        else if (_counter._countCristal < 25 * _mnozhCristal)
        {
            //украснить каунтер кристаллов и кнопку.
            flagcolor[2] = true;
            _flag[1] = true;
        }
    }

    public void ImissionCrisralsInRan()
    {
        Debug.Log("Work");
        timer -=0.06f;
        if (_colorcountes_button[0].GetComponent<Image>().color != Color.red && flagcolor[0] == false)
        {
            if (timer < 0)
            {
                _colorcountes_button[0].GetComponent<Image>().color = Color.Lerp(_colorcountes_button[0].GetComponent<Image>().color, Color.red, 0.4f);
                _colorcountes_button[1].GetComponent<Image>().color = Color.Lerp(_colorcountes_button[0].GetComponent<Image>().color, Color.red, 0.4f);
                timer = 0.01f;
            }
            if (_colorcountes_button[0].GetComponent<Image>().color == Color.red && flagcolor[0] == false)
            {
                flagcolor[0] = true;
                timer = 0.3f;
            }
        }
        else if (_colorcountes_button[0].GetComponent<Image>().color != Color.white && flagcolor[1] == false)
        {
            if (timer < 0)
            {
                _colorcountes_button[0].GetComponent<Image>().color = Color.Lerp(_colorcountes_button[0].GetComponent<Image>().color, Color.white, 0.4f);
                _colorcountes_button[1].GetComponent<Image>().color = Color.Lerp(_colorcountes_button[0].GetComponent<Image>().color, Color.white, 0.4f);
                timer = 0.02f;
            }
            if (_colorcountes_button[0].GetComponent<Image>().color == Color.white && flagcolor[1] == false)
            {
                flagcolor[1] = true;
            }
        }
        else if (flagcolor[0] == true && flagcolor[1] == true)
        {
            flagcolor[2]=flagcolor[0] = flagcolor[1] = false;
        }
    }

    public void SaveForADS()
    {
        _counter._deathS = false;
        _screenSave.SetActive(false);
        _counter._oxygen2.fillAmount = 1;
        _counter._oxygen3.fillAmount = 0;
        _counter._playerbody.GetComponent<MoveAcselorometr>()._speed = 3;
        _counter._animRan.ResetSwim();
    }


    public void PlayADVDouble()
    {
        _ads._checkFinish = 1;
        _ads.ShowRewardVideo();
        //PlayAdvDoubleGet();
    }
    public void PlayAdvDoubleGet()
    {
        StartCoroutine(PlayAdvDoubleCurotine());
    }

    private IEnumerator PlayAdvDoubleCurotine()
    {

        //????? ????????? ????????? ???????
        
        AchivCoinRan();
        _counter._countCoin += _differense;
        _saveAndQuit.Save();
        yield return new WaitForSeconds(0);
         _panelOn.SetActive(true);
        _stopMusic.SoundMusicOff();
        _playAnim.PlayAnim();
        _offGameCore.SetActive(false);
    }
    public void AchivCoinRan()
    {
        if (_beforeRan != 0)
        {
            _differense = _counter._countCoin - _beforeRan;
        }
        else
            _differense = 0;
        _coinRan.AchivCoinsRan(6, _differense);
        AppMetrika_Metods.CollectCoinsInRan(_differense);
        // Debug.Log(_counter._countCoin - _beforeRan);
    }


    public void CheckText(bool flag, string textval) 
    {
     _flag[0] = flag;
        _priceText.text= "+" + textval;
        Debug.Log(_priceText);
    }


    public void TextCounterPlus()
    {
        if (_flag[0] == true && _textPlus.transform.position.y < _posY[0])
        {
            _textPlus.gameObject.SetActive(true);
            _textPlus.GetComponent<TextMeshProUGUI>().text = _priceText.text;
            _textPlus.transform.position = Vector3.Lerp(_textPlus.transform.position,
                new Vector3(_textPlus.transform.position.x, _posY[0], _textPlus.transform.position.z), 0.07f);
        }
        if (_textPlus.transform.position.y > _posY[0] -1 )
        {
            _flag[0] = false;
            _textPlus.transform.position = new Vector3(_textPlus.transform.position.x, _posY[0] - 20, _textPlus.transform.position.z);
            _textPlus.gameObject.SetActive(false);
        }


        if (_flag[1] == true && _crist.gameObject.transform.position.y < _posY[1])
        {
            _crist.gameObject.gameObject.SetActive(true);
           // _crist.gameObject.GetComponent<TextMeshProUGUI>().text = _priceText.text;
            _crist.gameObject.transform.position = Vector3.Lerp(_crist.gameObject.transform.position,
                new Vector3(_crist.gameObject.transform.position.x, _posY[1], _crist.gameObject.transform.position.z), 0.05f);
        }
        if (_crist.gameObject.transform.position.y > _posY[1] - 1)
        {
            _flag[1] = false;
            _crist.gameObject.transform.position = new Vector3(_crist.gameObject.transform.position.x, _posY[1] - 20, _crist.gameObject.transform.position.z);
            _crist.gameObject.gameObject.SetActive(false);
        }
    }
}
