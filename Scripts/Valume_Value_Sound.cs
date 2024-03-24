using UnityEngine;
using UnityEngine.UI;


public class Valume_Value_Sound : MonoBehaviour
{
    [SerializeField] private Scrollbar _valueMusic;
    [SerializeField] private Scrollbar _valueSound;
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _sound;
    [SerializeField] private float _valMus;
    [SerializeField]private float _valSound;

    private void Start()
    {
      //  Debug.Log("Start");
        Load();
    }

    public void SliderSound(int i)//изменение параметра громкости
    {
        if (i == 1)
        {
            _valMus = _valueMusic.value;
            ValueMusicTest(_valMus, _music, _valueMusic);
            Save(_valMus, "ValMus");
        }
        if (i == 2)
        {
            _valSound = _valueSound.value;
            ValueMusicTest(_valSound, _sound, _valueSound);
            Save(_valSound, "ValSound");
        }
    }

   
    private void ValueMusicTest(float _val,AudioSource _mic, Scrollbar _valMic)// изменение громкости на основе параметра
    {
        _mic.volume = _val;
        _valMic.value = _val;
    }

    private void Save(float _vall, string name)
    {
        PlayerPrefs.SetFloat(name, _vall);
    }


    private void Load()
    {
        if (PlayerPrefs.GetFloat("ValMus") != 0)
        {
            _valMus = PlayerPrefs.GetFloat("ValMus");
            _music.volume = _valueMusic.value = _valMus;
        }
        if (PlayerPrefs.GetFloat("ValSound") != 0)
        {
            _valSound = PlayerPrefs.GetFloat("ValSound");
            _sound.volume = _valueSound.value = _valSound;
        }
    }



}
