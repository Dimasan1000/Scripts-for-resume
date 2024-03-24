using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using AppodealAds.Unity.Api;

public class ScreenDeath : MonoBehaviour
{
    [SerializeField] private GameObject _plaerBody;
    [SerializeField] private GameObject _die;
    [SerializeField] private SaveAndQuit _save;
    [SerializeField] private Counter _SaveDist;
    [SerializeField] private All_Timers _timerDie;
    [SerializeField] private FakeLiderboard _distanseLeader;

    public void DieScreen()
    {
        //?????????? ????? ????? ??????.
        Appodeal.cache(Appodeal.REWARDED_VIDEO);
        ControlDist();
        _die.SetActive(true);
        _save.Save();
        

        // _timerDie.StartTimerScreenDeath();

    }
    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ControlDist()
    {
        if (PlayerPrefs.HasKey("Distanse") == true)
        {
            int _ditssave = Convert.ToInt32(PlayerPrefs.GetString("Distanse"));
            int _myDist = Convert.ToInt32(_SaveDist._distanse.text);

            //  Debug.Log((_ditssave < _myDist) + "  " + _ditssave + " " + _myDist);

            if (_ditssave < _myDist)
            {
                PlayerPrefs.SetString("Distanse", _SaveDist._distanse.text);
              //  _distanseLeader.AddDistenseinLeaderBoard(_myDist);
            }
        }
        else if (PlayerPrefs.HasKey("Distanse") == false)
        {
            PlayerPrefs.SetString("Distanse", _SaveDist._distanse.text);
           // _distanseLeader.AddDistenseinLeaderBoard(Convert.ToInt32(_SaveDist._distanse.text));
        }
        // Debug.Log(PlayerPrefs.GetString("Distanse"));
    }
    public void FinishRep()
    {
        AppMetrika_Metods.RepFinish(_SaveDist._repFin);
        AppMetrika_Metods.RepADS("Not continue ran");
    }
}
