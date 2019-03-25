using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    GoldManager Script_GoldManager;
    SaveProgress Script_SaveProgress;

    public Text scoreText;

    private int score = 0;
    private int rewardCounter = 0;

    private bool isUnlocked_Restart = false;
    private bool isUnlocked_Leaderboards = false;
    private bool isUnlocked_EE = false;

    public GameObject Main;
    public GameObject Shop;
    public GameObject IAPShop;

    /// <summary>
    /// Reference to the "GoldManager" and "SaveProgress" scripts to get access to the necessary variables/functions.
    /// </summary>
    void Start()
    {
        Script_GoldManager = GetComponent<GoldManager>();
        Script_SaveProgress = GetComponent<SaveProgress>();
    }

    /// <summary>
    /// Here we check if the player should be rewarded for completing an Achievement
    /// </summary>
    public void Update()
    {
        #region Achievements

        if(score == 1)
        {
            PlayServices.instance.UnlockAchievement(GPGSIds.achievement_hit_or_miss);
        }

        if (score == 25)
        {
            PlayServices.instance.UnlockAchievement(GPGSIds.achievement_tactical_nuke_incoming);
        }

        if (score == 500)
        {
            PlayServices.instance.UnlockAchievement(GPGSIds.achievement_i_would_walk_500_miles);
        }

        if (score == 1000)
        {
            PlayServices.instance.UnlockAchievement(GPGSIds.achievement_and_i_would_walk_500_more);
        }

        if (score == 10000)
        {
            PlayServices.instance.UnlockAchievement(GPGSIds.achievement_winner_mentality);
        }

        if (isUnlocked_Leaderboards == true)
        {
            PlayServices.instance.UnlockAchievement(GPGSIds.achievement_lol_nerd);
        }

        if (isUnlocked_Restart == true)
        {
            PlayServices.instance.UnlockAchievement(GPGSIds.achievement_better_safe_than_sorry);
        }

        if (isUnlocked_EE == true)
        {
            PlayServices.instance.UnlockAchievement(GPGSIds.achievement_200_iq);
        }
        #endregion
    }

    /// <summary>
    /// Adding score and updating the counter to match the player's score.
    /// Also, it'll reward the player with Gold every 10 clicks after he has bought the "Remove Ads" IAP.
    /// </summary>
    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (Script_SaveProgress.activeAds == "false")
        {
            rewardCounter++;

            if (rewardCounter >= 10)
            {
                Script_GoldManager.addGold(1);
                Debug.Log("You clicked 10 times; Added 1 GOLD!");
                rewardCounter = 0;
            }
        }
    }

    /// <summary>
    /// Sets a bool to true (rewarding the player with an Achievement), Adds the score to the Leaderboards (if it's your new record),
    /// resets the score, updates the value of the counter accordingly and will call the ShowAd() function.
    /// </summary>
    public void Restart()
    {
        isUnlocked_Restart = true;
        PlayServices.instance.AddScoreToLeaderboard(GPGSIds.leaderboard_leaderboards, score);
        score = 0;
        scoreText.text = score.ToString();

        ShowAd();
    }

    /// <summary>
    /// Sets a bool to true (rewarding the player with an Achievement) and call the ShowLeaderboardsUI() function (which will display the Leaderboards to the player).
    /// </summary>
    public void Leaderboards()
    {
        isUnlocked_Leaderboards = true;
        Social.ShowLeaderboardUI();
    }

    /// <summary>
    /// This function will redirect to the ShowAchievementsUI() method (which will display the Achievements to the player).
    /// </summary>
    public void Achievements()
    {
        Social.ShowAchievementsUI();
    }

    /// <summary>
    /// Sets a bool to true (rewarding the player with an Achievement).
    /// </summary>
    public void EE()
    {
        isUnlocked_EE = true;
    }

    /// <summary>
    /// Closes the application.
    /// </summary>
    public void Leave()
    {
        Application.Quit();
    }

    /// <summary>
    /// Sets the appropriate GameObjects active and in-active.
    /// </summary>
    public void OpenShop()
    {
        Main.SetActive(false);
        Shop.SetActive(true);
        
    }
    /// <summary>
    /// Sets the appropriate GameObjects active and in-active.
    /// </summary>
    public void CloseShop()
    {
        Main.SetActive(true);
        Shop.SetActive(false);
    }

    /// <summary>
    /// Sets the appropriate GameObjects active and in-active.
    /// </summary>
    public void OpenIAPShop()
    {
        Main.SetActive(false);
        IAPShop.SetActive(true);
    }
    /// <summary>
    /// Sets the appropriate GameObjects active and in-active.
    /// </summary>
    public void CloseIAPShop()
    {
        Main.SetActive(true);
        IAPShop.SetActive(false);
    }

    /// <summary>
    /// Checks if the ad is ready to display and if the player should be shown an ad. If the criteria is met, a "rewardedVideo" will be shown to the player.
    /// </summary>
    public void ShowAd()
    {
        if (Advertisement.IsReady() && Script_SaveProgress.activeAds == "true")
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
        }
        else
        {
            Debug.Log("Ads are disabled!");
        }
    }
    /// <summary>
    /// Here we check if the player has either watched, skipped or failed the advertisement and we reward the player for his behaviour.
    /// </summary>
    /// <param name="result"></param>
    private void HandleAdResult(ShowResult result)
    {
        GoldManager goldManager = GetComponent<GoldManager>();

        switch (result)
        {
            case ShowResult.Finished:
                //Ad watched fully: Player gets big reward!
                goldManager.addGold(50);
                break;
            case ShowResult.Skipped:
                //Ad skipped: Player gets small reward.
                goldManager.addGold(20);
                break;
            case ShowResult.Failed:
                //Ad failed: No connection?
                break;
        }
    }
}
