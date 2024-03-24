using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Music : MonoBehaviour
{
    public GameObject _audioMusic;
    public AudioSource _audio;
    [SerializeField] private AudioClip[] _gameSounds;


    public void SoundMusicOn(int i)
    {
        _audioMusic.GetComponent<AudioSource>().enabled=true;
        _audio.clip = _gameSounds[i];
        _audio.Play();
    }
    public void SoundMusicOff()
    {
        _audioMusic.GetComponent<AudioSource>().enabled=false;
    }
}