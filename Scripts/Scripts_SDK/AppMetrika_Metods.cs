using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class AppMetrika_Metods : MonoBehaviour
{
    public static Action<bool> FinActiv;
    public static Action<bool> StartActiv;
    public static Action<bool> DiePlayercount;
    public static bool con = false;
    static int bo;


    /// <summary>
    /// Enter in Game.
    /// </summary>
    public static void EnterGame()
    {
        Dictionary<string, object> report = new Dictionary<string, object>();
        report.Add("Enter game", SceneManager.GetActiveScene().buildIndex);
        AppMetrica.Instance.ReportEvent("Enter Game", report);
        AppMetrica.Instance.SendEventsBuffer();
    }
  
    /// <summary>
    /// Start
    /// </summary>
    public static void RepStart()
    {
      //  Debug.Log("Start   Start Ran");
        Dictionary<string, object> report = new Dictionary<string, object>();
        report.Add("Start", "Start Ran");
        AppMetrica.Instance.ReportEvent("Start", report);
        AppMetrica.Instance.SendEventsBuffer();
    }

    /// <summary>
    /// Finish
    /// </summary>
    public static  void RepFinish(string _repFin)
    {
        Debug.Log("Finish "+ _repFin);
        Dictionary<string, object> report = new Dictionary<string, object>();
        report.Add("Finish", _repFin);
        AppMetrica.Instance.ReportEvent("Finish", report);
        AppMetrica.Instance.SendEventsBuffer();
    }
    
    /// <summary>
    /// Main Menu
    /// </summary>
    /// <param name="nameButton"></param>
    public static void ClicMainMenu(string nameButton)
    {
       // Debug.Log("Main Menu  "+ nameButton);
        Dictionary<string, object> report = new Dictionary<string, object>();
        report.Add("Main Menu", nameButton);
        AppMetrica.Instance.ReportEvent("Click", report);
        AppMetrica.Instance.SendEventsBuffer();
    }

    /// <summary>
    /// Main Buttons Shop
    /// </summary>
    /// <param name="nameButtonShop"></param>
    public static void ClicMainButtonInShop(string nameButtonShop)
    {
       // Debug.Log("Main Button Shop "+ nameButtonShop);
        Dictionary<string, object> report = new Dictionary<string, object>();
        report.Add("Main Button Shop", nameButtonShop);
        AppMetrica.Instance.ReportEvent("Click", report);
        AppMetrica.Instance.SendEventsBuffer();
    }

    /// <summary>
    /// Rewive
    /// </summary>
    /// <param name="count"></param>
    public static void CountClicRewive(int count)
    {
       // Debug.Log("Button Rewive "+count);
        Dictionary<string, object> report = new Dictionary<string, object>();
        report.Add("Button Rewive", count);
        AppMetrica.Instance.ReportEvent("Click", report);
        AppMetrica.Instance.SendEventsBuffer();
    }

    /// <summary>
    /// Collect Coins
    /// </summary>
    /// <param name="coins"></param>
    public static void CollectCoinsInRan(int coins)
    {
       // Debug.Log("Coin "+coins);
        Dictionary<string, object> report = new Dictionary<string, object>();
        report.Add("Coin", coins);
        AppMetrica.Instance.ReportEvent("Collect", report);
        AppMetrica.Instance.SendEventsBuffer();
    }

    /// <summary>
    /// Hit Obstacles
    /// </summary>
    /// <param name="hits"></param>
    public static void CountHitsInRan(int hits)
    {
       // Debug.Log("HitsObs " + hits);
        Dictionary<string, object> report = new Dictionary<string, object>();
        report.Add("Hits", hits);
        AppMetrica.Instance.ReportEvent("Hits", report);
        AppMetrica.Instance.SendEventsBuffer();
    }

    /// <summary>
    /// Clic Buster 2x.
    /// </summary>
    /// <param name="hits"></param>
    public static void Count2xBuster(int count)
    {
       // Debug.Log("DoubleBuster " + count);
        Dictionary<string, object> report = new Dictionary<string, object>();
        report.Add("DoubleBuster", count);
        AppMetrica.Instance.ReportEvent("Double", report);
        AppMetrica.Instance.SendEventsBuffer();
    }

    /// <summary>
    /// Click any Tacks or Progress
    /// </summary>
    /// <param name="nameButon"></param>
    public static void ClicButtonTascksAndProgr(string nameButon)
    {
      //  Debug.Log("Achivs "+ nameButon);
        Dictionary<string, object> report = new Dictionary<string, object>();
        report.Add("Achivs", nameButon);
        AppMetrica.Instance.ReportEvent("Achivs", report);
        AppMetrica.Instance.SendEventsBuffer();
    }

    /// <summary>
    /// Time
    /// </summary>
    /// <param name="time"></param>
    public static void RepTimeOnGame(float time)//считать время в игре от входа в игру, до выхода и выводить в апп метрику.
    {
            Dictionary<string, object> report = new Dictionary<string, object>();
            report.Add("level_number", time);
            AppMetrica.Instance.ReportEvent("level_finish", report);
            AppMetrica.Instance.SendEventsBuffer();
        
    }
    public static void RepADS(string _repADS)
    {
        Debug.Log("ADS " + _repADS);
        Dictionary<string, object> report = new Dictionary<string, object>();
        report.Add("ADS", _repADS);
        AppMetrica.Instance.ReportEvent("ADS", report);
        AppMetrica.Instance.SendEventsBuffer();
    }
}