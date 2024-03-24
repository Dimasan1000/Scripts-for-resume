using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Playables;

public class PlayAnimAfterRan : MonoBehaviour
{
    public GameObject _player;
    public GameObject _playerAfterRan;
    public TextMeshProUGUI _bestDistanse;
    public TextMeshProUGUI _distanse;
    [SerializeField] private GameObject[] _hair = new GameObject[2];
    [SerializeField] private GameObject[] _bodyplayer;
    [SerializeField] private GameObject[] _hairAfterRan = new GameObject[2];
    [SerializeField] private GameObject[] _bodyplayerAfterRan;
    [SerializeField] private GameObject _afterRanScene;
    public Camera _afterRanCam;
    public ScreenDeath _return;
    public GameObject _mainCanvas;
    public Counter _dist;
    [SerializeField] private GameObject _rotateImage;
    public bool _flagAnimBonus;

    public void Update()
    {
        if (_afterRanScene.activeSelf == true)
            AnimImageWall();
    }

    // Start is called before the first frame update
    private void GetSettingsBody()
    {
        _hairAfterRan[0].gameObject.SetActive(_hair[0].activeSelf);
        _hairAfterRan[1].gameObject.SetActive(_hair[1].activeSelf);
        _hairAfterRan[0].GetComponent<Renderer>().material = _hair[0].GetComponent<Renderer>().material;
        _hairAfterRan[1].GetComponent<Renderer>().material = _hair[1].GetComponent<Renderer>().material;
        _bodyplayerAfterRan[4].GetComponent<Renderer>().material = _bodyplayer[4].GetComponent<Renderer>().material;
        for (int i = 0; i < 2; i++)
        {
            _bodyplayerAfterRan[1].GetComponent<Renderer>().materials[i].color = _bodyplayer[1].GetComponent<Renderer>().materials[i].color;
        }
        for (int i = 0; i < 2; i++)
        {
            _bodyplayerAfterRan[2].GetComponent<Renderer>().materials[i].color = _bodyplayer[2].GetComponent<Renderer>().materials[i].color;
        }
    }

    public void PlayAnim()
    {
        GetSettingsBody();
        _afterRanScene.gameObject.SetActive(true);
        _afterRanCam.depth = 1; //сменить камеру
        _afterRanScene.transform.GetChild(0).GetComponent<PlayableDirector>().enabled=true;
        Debug.Log("On");
        _mainCanvas.SetActive(false);
        _bestDistanse.text = PlayerPrefs.GetString("Distanse");
        _distanse.text = _dist._distanse.text;
    }

    public void ReportMetrika()
    {
        AppMetrika_Metods.RepADS("Not double coins after ran");
    }
   
    public void ButtonOffAnim()
    {
        _return.ResetButton();
        //_mainCanvas.SetActive();
       // _afterRanCam.depth = 0;
       
        _afterRanScene.transform.GetChild(0).GetComponent<PlayableDirector>().enabled = false;
        //_afterRanScene.gameObject.SetActive(false);

    }
  
    public void AnimImageWall()
    {
        Quaternion imageWall = _rotateImage.transform.localRotation;
        imageWall *= Quaternion.Euler(new Vector3(0, 0.5f, 0));
        _rotateImage.transform.localRotation = imageWall;
        Vector3 _scalebonus = _rotateImage.transform.localScale;
        if (_scalebonus.x >= 60 && _flagAnimBonus == false)
        {
            _scalebonus.x -= 0.5f;
            _scalebonus.y = _scalebonus.x;
            _rotateImage.transform.localScale = _scalebonus;
            if (_scalebonus.x < 61)
                _flagAnimBonus = true;
        }
        if (_scalebonus.x <= 100f && _flagAnimBonus == true)
        {
            _scalebonus.x += 0.5f;
            _scalebonus.y = _scalebonus.x;
            _rotateImage.transform.localScale = _scalebonus;
            if (_scalebonus.x > 99)
                _flagAnimBonus = false;
        }
    }
}
