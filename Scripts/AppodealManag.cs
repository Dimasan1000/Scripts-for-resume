using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AppodealManag : MonoBehaviour, IAppodealInitializationListener, IRewardedVideoAdListener
{
   public string appKey = "6d307663540b6fee93cbf54a165bf35f5e69858860891ae6";
    [SerializeField] private PlayADV _afterRan;
    [SerializeField] private Save_date _bonus;
    public int _checkFinish;
    public AppMetrika_Metods _metrika;

    private void Start()
    {
        int adTypes = Appodeal.REWARDED_VIDEO| Appodeal.BANNER;
        Appodeal.setTesting(false);
        Appodeal.muteVideosIfCallsMuted(true);
        Appodeal.disableLocationPermissionCheck();
        Appodeal.initialize( appKey, adTypes);
        Appodeal.setRewardedVideoCallbacks(this);
    }
    public void onInitializationFinished(List<string> errors)
    {
        throw new System.NotImplementedException();
    }
    public void ShowRewardVideo()
    {
        if (Appodeal.canShow(Appodeal.REWARDED_VIDEO))
        {
            Appodeal.show(Appodeal.REWARDED_VIDEO);
        }
        else
        {
            Appodeal.cache(Appodeal.REWARDED_VIDEO);
        }
    }
    public void onRewardedVideoClicked()
    {
        AppMetrika_Metods.RepADS("Clicked");
        throw new System.NotImplementedException();
    }
    public void onRewardedVideoClosed(bool finished)
    {
        switch (_checkFinish)
        {
            case 0:

                _afterRan.SaveForADS();
                break;
            case 1:
                _afterRan.PlayAdvDoubleGet();
                break;
            case 2:
                _bonus.GetBonusADS();
                break;
        }
        AppMetrika_Metods.RepADS("ADSClosed");
        //throw new System.NotImplementedException();
    }

    public void onRewardedVideoExpired()
    {
        throw new System.NotImplementedException();
    }
    public void onRewardedVideoFailedToLoad()
    {
        AppMetrika_Metods.RepADS("FailedLoaded");
        throw new System.NotImplementedException();
    }
    public void onRewardedVideoFinished(double amount, string name)
    {
        AppMetrika_Metods.RepADS("Finished");
        throw new System.NotImplementedException();

    }
    public void onRewardedVideoLoaded(bool precache)
    {
        AppMetrika_Metods.RepADS("IsLoaded");
        throw new System.NotImplementedException();
    }
    public void onRewardedVideoShowFailed()
    {
        AppMetrika_Metods.RepADS("ShowFailed");
        throw new System.NotImplementedException();
    }
    public void onRewardedVideoShown()
    {
        AppMetrika_Metods.RepADS("Show");
        throw new System.NotImplementedException();
    }

   
}
