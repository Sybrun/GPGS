using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    GoldManager Script_GoldManager;
    SkinManager Script_SkinManager;

    public string activeAds;
    public string unlocked_Green;
    public string unlocked_Crimson;
    public string unlocked_Cyan;
    public string unlocked_Violet;
    public string unlocked_Gold;

    /// <summary>
    /// Reference to the "GoldManager" and "SkinManager" scripts to get access to the necessary variables/functions and keeping track of the player's progress in the game 
    /// (this includes the player's Gold, unlocked skins and whether or not the player has purchased "Remove Ads" from the IAP Shop) so that the player will not lose his 
    /// progress after closing the game.
    /// </summary>
    void Start()
    {
        Script_GoldManager = GetComponent<GoldManager>();
        Script_SkinManager = GetComponent<SkinManager>();

        //To reset ActiveAds:
        //PlayerPrefs.DeleteKey("ActiveAds");
        activeAds = PlayerPrefs.GetString("ActiveAds", "true");
        if (activeAds == "true")
        {
            Debug.Log("Ads should work.");
        }
        else if (activeAds == "false")
        {
            Debug.Log("Ads should NOT work.");
        }
        else
        {
            Debug.Log("ERROR: activeAds != true or false.");
        }

        //To reset Gold:
        //PlayerPrefs.DeleteKey("Gold");
        Script_GoldManager.gold = PlayerPrefs.GetInt("Gold", 0);

        #region Skins
        //To reset Green:
        //PlayerPrefs.DeleteKey("Unlocked_Green");
        unlocked_Green = PlayerPrefs.GetString("Unlocked_Green", "false");

        if (unlocked_Green == "true")
        {
            Script_SkinManager.Panel_Cost_Green.SetActive(false);
        }

        //To reset Crimson:
        //PlayerPrefs.DeleteKey("Unlocked_Crimson");
        unlocked_Crimson = PlayerPrefs.GetString("Unlocked_Crimson", "false");

        if (unlocked_Crimson == "true")
        {
            Script_SkinManager.Panel_Cost_Crimson.SetActive(false);
        }

        //To reset Cyan:
        //PlayerPrefs.DeleteKey("Unlocked_Cyan");
        unlocked_Cyan = PlayerPrefs.GetString("Unlocked_Cyan", "false");

        if (unlocked_Cyan == "true")
        {
            Script_SkinManager.Panel_Cost_Cyan.SetActive(false);
        }

        //To reset Violet:
        //PlayerPrefs.DeleteKey("Unlocked_Violet");
        unlocked_Violet = PlayerPrefs.GetString("Unlocked_Violet", "false");

        if (unlocked_Violet == "true")
        {
            Script_SkinManager.Panel_Cost_Violet.SetActive(false);
        }

        //To reset Gold:
        //PlayerPrefs.DeleteKey("Unlocked_Gold");
        unlocked_Gold = PlayerPrefs.GetString("Unlocked_Gold", "false");

        if (unlocked_Gold == "true")
        {
            Script_SkinManager.Panel_Cost_Gold.SetActive(false);
        }
        #endregion
    }
}
