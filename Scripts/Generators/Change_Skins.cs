using UnityEngine;
using UnityEngine.UI;

public class Change_Skins : MonoBehaviour
{
    public bool boy_Girl;
    public Logic_Tasks _logTask;
    public Logic_Progress _progress;
    [SerializeField] private GameObject[] _hair = new GameObject[2];
    [SerializeField] private GameObject _face;
    [SerializeField] private GameObject _tors;
    [SerializeField] private GameObject _hip;
    [SerializeField] private GameObject _legs;
    [SerializeField] private GameObject _back;
    [SerializeField] private GameObject[] _hairPersShop;
    [SerializeField] private GameObject[] _bodyPersShop;
    public Sound _clik;
    [SerializeField] private Sprite[] _iconHead;
    [SerializeField] private Image[] _imageHeadShop;
    public Color[] _colorHead;
    public Color[] _colorSoot;

    public void ChangeGender(int child)
    {
        if (child == 0)//Woman
        {
            for (int i = 0; i < _iconHead.Length / 2; i++)
            {
                _imageHeadShop[i].sprite = _iconHead[i];
                
            }
            _hair[0].SetActive(false);
            _hair[1].SetActive(true);
            _hairPersShop[0].SetActive(false);
            _hairPersShop[1].SetActive(true);

            boy_Girl = false;
            

        }
        if (child == 1)//Man
        {
            for (int i = _iconHead.Length / 2; i < _iconHead.Length; i++)
            {
                _imageHeadShop[i - _iconHead.Length / 2].sprite = _iconHead[i];
            }
            _hair[0].SetActive(true);
            _hair[1].SetActive(false);
            _hairPersShop[0].SetActive(true);
            _hairPersShop[1].SetActive(false);
            boy_Girl = true;
            _progress.ChangeChracter(1, 22);
        }
    }

    public void ChangeColor(Color col, string Name)
    {
       // _clik.SoundB();
        

        switch (Name)
        {
            case "Head":
                colorHair(boy_Girl, col);
                break;
            case "Tors":
                for (int i = 0; i <2; i++)
                {
                    _tors.GetComponent<Renderer>().materials[i].color = col;
                    _bodyPersShop[1].GetComponent<Renderer>().materials[i].color = col;
                }
                break;
            case "Legs":
                for (int i = 0; i < 2; i++)
                {
                    _hip.GetComponent<Renderer>().materials[i].color = col;
                    _bodyPersShop[2].GetComponent<Renderer>().materials[i].color = col;
                }
                break;
            case "Back":
                _back.GetComponent<Renderer>().material.color = col;
                _bodyPersShop[4].GetComponent<Renderer>().material.color = col;
                break;
        }
    }

    private void colorHair(bool hair, Color col)
    {
        _hair[1].GetComponent<Renderer>().material.color = col;
        _hair[0].GetComponent<Renderer>().material.color = col;
        _hairPersShop[1].GetComponent<Renderer>().material.color = col;
        _hairPersShop[0].GetComponent<Renderer>().material.color = col;
    }

   
}

