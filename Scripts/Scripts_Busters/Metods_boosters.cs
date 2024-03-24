using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Metods_boosters : MonoBehaviour
{
    [SerializeField] private Boosters booster;
    [SerializeField] private Boosters_Time boosterTime;
    [SerializeField] private Imission_Tab_shop _goToBooster;
    public Save_Boosters _SaveBoost;
    public Sound _soundBuster;
    public Save_Boosters _saveB;
    public bool[] _boost = new bool[2];
    public bool[] _boosttime = new bool[2];
    public int _boostCount = 0;
    public int boostModul = 0;
    [SerializeField] private Sprite[] _iconBoosters;
    public GameObject[] _iconBoostsRan;
    [SerializeField] private GameObject[] _goToshopBoost;
    [SerializeField] private GameObject[] _boosterRan;

    public void Coins2x()
    {
        if (booster._busterUnlimited._coin_2x == 0)
        {
            GotoShop("notTime", 0);
        }
        else if (booster._busterUnlimited._coin_2x > 0)
        {
            _soundBuster.PlaySounds(3);//???? ????????? ???????
            _boost[0] = true;
            booster._busterUnlimited._coin_2x -= 1;
            _SaveBoost.test();
            booster._buyBuster.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = _iconBoosters[0];
            _SaveBoost.SaveToFile();
        }
    }

    public void lives4()
    {
        if (booster._busterUnlimited._healthFour == 0)
        {
            GotoShop("notTime", 1);
        }
        else if (booster._busterUnlimited._healthFour > 0)
        {
            _soundBuster.PlaySounds(3);//???? ????????? ???????
            _boost[1] = true;
            booster._busterUnlimited._healthFour -= 1;
            _SaveBoost.test();
            booster._buyBuster.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = _iconBoosters[1];
            _SaveBoost.SaveToFile();
        }
    }

    public void OxyUnlimit()
    {
            _soundBuster.PlaySounds(3);//???? ????????? ???????
            _boosttime[0] = true;
        _iconBoostsRan[0].GetComponent<Image>().sprite = _iconBoosters[2];
            _SaveBoost.SaveToFile();
    }
    public void OxyUnlimitActive()
    {
        if (boosterTime._busterlimit._oxyUnlimit == 0)
        {
            GotoShop("time", 0);
        }
        else if (boosterTime._busterlimit._oxyUnlimit > 0 && _boosterRan[0].activeSelf==false )
        {
            _soundBuster.PlaySounds(3);
            _boosterRan[0].SetActive(true);
            boosterTime._busterlimit._oxyUnlimit -= 1; 
            _SaveBoost.test();
            _SaveBoost.SaveToFile();
            if (boosterTime._busterlimit._oxyUnlimit==0)
            booster._buyBuster.transform.GetChild(3).GetChild(0).GetComponent<Image>().sprite = _iconBoosters[2];
        }
    }

    public void livesUnlimit()
    {
            _soundBuster.PlaySounds(3);//???? ????????? ???????
            _boosttime[1] = true;
            _iconBoostsRan[1].GetComponent<Image>().sprite = _iconBoosters[3];
            _SaveBoost.SaveToFile();
    }
    public void livesUnlimitActive()
    {
        Debug.Log(boosterTime._busterlimit._unlimitLives);
        if (boosterTime._busterlimit._unlimitLives == 0)
        {
            GotoShop("time", 1);
        }
        else if (boosterTime._busterlimit._unlimitLives > 0&& _boosterRan[1].activeSelf == false)
        {
            _soundBuster.PlaySounds(3);
            _boosterRan[1].SetActive(true);
            boosterTime._busterlimit._unlimitLives -= 1;
            _SaveBoost.test();
            _SaveBoost.SaveToFile();
            if (boosterTime._busterlimit._unlimitLives == 0)
                booster._buyBuster.transform.GetChild(4).GetChild(0).GetComponent<Image>().sprite = _iconBoosters[3];
        }
    }

    public void BuyBuster()
    {
        _soundBuster.PlaySounds(3);
        if (boostModul==1)
        {
            booster.BayBuster(_boostCount);
        }
        else if (boostModul==2)
        {
            boosterTime.BayBusterLim(_boostCount);
        }
        _saveB.SaveToFile();
    }

    public void GotoShop(string name, int num)
    {
        _goToBooster.ShowPreview(1);
        _goToBooster.OpenModulTabShop(2);
        _goToBooster.ShowPriceModul(2);
        _goToBooster.ReSiseContent("boosters");
        _goToBooster.OnImmission(2);
        _goToshopBoost[5].SetActive(false);
        _goToshopBoost[6].SetActive(true);
        _goToshopBoost[7].SetActive(false);
        if (name == "time")
        {
            _goToshopBoost[0].SetActive(true);
            _goToshopBoost[1].SetActive(false);
            boosterTime.ChoiseBusterTime(num);
            ChoiseBuster(_goToshopBoost[0]);
        }
        else if(name == "notTime")
        {
            _goToshopBoost[1].SetActive(true);
            _goToshopBoost[0].SetActive(false);
            booster.ChoiseBuster(num);
            ChoiseBuster(_goToshopBoost[1]);
        }
    }
    private void ChoiseBuster(GameObject boostMassive)
    {
        _goToshopBoost[4].SetActive(true);
        _goToshopBoost[3].SetActive(true);
        boostMassive.transform.parent.gameObject.SetActive(true);
    }
}
