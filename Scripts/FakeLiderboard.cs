using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class FakeLiderboard : MonoBehaviour
{
    [SerializeField] private GameObject _statePlayer;
    [SerializeField] private GameObject _leaderBoard;
    private const string _liderBoard = "";//идентификатор лидерборда в гугле

    private void Start()
    {
        // _disT = PlayerPrefs.GetString("Distanse");
        // GenerateLeaderboard();
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(success=> 
        {
            if (success)
            {

            }
            else
            {

            }
        
        });
    }


    public void AddDistenseinLeaderBoard(int dist)
    {
        Social.ReportScore(dist, _liderBoard, (bool success) => { });
    }

    public void ShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }

    public void ExitFromGPGS()
    {
    }

}
