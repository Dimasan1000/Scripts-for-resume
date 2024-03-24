using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource _audio;
    public AudioClip _clip;
    [SerializeField] private AudioClip[] _gameSounds;


    public void SoundB()
    {
        _audio.PlayOneShot(_clip);
    } 

    public void PlaySounds(int _S)
    {
        switch (_S)
        {
            case 0: _audio.PlayOneShot(_gameSounds[_S]); break;
            case 1: _audio.PlayOneShot(_gameSounds[_S]); break;
            case 2: _audio.PlayOneShot(_gameSounds[_S]); break;
            case 3: _audio.PlayOneShot(_gameSounds[_S]); break;
            case 4: _audio.PlayOneShot(_gameSounds[_S]); break;
            case 5: _audio.PlayOneShot(_gameSounds[_S]); break;
            case 6: _audio.PlayOneShot(_gameSounds[_S]); break;

        }
    }
}