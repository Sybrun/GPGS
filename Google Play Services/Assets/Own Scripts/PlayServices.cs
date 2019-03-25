using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;

public class PlayServices : MonoBehaviour
{
    public static PlayServices instance;
    public GameObject login_Fail;
    public GameObject login_Success;

    /// <summary>
    /// Creates an instance and activates "PlayGamesPlatform"
    /// </summary>
    public void Awake()
    {
        instance = this;
        PlayGamesPlatform.Activate();
    }

    void Start()
    {
        SignIn();
    }

    /// <summary>
    /// Signs the player in to the Google Play Services.
    /// </summary>
    public void SignIn()
    {
        
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        

        Social.localUser.Authenticate((bool success, string message) =>
        {
            if (success)
            {
                login_Success.SetActive(true);
            }
            else
            {
                login_Fail.SetActive(true);
                login_Fail.GetComponent<Text>().text = message;
            }

        });
    }

    #region Achievements

    /// <summary>
    /// Determines if the player has completed a certain Achievement.
    /// </summary>
    public void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100.0f, (bool success) =>
        {
            
        });
    }


    #endregion

    #region Leaderboards

    /// <summary>
    /// Adds the player's score to the Leaderboards (if the score is higher than the player's previous personal record).
    /// </summary>
    public void AddScoreToLeaderboard(string leaderboardId, long score)
    {
        Social.ReportScore(score, leaderboardId, success =>
        {

        });
    }


    #endregion
}
